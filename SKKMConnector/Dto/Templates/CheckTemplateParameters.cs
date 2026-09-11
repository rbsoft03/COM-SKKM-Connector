using System.Runtime.InteropServices;
namespace RBSoftSkkm;

/// <summary>
/// Параметры создания или изменения шаблона чека:
/// <para>
/// Name - Уникальное имя шаблона на сервере
/// </para>
/// <para>
/// Document - Документ шаблона (<see cref="CheckTemplateDocument"/>)
/// </para>
/// </summary>
[ComVisible(true)]
[Guid("26511D77-7636-4987-9632-33C389A0BF55")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class CheckTemplateParameters
{
    /// <summary>
    /// Имя шаблона чека. Уникальный идентификатор на сервере.
    /// Разрешены символы a-z, A-Z, 0-9, _, -, (, ). Пробелы запрещены.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Документ шаблона
    /// </summary>
    public CheckTemplateDocument? Document { get; set; }
}
