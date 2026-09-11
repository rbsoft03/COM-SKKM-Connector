using System.Runtime.InteropServices;
namespace RBSoftSkkm;

/// <summary>
/// Результат проверки кода маркировки.
/// </summary>
[ComVisible(true)]
[Guid("C162D671-07EE-4553-889E-B3DB0C436372")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class MarkingVerifyResult
{
    /// <summary>
    /// Код результата проверки.
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// Описание результата проверки.
    /// </summary>
    public string Description { get; set; } = "";

    /// <summary>
    /// Данные проверки кодов маркировки.
    /// </summary>
    public List<CodeMarkInfo> Codes { get; set; } = [];

    /// <summary>Количество проверенных кодов — удобно для COM-клиентов вместо .Count на List&lt;T&gt;.</summary>
    public int CodeCount => Codes.Count;

    /// <summary>Возвращает результат проверки конкретного кода по индексу (0-based).</summary>
    public CodeMarkInfo GetCodeAt(int index) => Codes[index];

    /// <summary>
    /// Идентификатор операции проверки.
    /// </summary>
    public string ReqId { get; set; } = "";

    /// <summary>
    /// Временная метка операции проверки.
    /// </summary>
    public long ReqTimestamp { get; set; }

    /// <summary>
    /// Признак офлайн-проверки.
    /// </summary>
    public bool IsCheckedOffline { get; set; }
}
