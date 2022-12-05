using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using Retalix.StoreServices.Model.Infrastructure.DataMovement.Versioning;
using Retalix.WholeFoods.WfmEmployeeManagement.Model;

namespace Retalix.WholeFoods.WfmEmployeeManagement.DMS
{
    public class WfmEmployeeManagementServiceResolver : ICompatibilityMovableServicesResolver
    {
        private readonly IWfmEmployeeManagementDao _employeeManagementDao;

        public WfmEmployeeManagementServiceResolver(IWfmEmployeeManagementDao employeeManagementDao)
        {
            _employeeManagementDao = employeeManagementDao;
        }
        public IMovableFormatter Formatter { get { return null; } }

        public IMovableDao MovableDao { get { return _employeeManagementDao; } }

        public IEntityToDtoMapper EntityToDtoMapper { get { return new WfmEmployeeManagementDtoMapper(); } }

        public string ComponentName { get { return "WfmRetail"; } }
    }
}
