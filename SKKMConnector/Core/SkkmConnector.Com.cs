using System.Runtime.InteropServices;

namespace RBSoftSkkm;

/// <summary>
/// COM-обёртка над <see cref="SkkmConnector"/>: те же свойства и методы, что и в обычном
/// коннекторе (имена в SkkmConnector.Api.cs не меняются — полностью совпадают с обычным
/// .NET-коннектором). Классический COM (VBA, 1С, VBScript и т.п.) не умеет работать с
/// Task/async напрямую, поэтому здесь добавлены синхронные версии — с приставкой Run
/// (например, RunPrintCheck() для PrintCheck()), чтобы не совпадать по имени с
/// исходным async-методом (Task Foo() и void Foo() в одном классе не уживаются).
/// </summary>
[ComVisible(true)]
[Guid("8F2E1A3B-6C4D-4A9E-9B2F-1D3E5A7C9F01")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ProgId("RBSoftSkkm.SkkmConnector")]
public sealed partial class SkkmConnector
{
    /// <summary>
    /// RegAsm по умолчанию регистрирует .NET-классы с ThreadingModel=Both.
    /// 1С 7.7 в СоздатьОбъект отказывается создавать объект для любого ThreadingModel,
    /// кроме Apartment (не доходит даже до загрузки mscoree.dll) — правим значение
    /// сразу после стандартной регистрации, чтобы это не требовало ручной правки реестра.
    /// </summary>
    [ComRegisterFunction]
    private static void ComRegister(Type t)
    {
        using var key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(
            $@"CLSID\{t.GUID:B}\InprocServer32", writable: true);
        key?.SetValue("ThreadingModel", "Apartment");
    }

