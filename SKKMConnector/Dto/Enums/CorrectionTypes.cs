using System.Runtime.InteropServices;
namespace RBSoftSkkm
{
    /// <summary>
    /// Тип коррекции:
    /// <para>
    /// Самостоятельно - Самостоятельно
    /// </para>
    /// <para>
    /// ПоПредписанию - По предписанию налогового органа
    /// </para>
    /// </summary>
    [ComVisible(true)]
    public enum CorrectionTypes
    {
        /// <summary>
        /// Самостоятельно
        /// </summary>
        Самостоятельно = 0,

        /// <summary>
        /// По предписанию налогового органа. Рекомендуется заполнять номер предписания.
        /// </summary>
        ПоПредписанию = 1,
    }
}
