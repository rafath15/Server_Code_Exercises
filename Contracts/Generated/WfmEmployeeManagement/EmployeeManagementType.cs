namespace Retalix.Wholefoods.Contracts.Generated.WfmEmployeeManagement
{
    using Retalix.Contracts.Generated.Common;
    using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "10.100.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://retalix.com/R10/services")]
    [System.Xml.Serialization.XmlRootAttribute("EmployeeManagement", Namespace="http://retalix.com/R10/services", IsNullable=false)]
    public partial class EmployeeManagementType
    {
        
        private int idField;
        
        private string nameField;
        
        private string projectNameField;
        
        private string emailField;
        
        private string mobileNumberField;
        
        private ActionTypeCodes actionField;
        
        private bool actionFieldSpecified;
        
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
        
        public string MobileNumber
        {
            get
            {
                return this.mobileNumberField;
            }
            set
            {
                this.mobileNumberField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ActionTypeCodes Action
        {
            get
            {
                return this.actionField;
            }
            set
            {
                this.actionField = value;
                this.ActionSpecified = true;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ActionSpecified
        {
            get
            {
                return this.actionFieldSpecified;
            }
            set
            {
                this.actionFieldSpecified = value;
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
