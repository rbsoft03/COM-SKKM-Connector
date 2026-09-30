using System.Runtime.InteropServices;
namespace RBSoftSkkm;

/// <summary>
/// Операционный реквизит чека:
/// <para>
/// DateTime - Дата и время операции
/// </para>
/// <para>
/// OperationId - Идентификатор операции
/// </para>
/// <para>
/// OperationData - Данные операции
/// </para>
/// </summary>
[ComVisible(true)]
[Guid("B87189BD-979C-4A79-8F59-0C60062259FF")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class OperationalAttribute
{
    /// <summary>
    /// Дата, время операции.
    /// </summary>
    public string? DateTime { get; set; }

    /// <summary>
    /// Идентификатор операции.
    /// </summary>
    public int? OperationId { get; set; }

    /// <summary>
    /// Данные операции.
    /// </summary>
    public string? OperationData { get; set; }

    /// <summary>Устанавливает идентификатор операции (см. OperationId) — обёртка для COM: свойство объявлено как nullable int (int?) и не присваивается напрямую из классического COM (IDispatch).</summary>
    public void SetOperationId(int value) => OperationId = value;
}
