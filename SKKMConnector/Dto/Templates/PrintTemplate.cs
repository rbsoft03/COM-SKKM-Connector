using System.Runtime.InteropServices;
namespace RBSoftSkkm;

/// <summary>
/// Шаблон печати, полученный с сервера.
/// </summary>
[ComVisible(true)]
[Guid("5857677E-AE7A-4E13-B335-5660EE81CB7C")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class PrintTemplate
{
    /// <summary>
    /// Имя шаблона. Уникальный идентификатор на сервере.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Тип шаблона.
    /// </summary>
    public PrintTemplateType Type { get; set; }

    /// <summary>
    /// Строки шаблона (текст, штрихкод, картинка, разделитель).
    /// </summary>
    public List<TemplateItem> TemplateItems { get; set; } = [];

    /// <summary>Количество строк в шаблоне — удобно для COM-клиентов вместо .Count на List&lt;T&gt;.</summary>
    public int TemplateItemCount => TemplateItems.Count;

    /// <summary>Возвращает строку шаблона по индексу (0-based).</summary>
    public TemplateItem GetTemplateItemAt(int index) => TemplateItems[index];

    /// <summary>Возвращает саму печатную строку (PrintLine) по индексу — то, что чаще всего нужно.</summary>
    public PrintLine? GetPrintLineAt(int index) => TemplateItems[index].PrintLine;
}
