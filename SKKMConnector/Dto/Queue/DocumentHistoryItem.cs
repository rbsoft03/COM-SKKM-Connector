using System.Runtime.InteropServices;
namespace RBSoftSkkm;

/// <summary>
/// Запись истории обработки документа в очереди.
/// </summary>
[ComVisible(true)]
[Guid("8351B8C5-5C67-46F6-BA0C-C8A616EC035B")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class DocumentHistoryItem
{
    /// <summary>
    /// Время события.
    /// </summary>
    public DateTime Time { get; set; }

    /// <summary>
    /// Код состояния.
    /// </summary>
    public int State { get; set; }

    /// <summary>
    /// Описание события.
    /// </summary>
    public string Description { get; set; } = "";

    /// <summary>
    /// Дополнительная информация о событии.
    /// </summary>
    public string Info { get; set; } = "";
}
