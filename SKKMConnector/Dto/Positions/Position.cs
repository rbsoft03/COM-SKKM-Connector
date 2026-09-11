using System.Runtime.InteropServices;
namespace RBSoftSkkm;

/// <summary>
/// Базовый тип позиции чека. В <c>kkm.Positions</c> добавляйте конкретные типы:
/// <para>
/// FiscalLine - Фискальная (товар/услуга)
/// </para>
/// <para>
/// TextLine - Текстовая
/// </para>
/// <para>
/// BarcodeLine - Штрихкод
/// </para>
/// <para>
/// PictureLine - Изображение
/// </para>
/// <para>
/// SeparatorLine - Разделительная линия
/// </para>
/// </summary>
[ComVisible(true)]
[Guid("7C3CA37C-F40B-462D-B38A-3C104E495BBD")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public abstract class Position
{
}
