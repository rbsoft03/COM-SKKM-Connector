namespace RBSoftSkkm;
public sealed partial class SkkmConnector
{
    // Подключение

    /// <summary>
    /// Хост сервера ККМ (IP или DNS). Можно менять между запросами, пока программа запущена.
    /// </summary>
    public string Host { get; set; } = "localhost";

    /// <summary>
    /// TCP-порт сервера ККМ. Можно менять между запросами, пока программа запущена.
    /// </summary>
    public int Port { get; set; } = 4398;

    /// <summary>
    /// HTTPS вместо HTTP
    /// </summary>
    public bool UseHttps { get; set; }

    /// <summary>
    /// Таймаут запроса к серверу ККМ. По умолчанию 60 секунд.
    /// </summary>
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(60);

    /// <summary>
    /// Токен авторизации (заголовок api_key). Можно менять между запросами, пока программа запущена.
    /// </summary>
    public string Token { get; set; } = "";

    /// <summary>
    /// Идентификатор терминала
    /// </summary>
    public string TerminalId { get; set; } = "";

    /// <summary>
    /// Имя устройства.
    /// </summary>
    public string DeviceName { get; set; } = "";

    /// <summary>
    /// Сведения о кассире (продавце). Создайте объект <see cref="Cashier"/> (Name, Vatin).
    /// </summary>
    public Cashier? Cashier { get; set; }

    /// <summary>
    /// Логин для Basic Auth при получении токена. По умолчанию Admin.
    /// </summary>
    public string AuthUserName { get; set; } = "Admin";

    /// <summary>
    /// Пароль для Basic Auth при получении токена. По умолчанию Admin.
    /// </summary>
    public string AuthPassword { get; set; } = "Admin";

    /// <summary>
    /// Имя пула устройств.
    /// </summary>
    public string PoolName { get; set; } = "";

    /// <summary>
    /// Тип отчёта для списка Z-отчётов.
    /// </summary>
    public int ReportType { get; set; }

    /// <summary>
    /// Идентификатор задания в очереди печати.
    /// </summary>
    public string QueueTaskId { get; set; } = "";

    /// <summary>
    /// Имя картинки или шаблона.
    /// </summary>
    public string PictureId { get; set; } = "";

    /// <summary>
    /// Имя шаблона печати или чека.
    /// </summary>
    public string TemplateName { get; set; } = "";

    /// <summary>
    /// Идентификатор пользователя сервера ККМ.
    /// </summary>
    public string UserId { get; set; } = "";

    /// <summary>
    /// Номер ФН
    /// </summary>
    public string FnNumber { get; set; } = "";

    /// <summary>
    /// Коды маркировки для проверки.
    /// </summary>
    public List<string> MarkingCodes { get; } = [];

    /// <summary>
    /// Настройки кассы для добавления или изменения.
    /// Создайте объект <see cref="DeviceSettings"/> и заполните нужные поля.
    /// </summary>
    public DeviceSettings? DeviceSettings { get; set; }

    /// <summary>
    /// Настройки службы печати. Создайте объект <see cref="ServiceSettings"/>
    /// (WcfServicePort, WebServicePort, ServiceTimeOut, ProxyServerSettings, MaxQueueSize, RepeatPrintingOnError).
    /// </summary>
    public ServiceSettings? ServiceSettings { get; set; }

    /// <summary>
    /// Пользователь сервера ККМ. Создайте объект <see cref="ServiceUser"/>
    /// (Id, UserName, FullName, Vatin, Role, TokenId, Password).
    /// </summary>
    public ServiceUser? ServiceUser { get; set; }

    /// <summary>
    /// Параметры шаблона печати. Создайте объект <see cref="TemplateParameters"/>
    /// (Name, Type, TemplateItems).
    /// </summary>
    public TemplateParameters? TemplateParameters { get; set; }

    /// <summary>
    /// Параметры шаблона чека. Создайте объект <see cref="CheckTemplateParameters"/>
    /// (Name, Document).
    /// </summary>
    public CheckTemplateParameters? CheckTemplateParameters { get; set; }

    /// <summary>
    /// Параметры фискализации / перерегистрации.
    /// Создайте объект <see cref="FiscalizationParameters"/> и заполните нужные поля.
    /// </summary>
    public FiscalizationParameters? FiscalizationParameters { get; set; }

    // Прямая проверка кодов маркировки (RBSoft.MarkingVerification) — без обращения к серверу ККМ

    /// <summary>
    /// Токен авторизации (X-Api-Key) ГИС МТ для <see cref="CheckMarkingTrueApiDirect"/>.
    /// </summary>
    public string MarkingTrueApiToken { get; set; } = "";

    /// <summary>
    /// CDN-сервер ГИС МТ для <see cref="CheckMarkingTrueApiDirect"/>.
    /// </summary>
    public string MarkingTrueApiCdnServer { get; set; } = "https://cdn01.crpt.ru";

    /// <summary>
    /// Адрес ТС ПИоТ (IP или хост, можно с http(s)://) для <see cref="CheckMarkingTsPiotDirect"/>.
    /// </summary>
    public string TsPiotAddress { get; set; } = "";

    /// <summary>
    /// Порт ТС ПИоТ. 0 — использовать порт по умолчанию для схемы.
    /// </summary>
    public int TsPiotPort { get; set; }

    /// <summary>
    /// Имя клиента — обязательная идентификация в каждом запросе к ТС ПИоТ.
    /// </summary>
    public string TsPiotClientName { get; set; } = "";

    /// <summary>
    /// Версия клиента для идентификации в ТС ПИоТ.
    /// </summary>
    public string TsPiotClientVersion { get; set; } = "";

    /// <summary>
    /// Идентификатор клиента для идентификации в ТС ПИоТ.
    /// </summary>
    public string TsPiotClientId { get; set; } = "";

    /// <summary>
    /// Токен клиента для идентификации в ТС ПИоТ.
    /// </summary>
    public string TsPiotClientToken { get; set; } = "";

    /// <summary>
    /// Принимать любой сертификат сервера ТС ПИоТ (по умолчанию true — обычно локальная
    /// сеть с самоподписанным сертификатом).
    /// </summary>
    public bool TsPiotTrustAnyCertificate { get; set; } = true;

    /// <summary>
    /// Таймаут проверки кодов маркировки через ТС ПИоТ, мс. 0 — не задавать.
    /// </summary>
    public long TsPiotCheckTimeoutMs { get; set; }

    /// <summary>
    /// Адрес локального модуля «Честный знак» (ЛМ ЧЗ) для <see cref="CheckMarkingLocalDirect"/>.
    /// </summary>
    public string LmczAddress { get; set; } = "";

    /// <summary>
    /// Порт локального модуля «Честный знак».
    /// </summary>
    public int LmczPort { get; set; }

    /// <summary>
    /// Логин Basic Auth для локального модуля «Честный знак».
    /// </summary>
    public string LmczLogin { get; set; } = "";

    /// <summary>
    /// Пароль Basic Auth для локального модуля «Честный знак».
    /// </summary>
    public string LmczPassword { get; set; } = "";
}
