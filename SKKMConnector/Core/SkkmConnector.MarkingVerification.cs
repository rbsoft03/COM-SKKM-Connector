using System.ComponentModel;
using RBSoft.MarkingVerification;
using RBSoft.MarkingVerification.Dto.TsPiot;
using PkgCheckCodeMarkAnswer = RBSoft.MarkingVerification.Dto.MarkirovkaApi.CheckCodeMarkAnswer;
using PkgCodeMarkInfo = RBSoft.MarkingVerification.Dto.MarkirovkaApi.CodeMarkInfo;
using PkgErrorCode = RBSoft.MarkingVerification.Enums.ErrorCode;

namespace RBSoftSkkm;

/// <summary>
/// Прямая проверка кодов маркировки через пакет RBSoft.MarkingVerification — минуя сервер ККМ,
/// напрямую к сервисам проверки (Честный Знак True API, ТС ПИоТ, локальный модуль ЧЗ).
/// В отличие от <see cref="SkkmConnector.VerifyMarking"/>/<see cref="SkkmConnector.VerifyMarkingTsPiot"/>/
/// <see cref="SkkmConnector.VerifyMarkingLmcz"/> (которые проксируются через сервер ККМ), эти методы
/// работают без него.
/// </summary>
public sealed partial class SkkmConnector
{
    /// <summary>
    /// Прямая проверка кодов маркировки через Честный Знак (True API) — минуя сервер ККМ.
    /// Коды берутся из <see cref="MarkingCodes"/>, токен и CDN-сервер — из
    /// <see cref="MarkingTrueApiToken"/>/<see cref="MarkingTrueApiCdnServer"/>.
    /// Результат — в <see cref="MarkingVerify"/> (тот же формат, что и у <see cref="VerifyMarking"/>).
    /// </summary>
    public async Task CheckMarkingTrueApiDirect()
    {
        var wrapper = await Task.Run(() => new MarkingCodeVerifier().CheckTrueApi(
            MarkingCodes.ToArray(), MarkingTrueApiToken, MarkingTrueApiCdnServer));

        Ok = wrapper.Error == PkgErrorCode.Ok;
        ErrorCode = (int)wrapper.Error;
        ErrorDescription = Ok ? "" : GetErrorDescription(wrapper.Error);
        MarkingVerify = Ok ? MapCheckCodeMarkAnswer(wrapper.CheckCodeMarkAnswer) : null;
    }

    /// <summary>
    /// Прямая проверка кодов маркировки через ТС ПИоТ — минуя сервер ККМ. Коды берутся из
    /// <see cref="MarkingCodes"/>, адрес/порт — из <see cref="TsPiotAddress"/>/<see cref="TsPiotPort"/>,
    /// идентификация клиента — из <see cref="TsPiotClientName"/>/<see cref="TsPiotClientVersion"/>/
    /// <see cref="TsPiotClientId"/>/<see cref="TsPiotClientToken"/>. Результат — в <see cref="MarkingVerify"/>.
    /// </summary>
    public async Task CheckMarkingTsPiotDirect()
    {
        var clientInfo = new TsPiotClientInfo
        {
            Name = TsPiotClientName,
            Version = TsPiotClientVersion,
            Id = TsPiotClientId,
            Token = TsPiotClientToken
        };

        var answer = await Task.Run(() => new MarkingCodeVerifier().CheckTsPiot(
            MarkingCodes.ToArray(),
            TsPiotAddress,
            TsPiotPort,
            clientInfo,
            TsPiotCheckTimeoutMs > 0 ? TsPiotCheckTimeoutMs : null,
            TsPiotTrustAnyCertificate));

        Ok = answer.Code == 0;
        ErrorCode = answer.Code;
        ErrorDescription = Ok ? "" : answer.Description ?? "";
        MarkingVerify = MapCheckCodeMarkAnswer(answer);
    }

    /// <summary>
    /// Прямая проверка кодов маркировки через локальный модуль «Честный знак» (ЛМ ЧЗ). Коды берутся из <see cref="MarkingCodes"/> (текстовые или Base64 из 1С),
    /// адрес/логин/пароль — из <see cref="LmczAddress"/>/<see cref="LmczPort"/>/<see cref="LmczLogin"/>/
    /// <see cref="LmczPassword"/>. Результат — в <see cref="MarkingVerify"/>; ЛМ ЧЗ возвращает только
    /// текстовые ошибки по кодам (без полного разбора, как у True API/ТС ПИоТ), поэтому
    /// <see cref="MarkingVerifyResult.Codes"/> остаётся пустым.
    /// </summary>
    public async Task CheckMarkingLocalDirect()
    {
        var codes = MarkingCodes.ToArray();
        var (isGood, errors) = await Task.Run(() =>
        {
            var good = new MarkingCodeVerifier().CheckLocal(codes, LmczAddress, LmczPort, LmczLogin, LmczPassword, out var err);
            return (good, err);
        });

        Ok = isGood;
        ErrorCode = isGood ? 0 : -1;
        ErrorDescription = isGood ? "" : string.Join("; ", errors ?? []);
        MarkingVerify = new MarkingVerifyResult
        {
            Code = ErrorCode,
            Description = ErrorDescription
        };
    }

    private static string GetErrorDescription(PkgErrorCode error)
    {
        var member = typeof(PkgErrorCode).GetMember(error.ToString());
        var attrs = member.Length > 0 ? member[0].GetCustomAttributes(typeof(DescriptionAttribute), false) : [];
        return attrs.Length > 0 ? ((DescriptionAttribute)attrs[0]).Description : error.ToString();
    }

    private static MarkingVerifyResult MapCheckCodeMarkAnswer(PkgCheckCodeMarkAnswer? answer)
    {
        var result = new MarkingVerifyResult
        {
            Code = answer?.Code ?? 0,
            Description = answer?.Description ?? "",
            ReqId = answer?.ReqId.ToString() ?? "",
            ReqTimestamp = answer?.ReqTimestamp ?? 0,
            IsCheckedOffline = answer?.IsCheckedOffline ?? false
        };

        if (answer?.Codes != null)
            result.Codes = answer.Codes.Select(MapCodeMarkInfo).ToList();

        return result;
    }

    private static CodeMarkInfo MapCodeMarkInfo(PkgCodeMarkInfo c) => new()
    {
        Cis = c.Cis ?? "",
        Valid = c.Valid,
        PrintView = c.PrintView ?? "",
        GroupIds = c.GroupIds ?? [],
        Verified = c.Verified,
        Realizable = c.Realizable,
        Utilised = c.Utilised,
        Found = c.Found,
        ErrorCode = c.ErrorCode ?? 0,
        Message = c.Message ?? "",
        IsTracking = c.IsTracking,
        Sold = c.Sold,
        Gtin = c.Gtin ?? "",
        PackageType = c.PackageType ?? "",
        ProducerInn = c.ProducerInn ?? "",
        GrayZone = c.GrayZone,
        IsBlocked = c.IsBlocked,
        IsGreyGtin = c.IsGreyGtin,
        Ogvs = c.Ogvs ?? [],
        PackageQuantity = c.PackageQuantity
    };
}
