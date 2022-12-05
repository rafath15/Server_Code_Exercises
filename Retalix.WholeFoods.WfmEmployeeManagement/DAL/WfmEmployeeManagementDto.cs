using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using System;

namespace Retalix.WholeFoods.WfmEmployeeManagement.DAL
{
    [Serializable]
    public class WfmEmployeeManagementDto : IMovable
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string ProjectName { get; set; }
        public virtual string Email { get; set; }
        public virtual string MobileNumber { get; set; }
        public override bool Equals(object obj)
        {
            var dto = obj as WfmEmployeeManagementDto;
            if (dto == null)
                return false;
            return (Id == dto.Id && Name == dto.Name && ProjectName == dto.ProjectName && Email == dto.Email && MobileNumber == dto.MobileNumber);
        }
        public override int GetHashCode()
        {
            return (Id + "|" + Name + "|" + ProjectName + "|" + Email + "|" + MobileNumber).GetHashCode();
        }
        public virtual string EntityName
        {
            get { return "WfmEmployeeManagementDtoDMS"; }
        }
    }
}
