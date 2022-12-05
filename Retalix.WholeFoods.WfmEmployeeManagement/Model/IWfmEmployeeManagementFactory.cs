using Retalix.WholeFoods.WfmEmployeeManagement.BusinessComponents;

namespace Retalix.WholeFoods.WfmEmployeeManagement.Model
{
    public interface IWfmEmployeeManagementFactory
    {
        WfmEmployeeManagementType Create();
    }
}