    /// <summary>Синхронная COM-версия <see cref="Ping"/>.</summary>
    public void RunPing() => Ping().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetDeviceList"/>.</summary>
    public void RunGetDeviceList() => GetDeviceList().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="Connect"/>.</summary>
    public void RunConnect() => Connect().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetStatus"/>.</summary>
    public void RunGetStatus() => GetStatus().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetShiftStatus"/>.</summary>
    public void RunGetShiftStatus() => GetShiftStatus().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="OpenShift"/>.</summary>
    public void RunOpenShift() => OpenShift().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="CloseShift"/>.</summary>
    public void RunCloseShift() => CloseShift().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="ReportX"/>.</summary>
    public void RunReportX() => ReportX().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="ReportSettlement"/>.</summary>
    public void RunReportSettlement() => ReportSettlement().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetReportX"/>.</summary>
    public void RunGetReportX() => GetReportX().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetReportZ"/>.</summary>
    public void RunGetReportZ() => GetReportZ().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetOpenShift"/>.</summary>
    public void RunGetOpenShift() => GetOpenShift().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetReportSettlement"/>.</summary>
    public void RunGetReportSettlement() => GetReportSettlement().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetOverAll"/>.</summary>
    public void RunGetOverAll() => GetOverAll().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetLineLength"/>.</summary>
    public void RunGetLineLength() => GetLineLength().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetTotals"/>.</summary>
    public void RunGetTotals() => GetTotals().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetShiftList"/>.</summary>
    public void RunGetShiftList() => GetShiftList().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetOpenShiftList"/>.</summary>
    public void RunGetOpenShiftList() => GetOpenShiftList().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetReportXList"/>.</summary>
    public void RunGetReportXList() => GetReportXList().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetReportSettlementList"/>.</summary>
    public void RunGetReportSettlementList() => GetReportSettlementList().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="PrintCheck"/>.</summary>
    public void RunPrintCheck() => PrintCheck().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="PrintCheckAsync"/>.</summary>
    public void RunPrintCheckAsync() => PrintCheckAsync().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="PrintCheckCorrection120"/>.</summary>
    public void RunPrintCheckCorrection120() => PrintCheckCorrection120().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="PrintCheckCorrection120Async"/>.</summary>
    public void RunPrintCheckCorrection120Async() => PrintCheckCorrection120Async().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="PrintCheckCorrection105"/>.</summary>
    public void RunPrintCheckCorrection105() => PrintCheckCorrection105().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="PrintCheckCorrection105Async"/>.</summary>
    public void RunPrintCheckCorrection105Async() => PrintCheckCorrection105Async().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetCorrection120"/>.</summary>
    public void RunGetCorrection120() => GetCorrection120().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetCorrection120List"/>.</summary>
    public void RunGetCorrection120List() => GetCorrection120List().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetCorrection105"/>.</summary>
    public void RunGetCorrection105() => GetCorrection105().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetCorrection105List"/>.</summary>
    public void RunGetCorrection105List() => GetCorrection105List().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetChecksByShift"/>.</summary>
    public void RunGetChecksByShift() => GetChecksByShift().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetTaskStatus"/>.</summary>
    public void RunGetTaskStatus() => GetTaskStatus().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetCheck"/>.</summary>
    public void RunGetCheck() => GetCheck().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetFiscalSign"/>.</summary>
    public void RunGetFiscalSign() => GetFiscalSign().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="PrintCheckCopy"/>.</summary>
    public void RunPrintCheckCopy() => PrintCheckCopy().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetPrintForm"/>.</summary>
    public void RunGetPrintForm() => GetPrintForm().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="CashIn"/>.</summary>
    public void RunCashIn() => CashIn().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="CashOut"/>.</summary>
    public void RunCashOut() => CashOut().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="OpenCashdrawer"/>.</summary>
    public void RunOpenCashdrawer() => OpenCashdrawer().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetCash"/>.</summary>
    public void RunGetCash() => GetCash().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetCashIn"/>.</summary>
    public void RunGetCashIn() => GetCashIn().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetCashInList"/>.</summary>
    public void RunGetCashInList() => GetCashInList().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetCashOut"/>.</summary>
    public void RunGetCashOut() => GetCashOut().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="SendPicture"/>.</summary>
    public void RunSendPicture() => SendPicture().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetPictureList"/>.</summary>
    public void RunGetPictureList() => GetPictureList().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="OpenSessionRegistrationKM"/>.</summary>
    public void RunOpenSessionRegistrationKM() => OpenSessionRegistrationKM().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="CloseSessionRegistrationKM"/>.</summary>
    public void RunCloseSessionRegistrationKM() => CloseSessionRegistrationKM().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="RequestKM"/>.</summary>
    public void RunRequestKM() => RequestKM().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetProcessingKMResult"/>.</summary>
    public void RunGetProcessingKMResult() => GetProcessingKMResult().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="ConfirmKM"/>.</summary>
    public void RunConfirmKM() => ConfirmKM().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="PrintSlip"/>.</summary>
    public void RunPrintSlip() => PrintSlip().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="PrintSlipAsync"/>.</summary>
    public void RunPrintSlipAsync() => PrintSlipAsync().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetVersion"/>.</summary>
    public void RunGetVersion() => GetVersion().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetUserToken"/>.</summary>
    public void RunGetUserToken() => GetUserToken().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetUserList"/>.</summary>
    public void RunGetUserList() => GetUserList().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="AddUser"/>.</summary>
    public void RunAddUser() => AddUser().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="UpdateUser"/>.</summary>
    public void RunUpdateUser() => UpdateUser().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="DeleteUser"/>.</summary>
    public void RunDeleteUser() => DeleteUser().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetServiceSettings"/>.</summary>
    public void RunGetServiceSettings() => GetServiceSettings().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="SaveServiceSettings"/>.</summary>
    public void RunSaveServiceSettings() => SaveServiceSettings().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="AddDevice"/>.</summary>
    public void RunAddDevice() => AddDevice().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="UpdateDevice"/>.</summary>
    public void RunUpdateDevice() => UpdateDevice().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="DeleteDevice"/>.</summary>
    public void RunDeleteDevice() => DeleteDevice().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="RebootDevice"/>.</summary>
    public void RunRebootDevice() => RebootDevice().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="SetDeviceFont"/>.</summary>
    public void RunSetDeviceFont() => SetDeviceFont().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetPoolList"/>.</summary>
    public void RunGetPoolList() => GetPoolList().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetDeviceListByPool"/>.</summary>
    public void RunGetDeviceListByPool() => GetDeviceListByPool().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="OpenShiftAsync"/>.</summary>
    public void RunOpenShiftAsync() => OpenShiftAsync().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="CloseShiftAsync"/>.</summary>
    public void RunCloseShiftAsync() => CloseShiftAsync().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="ReportXAsync"/>.</summary>
    public void RunReportXAsync() => ReportXAsync().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="ReportSettlementAsync"/>.</summary>
    public void RunReportSettlementAsync() => ReportSettlementAsync().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="CashInAsync"/>.</summary>
    public void RunCashInAsync() => CashInAsync().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="CashOutAsync"/>.</summary>
    public void RunCashOutAsync() => CashOutAsync().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetCheckList"/>.</summary>
    public void RunGetCheckList() => GetCheckList().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="PrintCheckCopyFn"/>.</summary>
    public void RunPrintCheckCopyFn() => PrintCheckCopyFn().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetSlip"/>.</summary>
    public void RunGetSlip() => GetSlip().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetSlipList"/>.</summary>
    public void RunGetSlipList() => GetSlipList().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetPicture"/>.</summary>
    public void RunGetPicture() => GetPicture().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="DeletePicture"/>.</summary>
    public void RunDeletePicture() => DeletePicture().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="AddTemplate"/>.</summary>
    public void RunAddTemplate() => AddTemplate().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="UpdateTemplate"/>.</summary>
    public void RunUpdateTemplate() => UpdateTemplate().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="DeleteTemplate"/>.</summary>
    public void RunDeleteTemplate() => DeleteTemplate().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetTemplateList"/>.</summary>
    public void RunGetTemplateList() => GetTemplateList().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetTemplate"/>.</summary>
    public void RunGetTemplate() => GetTemplate().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="AddCheckTemplate"/>.</summary>
    public void RunAddCheckTemplate() => AddCheckTemplate().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="UpdateCheckTemplate"/>.</summary>
    public void RunUpdateCheckTemplate() => UpdateCheckTemplate().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="DeleteCheckTemplate"/>.</summary>
    public void RunDeleteCheckTemplate() => DeleteCheckTemplate().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetCheckTemplateList"/>.</summary>
    public void RunGetCheckTemplateList() => GetCheckTemplateList().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetCheckTemplate"/>.</summary>
    public void RunGetCheckTemplate() => GetCheckTemplate().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetQueue"/>.</summary>
    public void RunGetQueue() => GetQueue().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetQueueTask"/>.</summary>
    public void RunGetQueueTask() => GetQueueTask().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetQueueTaskHistory"/>.</summary>
    public void RunGetQueueTaskHistory() => GetQueueTaskHistory().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="CancelQueueTask"/>.</summary>
    public void RunCancelQueueTask() => CancelQueueTask().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="VerifyMarking"/>.</summary>
    public void RunVerifyMarking() => VerifyMarking().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="VerifyMarkingTsPiot"/>.</summary>
    public void RunVerifyMarkingTsPiot() => VerifyMarkingTsPiot().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="VerifyMarkingLmcz"/>.</summary>
    public void RunVerifyMarkingLmcz() => VerifyMarkingLmcz().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="RepairMarking"/>.</summary>
    public void RunRepairMarking() => RepairMarking().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="Fiscalization"/>.</summary>
    public void RunFiscalization() => Fiscalization().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="FiscalizationAsync"/>.</summary>
    public void RunFiscalizationAsync() => FiscalizationAsync().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetFiscalization"/>.</summary>
    public void RunGetFiscalization() => GetFiscalization().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetFiscalizationList"/>.</summary>
    public void RunGetFiscalizationList() => GetFiscalizationList().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetOperationLast"/>.</summary>
    public void RunGetOperationLast() => GetOperationLast().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetOperation"/>.</summary>
    public void RunGetOperation() => GetOperation().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetOperationHistory"/>.</summary>
    public void RunGetOperationHistory() => GetOperationHistory().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetOperationTlv"/>.</summary>
    public void RunGetOperationTlv() => GetOperationTlv().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetOperationKm"/>.</summary>
    public void RunGetOperationKm() => GetOperationKm().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetOperationRelated"/>.</summary>
    public void RunGetOperationRelated() => GetOperationRelated().GetAwaiter().GetResult();

