using System.Runtime.InteropServices;
namespace RBSoftSkkm;

/// <summary>
/// Дробное количество предмета расчёта:
/// <para>
/// Numerator - Числитель
/// </para>
/// <para>
/// Denominator - Знаменатель
/// </para>
/// Используется вместе с мерой количества при частичной реализации маркированного товара.
/// </summary>
[ComVisible(true)]
[Guid("C6C267B0-6063-4C26-BE32-546E409B3196")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class FractionalQuantity
{
    /// <summary>
    /// Числитель.
    /// </summary>
    public int Numerator { get; set; }

    /// <summary>
    /// Знаменатель.
    /// </summary>
    public int Denominator { get; set; }
}
