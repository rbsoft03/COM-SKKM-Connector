using System.Runtime.InteropServices;
namespace RBSoftSkkm;

/// <summary>
/// Сведения о покупателе (клиенте):
/// <para>
/// Info - Наименование организации или ФИО
/// </para>
/// <para>
/// Vatin - ИНН покупателя
/// </para>
/// <para>
/// Email - Электронная почта
/// </para>
/// <para>
/// Phone - Телефон
/// </para>
/// <para>
/// DateOfBirth - Дата рождения
/// </para>
/// <para>
/// Citizenship - Код страны гражданства
/// </para>
/// <para>
/// DocumentTypeCode - Код вида документа (таблица 116 ФФД)
/// </para>
/// <para>
/// DocumentData - Данные документа, удостоверяющего личность
/// </para>
/// <para>
/// Address - Адрес покупателя
/// </para>
/// Заполните только нужные поля.
/// </summary>
[ComVisible(true)]
[Guid("DEEE9113-7652-4862-98F3-B1CDFCF6C6FE")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class Customer
{
    /// <summary>
    /// Наименование организации или фамилия, имя, отчество (при наличии).
    /// </summary>
    public string? Info { get; set; }

    /// <summary>
    /// ИНН покупателя.
    /// </summary>
    public string? Vatin { get; set; }

    /// <summary>
    /// Электронная почта покупателя.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Номер телефона.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Дата рождения покупателя (клиента).
    /// </summary>
    public string? DateOfBirth { get; set; }

    /// <summary>
    /// Числовой код страны.
    /// </summary>
    public string? Citizenship { get; set; }

    /// <summary>
    /// Числовой код вида документа, удостоверяющего личность (таблица 116).
    /// </summary>
    public string? DocumentTypeCode { get; set; }

    /// <summary>
    /// Данные документа, удостоверяющего личность.
    /// </summary>
    public string? DocumentData { get; set; }

    /// <summary>
    /// Адрес покупателя.
    /// </summary>
    public string? Address { get; set; }
}
