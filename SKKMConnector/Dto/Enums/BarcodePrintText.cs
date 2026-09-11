using System.Runtime.InteropServices;
namespace RBSoftSkkm;

/// <summary>
/// Способ печати текста штрихкода (для одномерных):
/// <para>
/// None - Не печатать
/// </para>
/// <para>
/// Below - Снизу
/// </para>
/// <para>
/// Above - Сверху
/// </para>
/// <para>
/// AboveAndBelow - Сверху и снизу
/// </para>
/// </summary>
[ComVisible(true)]
public enum BarcodePrintText
{
    /// <summary>
    /// Не печатать.
    /// </summary>
    None = 0,

    /// <summary>
    /// Печатать снизу.
    /// </summary>
    Below = 1,

    /// <summary>
    /// Печатать сверху.
    /// </summary>
    Above = 2,

    /// <summary>
    /// Печатать сверху и снизу.
    /// </summary>
    AboveAndBelow = 3,
}
