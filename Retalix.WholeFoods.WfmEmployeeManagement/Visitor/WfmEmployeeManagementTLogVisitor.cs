using Common.Logging;
using Retalix.StoreServices.Model.Infrastructure.Audit;
using Retalix.StoreServices.Model.Selling;
using Retalix.StoreServices.Model.Selling.RetailTransaction.RetailTransactionLog;
using Retalix.WholeFoods.WfmEmployeeManagement.Model;

namespace Retalix.WholeFoods.WfmEmployeeManagement.Visitor
{
    public class WfmEmployeeManagementTLogVisitor : IRetailTransactionLogDocumentCreationVisitor
    {
        private readonly IAuditLogDao _auditLogDao;
        private readonly IWfmEmployeeManagementTLogWriter _WfmEmployeeManagementTLogWriter;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(WfmEmployeeManagementTLogVisitor));

        public WfmEmployeeManagementTLogVisitor(IAuditLogDao auditLogDao, IWfmEmployeeManagementTLogWriter wfmEmployeeManagementTLogWriter)
        {
            _auditLogDao = auditLogDao;
            _WfmEmployeeManagementTLogWriter = wfmEmployeeManagementTLogWriter;
        }

        public void Visit(IRetailTransaction retailTransaction, IRetailTransactionLogDocumentWriter retailTransactionLogDocumentWriter)
        {
            Logger.Debug("WfmEmployeeManagementTLogVisitor::Visit");
            _WfmEmployeeManagementTLogWriter.Write(retailTransactionLogDocumentWriter, retailTransaction);
        }
    }
}