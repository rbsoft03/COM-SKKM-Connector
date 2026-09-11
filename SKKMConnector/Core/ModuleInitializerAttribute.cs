// Полифилл: атрибут ModuleInitializer отсутствует в BCL net48, но компилятор C#
// распознаёт его по полному имени типа. LangVersion=latest поддерживает механизм
// module initializer, поэтому достаточно объявить сам атрибут.
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    internal sealed class ModuleInitializerAttribute : Attribute
    {
    }
}
