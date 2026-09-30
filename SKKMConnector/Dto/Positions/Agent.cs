using System.Runtime.InteropServices;
namespace RBSoftSkkm;

/// <summary>
/// Данные агента в чеке:
/// <para>
/// PayingAgentOperation - Операция платёжного агента
/// </para>
/// <para>
/// PayingAgentPhone - Телефон(ы) платёжного агента
/// </para>
/// <para>
/// ReceivePaymentsOperatorPhone - Телефон(ы) оператора по приёму платежей
/// </para>
/// <para>
/// MoneyTransferOperatorPhone - Телефон(ы) оператора перевода
/// </para>
/// <para>
/// MoneyTransferOperatorName - Наименование оператора перевода
/// </para>
/// <para>
/// MoneyTransferOperatorAddress - Адрес оператора перевода
/// </para>
/// <para>
/// MoneyTransferOperatorVatin - ИНН оператора перевода
/// </para>
/// </summary>
[ComVisible(true)]
[Guid("82E72A9E-9E87-476C-B95E-6D1FAEF30DF2")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class Agent
{
    /// <summary>
    /// Операция платёжного агента.
    /// </summary>
    public string? PayingAgentOperation { get; set; }

    /// <summary>
    /// Телефон платёжного агента.
    /// </summary>
    public string[]? PayingAgentPhone { get; set; }

    /// <summary>
    /// Телефон оператора по приёму платежей.
    /// </summary>
    public string[]? ReceivePaymentsOperatorPhone { get; set; }

    /// <summary>
    /// Телефон оператора перевода.
    /// </summary>
    public string[]? MoneyTransferOperatorPhone { get; set; }

    /// <summary>
    /// Наименование оператора перевода.
    /// </summary>
    public string? MoneyTransferOperatorName { get; set; }

    /// <summary>
    /// Адрес оператора перевода.
    /// </summary>
    public string? MoneyTransferOperatorAddress { get; set; }

    /// <summary>
    /// ИНН оператора перевода.
    /// </summary>
    public string? MoneyTransferOperatorVatin { get; set; }

    // ------------------------------------------------------------------
    // Add-методы для COM-клиентов (1С/VBA): свойства-массивы (string[]?)
    // нельзя удобно заполнить из COM без промежуточного SAFEARRAY — эти
    // методы добавляют один телефон за раз и сами пересобирают массив.
    // ------------------------------------------------------------------

    /// <summary>Добавляет телефон платёжного агента (можно вызвать несколько раз для нескольких номеров).</summary>
    public void AddPayingAgentPhone(string phone) => PayingAgentPhone = AppendPhone(PayingAgentPhone, phone);

    /// <summary>Добавляет телефон оператора по приёму платежей.</summary>
    public void AddReceivePaymentsOperatorPhone(string phone) => ReceivePaymentsOperatorPhone = AppendPhone(ReceivePaymentsOperatorPhone, phone);

    /// <summary>Добавляет телефон оператора перевода.</summary>
    public void AddMoneyTransferOperatorPhone(string phone) => MoneyTransferOperatorPhone = AppendPhone(MoneyTransferOperatorPhone, phone);

    private static string[] AppendPhone(string[]? current, string phone)
    {
        var old = current ?? Array.Empty<string>();
        var next = new string[old.Length + 1];
        old.CopyTo(next, 0);
        next[old.Length] = phone;
        return next;
    }
}
