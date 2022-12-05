using Retalix.Wholefoods.Contracts.Generated.WfmEmployeeManagement;
using Retalix.WholeFoods.WfmEmployeeManagement.Model;
using System.Collections.Generic;

namespace Retalix.WholeFoods.WfmEmployeeManagement.BusinessComponents
{
    public class WfmEmployeeManagementLookUp : IWfmEmployeeManagementLookUp
    {
        private readonly IWfmEmployeeManagementDao _employeeManagementDao;
        public WfmEmployeeManagementLookUp(IWfmEmployeeManagementDao iEmployeeManagementDao)
        {
            _employeeManagementDao = iEmployeeManagementDao;
        }
        public IList<IWfmEmployeeManagement> GetAllEmployees()
        {
            return _employeeManagementDao.GetAllEmployees();
        }
        public IList<IWfmEmployeeManagement> FindEmployees(SearchCriteriaType criteria)
        {
            return _employeeManagementDao.FindEmployees(criteria);
        }
    }
}