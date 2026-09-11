using System.Runtime.InteropServices;
namespace RBSoftSkkm;

/// <summary>
/// Документ шаблона чека: тип чека, СНО, оплаты (<see cref="Payments"/>), позиции,
/// покупатель, агент и прочие реквизиты — по аналогии с обычным чеком.
/// </summary>
[ComVisible(true)]
[Guid("7D9BC574-17D3-4EE7-84BB-16DA3DB28AA3")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class CheckTemplateDocument
{
    /// <summary>
    /// Тип чека 
    /// </summary>
    public CheckType PaymentType { get; set; }

    /// <summary>
    /// Система налогообложения
    /// </summary>
    public TaxSystem TaxVariant { get; set; }

    /// <summary>
    /// Часовая зона.
    /// </summary>
    public CheckTimeZone? TimeZone { get; set; }

    /// <summary>
    /// Признак расчёта в сети Интернет.
    /// </summary>
    public bool OperationOnline { get; set; }

    /// <summary>
    /// Адрес электронной почты отправителя чека.
    /// </summary>
    public string SenderEmail { get; set; } = "";

    /// <summary>
    /// Адрес проведения расчётов.
    /// </summary>
    public string SaleAddress { get; set; } = "";

    /// <summary>
    /// Место проведения расчётов.
    /// </summary>
    public string SaleLocation { get; set; } = "";

    /// <summary>
    /// Формирование чека только в электронном виде.
    /// </summary>
    public bool Electronically { get; set; }

    /// <summary>
    /// Покупатель.
    /// </summary>
    public Customer? Customer { get; set; }

    /// <summary>
    /// Позиции чека
    /// </summary>
    public List<Position> Positions { get; set; } = [];

    /// <summary>
    /// Строки шаблона
    /// </summary>
    public List<CheckItem> CheckItems { get; set; } = [];

    /// <summary>
    /// Оплаты чека.
    /// </summary>
    public Payments? Payments { get; set; }

    /// <summary>
    /// Электронные платежи.
    /// </summary>
    public List<ElectronicPayment> ElectronicPayments { get; set; } = [];

    /// <summary>
    /// Данные коррекции
    /// </summary>
    public CorrectionData? CorrectionData { get; set; }

    /// <summary>
    /// Отраслевой реквизит чека
    /// </summary>
    public Industry? IndustryAttribute { get; set; }

    /// <summary>
    /// Дополнительный реквизит пользователя
    /// </summary>
    public UserAttribute? UserAttribute { get; set; }

    /// <summary>
    /// Операционный реквизит чека
    /// </summary>
    public OperationalAttribute? OperationalAttribute { get; set; }

    /// <summary>
    /// Дополнительный реквизит чека (БСО), тег 1192
    /// </summary>
    public string AdditionalAttribute { get; set; } = "";

    /// <summary>Добавляет фискальную строку в позиции документа-шаблона (аналогично AddFiscalLine у SkkmConnector).</summary>
    public void AddFiscalLine(string name, decimal quantity, decimal price, decimal sum, string tax, decimal taxSum = 0)
    {
        Positions.Add(new FiscalLine
        {
            Name = name,
            Quantity = quantity,
            Price = price,
            Sum = sum,
            Tax = tax,
            TaxSum = taxSum,
        });
    }

    /// <summary>Очищает позиции документа-шаблона.</summary>
    public void ClearPositions() => Positions.Clear();

    /// <summary>Добавляет безналичную оплату.</summary>
    public void AddElectronicPayment(decimal amount) => ElectronicPayments.Add(new ElectronicPayment { Amount = amount });

    /// <summary>Количество сохранённых позиций чека (CheckItems) — для чтения из COM.</summary>
    public int CheckItemCount => CheckItems.Count;

    /// <summary>Возвращает сохранённую позицию чека по индексу.</summary>
    public CheckItem GetCheckItemAt(int index) => CheckItems[index];
}
