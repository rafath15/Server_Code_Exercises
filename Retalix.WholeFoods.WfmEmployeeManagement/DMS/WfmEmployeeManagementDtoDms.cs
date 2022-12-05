using ProtoBuf;
using Retalix.StoreServices.Model.Infrastructure.DataMovement;

namespace Retalix.WholeFoods.WfmEmployeeManagement.DMS
{
    [ProtoContract]
    public class WfmEmployeeManagementDtoDms : INamedObject
    {
        [ProtoMember(2)]
        public int Id { get; set; }

        [ProtoMember(3)]
        public string Name { get; set; }
        [ProtoMember(4)]
        public string ProjectName { get; set; }

        [ProtoMember(5)]
        public string Email { get; set; }

        [ProtoMember(6)]
        public string MobileNumber { get; set; }


        public string EntityName
        {
            get { return "EmployeeManagementDtoDms"; }
            set { }
        }
    }
}
