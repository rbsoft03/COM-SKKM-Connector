using System.Runtime.InteropServices;
namespace RBSoftSkkm;

/// <summary>
/// Текстовая строка чека:
/// <para>
/// Text - Текст
/// </para>
/// <para>
/// Font - Шрифт
/// </para>
/// <para>
/// Alignment - Выравнивание
/// </para>
/// </summary>
[ComVisible(true)]
[Guid("22CA9604-8390-4BDE-8F7B-1536D5C0982D")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class TextLine : Position
{
    /// <summary>
    /// Текст строки
    /// </summary>
    public string Text { get; set; } = "";

    /// <summary>
    /// Шрифт
    /// </summary>
    public string? Font { get; set; }

    /// <summary>
    /// Выравнивание
    /// </summary>
    public string? Alignment { get; set; }
}