    /// <summary>Синхронная COM-версия <see cref="GetOperationList"/>.</summary>
    public void RunGetOperationList() => GetOperationList().GetAwaiter().GetResult();

    /// <summary>
    /// Добавляет фискальную строку в чек — удобный способ для COM-клиентов (VBA/1С),
    /// которым неудобно создавать List&lt;Position&gt; и объект FiscalLine напрямую.
    /// Необязательные параметры можно не указывать (значения по умолчанию — как в самом FiscalLine).
    /// </summary>
    public void AddFiscalLine(
        string name,
        decimal quantity,
        decimal price,
        decimal sum,
        string tax,
        decimal taxSum = 0,
        int department = 0,
        string? productCode = null)
    {
        var line = new FiscalLine
        {
            Name = name,
            Quantity = quantity,
            Price = price,
            Sum = sum,
            Tax = tax,
            TaxSum = taxSum,
            Department = department,
            ProductCode = productCode,
        };
        Positions.Add(line);
    }

    /// <summary>Очищает список позиций чека (аналог Positions.Clear() — для COM-клиентов, у которых нет прямого доступа к .Clear() на List&lt;T&gt;).</summary>
    public void ClearPositions() => Positions.Clear();

    /// <summary>Устанавливает наличную оплату — удобный метод вместо создания Payments вручную.</summary>
    public void SetCashPayment(decimal amount) => Payments = new Payments { Cash = amount };

    /// <summary>Устанавливает безналичную оплату.</summary>
    public void SetElectronicPayment(decimal amount) => Payments = new Payments { ElectronicPayment = amount };

    /// <summary>Устанавливает данные кассира — удобный метод вместо создания Cashier вручную.</summary>
    public void SetCashier(string name, string vatin) => Cashier = new Cashier { Name = name, Vatin = vatin };

    /// <summary>Добавляет код маркировки в список для проверки (<see cref="MarkingCodes"/>) — удобный способ для COM-клиентов.</summary>
    public void AddMarkingCode(string code) => MarkingCodes.Add(code);

    /// <summary>Очищает список кодов маркировки для проверки (аналог MarkingCodes.Clear()).</summary>
    public void ClearMarkingCodes() => MarkingCodes.Clear();
}