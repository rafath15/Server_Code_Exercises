namespace Retalix.Wholefoods.Contracts.Generated.WfmEmployeeManagement
{
    using Retalix.Contracts.Generated.Common;
    using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "10.100.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://retalix.com/R10/services")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://retalix.com/R10/services", IsNullable=true)]
    public partial class SearchCriteriaType
    {
        
        private int idField;
        
        private string nameField;
        
        private string projectNameField;
        
        private string emailField;
        
        private bool IdFieldSpecified;
        
        public int Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
                this.IdSpecified = true;
            }
        }
        
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        
        public string ProjectName
        {
            get
            {
                return this.projectNameField;
            }
            set
            {
                this.projectNameField = value;
            }
        }
        
        public string Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual bool IdSpecified
        {
            get
            {
                return this.IdFieldSpecified;
            }
            set
            {
                this.IdFieldSpecified = value;
            }
        }
    }
}
