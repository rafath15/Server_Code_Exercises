using Retalix.Wholefoods.Contracts.Generated.WfmEmployeeManagement;
using System.Collections.Generic;

namespace Retalix.WholeFoods.WfmEmployeeManagement.Model
{
    public interface IWfmEmployeeManagementLookUp
    {
        IList<IWfmEmployeeManagement> GetAllEmployees();
        IList<IWfmEmployeeManagement> FindEmployees(SearchCriteriaType criteria);

    }
}
