namespace Retalix.WholeFoods.WfmEmployeeManagement.Model
{
    public interface IWfmEmployeeManagementMaintenance
    {
        void Add(BusinessComponents.WfmEmployeeManagementType employeeManagements);
        void Update(BusinessComponents.WfmEmployeeManagementType employeeManagements);
        void Delete(BusinessComponents.WfmEmployeeManagementType employeeManagements);
    }
}