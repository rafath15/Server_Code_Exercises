namespace Retalix.Wholefoods.Contracts.Generated.WfmEmployeeManagement
{
    using Retalix.Contracts.Generated.Common;
    using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "10.100.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/XMLSchema.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/XMLSchema.xsd", IsNullable=false)]
    public partial class WfmEmployeeManagementMaintenanceServiceResponse : Retalix.Contracts.Interfaces.IHeaderResponse
    {
        
        private RetalixCommonHeaderType headerField;
        
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
    }
}
