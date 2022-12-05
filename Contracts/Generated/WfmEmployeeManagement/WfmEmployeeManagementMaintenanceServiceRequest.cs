namespace Retalix.Wholefoods.Contracts.Generated.WfmEmployeeManagement
{
    using Retalix.Contracts.Generated.Common;
    using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "10.100.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://retalix.com/R10/services")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://retalix.com/R10/services", IsNullable=false)]
    public partial class WfmEmployeeManagementMaintenanceServiceRequest : Retalix.Contracts.Interfaces.IHeaderRequest
    {
        
        private RetalixCommonHeaderType headerField;
        
        private EmployeeManagementType[] employeeManagementField;
        
        public RetalixCommonHeaderType Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("EmployeeManagement")]
        public EmployeeManagementType[] EmployeeManagement
        {
            get
            {
                return this.employeeManagementField;
            }
            set
            {
                this.employeeManagementField = value;
            }
        }
    }
}
