using Retalix.WholeFoods.WfmEmployeeManagement.Model;
using System;

namespace Retalix.WholeFoods.WfmEmployeeManagement.BusinessComponents
{
    [Serializable]
    public class WfmEmployeeManagementType : IWfmEmployeeManagement
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string ProjectName { get; set; }
        public virtual string Email { get; set; }
        public virtual string MobileNumber { get; set; }

        public virtual string EntityName
        {
            get { return "WfmEmployeeManagementType"; }
        }
    }
}