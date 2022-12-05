using Retalix.StoreServices.Model.Selling;
using Retalix.StoreServices.Model.Selling.RetailTransaction.RetailTransactionLog;

namespace Retalix.WholeFoods.WfmEmployeeManagement.Model
{
    public interface IWfmEmployeeManagementTLogWriter
    {
        void Write(IRetailTransactionLogDocumentWriter writer, IRetailTransaction retailTransaction);
    }
}
