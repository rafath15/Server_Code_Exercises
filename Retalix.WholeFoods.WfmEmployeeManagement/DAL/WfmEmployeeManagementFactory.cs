using Retalix.WholeFoods.WfmEmployeeManagement.BusinessComponents;
using Retalix.WholeFoods.WfmEmployeeManagement.Model;

namespace Retalix.WholeFoods.WfmEmployeeManagement.DAL
{
    public class WfmEmployeeManagementFactory : IWfmEmployeeManagementFactory
    {
        public BusinessComponents.WfmEmployeeManagementType Create()
        {
            return new WfmEmployeeManagementType();
        }
    }
}