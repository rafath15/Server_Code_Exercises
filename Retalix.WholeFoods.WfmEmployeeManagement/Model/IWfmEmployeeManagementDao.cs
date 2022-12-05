using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using Retalix.Wholefoods.Contracts.Generated.WfmEmployeeManagement;
using Retalix.WholeFoods.WfmEmployeeManagement.BusinessComponents;
using System.Collections.Generic;

namespace Retalix.WholeFoods.WfmEmployeeManagement.Model
{
    public interface IWfmEmployeeManagementDao : IMovableDao
    {
        IList<IWfmEmployeeManagement> FindEmployees(SearchCriteriaType criteria);
        IList<IWfmEmployeeManagement> GetAllEmployees();
        void Add(WfmEmployeeManagementType employeeManagement);
        void Update(WfmEmployeeManagementType employeeManagement);
        void Delete(WfmEmployeeManagementType employeeManagement);

    }
}
