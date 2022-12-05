using Retalix.StoreServices.Model.Infrastructure.DataMovement;

namespace Retalix.WholeFoods.WfmEmployeeManagement.Model
{
    public interface IWfmEmployeeManagement: IMovable
    {
        int Id { get; set; }
        string Name { get; set; }
        string ProjectName { get; set; }
        string Email { get; set; }
        string MobileNumber { get; set; }
    }
}
