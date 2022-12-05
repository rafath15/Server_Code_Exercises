using Retalix.WholeFoods.WfmEmployeeManagement.Model;

namespace Retalix.WholeFoods.WfmEmployeeManagement.BusinessComponents
{
    public class WfmEmployeeManagementMaintenance : IWfmEmployeeManagementMaintenance
    {
        private readonly IWfmEmployeeManagementDao _iEmployeeManagementDao;

        public WfmEmployeeManagementMaintenance(IWfmEmployeeManagementDao iEmployeeManagementDao)
        {
            _iEmployeeManagementDao = iEmployeeManagementDao;
        }

        public void Add(WfmEmployeeManagementType employees)
        {
            _iEmployeeManagementDao.Add(employees);
        }

        public void Update(WfmEmployeeManagementType employees)
        {
            _iEmployeeManagementDao.Update(employees);
        }
        public void Delete(WfmEmployeeManagementType employees)
        {
            _iEmployeeManagementDao.Delete(employees);
        }
    }
}