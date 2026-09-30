using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace RBSoftSkkm;

/// <summary>
/// Фискальная строка чека (товар / услуга). Основные поля: Name, Quantity, Price, Sum,
/// Tax, SignMethodCalculation, SignCalculationObject; при необходимости Marking, Agent, Vendor.
/// </summary>
[ComVisible(true)]
[Guid("23617125-0629-4D9A-9036-DEC3D9167A8C")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class FiscalLine : Position
{
    /// <summary>
    /// Наименование товара
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Код товара
    /// </summary>
    public string? ProductCode { get; set; }

    /// <summary>
    /// Количество товара
    /// </summary>
    public decimal Quantity { get; set; } = 1;

    /// <summary>
    /// Цена единицы товара с учетом скидок/наценок
    /// </summary>
    [JsonPropertyName("PriceWithDiscount")]
    public decimal Price { get; set; }

    /// <summary>
    /// Конечная сумма по позиции чека с учетом всех скидок/наценок
    /// </summary>
    [JsonPropertyName("SumWithDiscount")]
    public decimal Sum { get; set; }

    /// <summary>
    /// Сумма скидок и наценок
    /// </summary>
    public decimal DiscountSum { get; set; }

    /// <summary>
    /// Ставка НДС. Обязательна: сервер отклоняет позицию без ставки
    /// </summary>
    public string Tax { get; set; } = "";

    /// <summary>
    /// Сумма НДС за предмет расчета
    /// </summary>
    public decimal TaxSum { get; set; }

    /// <summary>
    /// Отдел, по которому ведется продажа
    /// </summary>
    public int Department { get; set; }

    /// <summary>
    /// Признак способа расчёта. Используйте enum <see cref="SignMethodCalculation"/>.
    /// </summary>
    public SignMethodCalculation? SignMethodCalculation { get; set; }

    /// <summary>
    /// Признак предмета расчёта. Используйте enum <see cref="SignCalculationObject"/>.
    /// </summary>
    public SignCalculationObject? SignCalculationObject { get; set; }

    /// <summary>
    /// Единица измерения предмета расчета
    /// </summary>
    public string? MeasurementUnit { get; set; }

    /// <summary>
    /// Мера количества предмета расчёта. Используйте enum <see cref="MeasureOfQuantity"/>.
    /// </summary>
    public MeasureOfQuantity? MeasureOfQuantity { get; set; }

    /// <summary>
    /// Сумма акциза с учетом копеек
    /// </summary>
    public decimal? ExciseAmount { get; set; }

    /// <summary>
    /// Цифровой код страны происхождения товара
    /// </summary>
    public string? CountryOfOrigin { get; set; }

    /// <summary>
    /// Регистрационный номер таможенной декларации
    /// </summary>
    public string? CustomsDeclaration { get; set; }

    /// <summary>
    /// Признак агента по предмету расчёта. Используйте enum <see cref="AgentType"/>.
    /// </summary>
    [JsonPropertyName("SignSubjectCalculationAgent")]
    public AgentType? AgentSign { get; set; }

    /// <summary>
    /// Данные агента. Создайте объект <see cref="Agent"/> и заполните нужные поля.
    /// </summary>
    [JsonPropertyName("AgentData")]
    public Agent? Agent { get; set; }

    /// <summary>
    /// Данные поставщика. Создайте объект <see cref="Vendor"/>
    /// (Name, Phones, Vatin).
    /// </summary>
    public Vendor? Vendor { get; set; }

    /// <summary>
    /// Данные кода товарной номенклатуры. Создайте объект <see cref="Marking"/>.
    /// </summary>
    [JsonPropertyName("GoodCodeData")]
    public Marking? Marking { get; set; }

    /// <summary>
    /// Код контрольной марки
    /// </summary>
    public string? MarkingCode { get; set; }

    /// <summary>
    /// Описание частичного выбытия. Создайте объект <see cref="FractionalQuantity"/>
    /// (Numerator, Denominator).
    /// </summary>
    [JsonPropertyName("FractionalQuantity")]
    public FractionalQuantity? Fractional { get; set; }

    /// <summary>
    /// Отраслевой реквизит. Создайте объект <see cref="Industry"/>
    /// (IdentifierFoiv, DocumentDate, DocumentNumber, AttributeValue).
    /// </summary>
    [JsonPropertyName("IndustryAttribute")]
    public Industry? Industry { get; set; }

    /// <summary>
    /// Дополнительный реквизит предмета расчета
    /// </summary>
    public string? AdditionalAttribute { get; set; }

    // ------------------------------------------------------------------
    // Обёртки для COM-клиентов (1С v7.7 и т.п.): классический COM (позднее
    // связывание, IDispatch) не умеет присваивать значения nullable-enum
    // свойствам (SignMethodCalculation?, SignCalculationObject?,
    // MeasureOfQuantity?, AgentSign?) напрямую — присваивание падает с
    // "Неизвестная ошибка" уже внутри .NET COM interop. Эти методы принимают
    // обычный int и сами делают приведение к нужному enum.
    // ------------------------------------------------------------------

    /// <summary>Устанавливает признак способа расчёта (см. enum SignMethodCalculation) — обёртка для COM.</summary>
    public void SetSignMethodCalculation(int value) => SignMethodCalculation = (SignMethodCalculation)value;

    /// <summary>Устанавливает признак предмета расчёта (см. enum SignCalculationObject) — обёртка для COM.</summary>
    public void SetSignCalculationObject(int value) => SignCalculationObject = (SignCalculationObject)value;

    /// <summary>Устанавливает меру количества предмета расчёта (см. enum MeasureOfQuantity) — обёртка для COM.</summary>
    public void SetMeasureOfQuantity(int value) => MeasureOfQuantity = (MeasureOfQuantity)value;

    /// <summary>Устанавливает признак агента по предмету расчёта (см. enum AgentType) — обёртка для COM.</summary>
    public void SetAgentSign(int value) => AgentSign = (AgentType)value;

    /// <summary>Устанавливает сумму акциза (см. ExciseAmount) — обёртка для COM: свойство объявлено как nullable decimal (decimal?) и не присваивается напрямую из классического COM (IDispatch).</summary>
    public void SetExciseAmount(decimal value) => ExciseAmount = value;
}