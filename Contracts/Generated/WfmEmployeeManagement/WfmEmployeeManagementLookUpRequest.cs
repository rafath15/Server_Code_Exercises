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
    public partial class WfmEmployeeManagementLookUpRequest : Retalix.Contracts.Interfaces.IHeaderRequest
    {
        
        private RetalixCommonHeaderType headerField;
        
        private SearchCriteriaType searchCriteriaField;
        
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
        
        public SearchCriteriaType SearchCriteria
        {
            get
            {
                return this.searchCriteriaField;
            }
            set
            {
                this.searchCriteriaField = value;
            }
        }
    }
}
