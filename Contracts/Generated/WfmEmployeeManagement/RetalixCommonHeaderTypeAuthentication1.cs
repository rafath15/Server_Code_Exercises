namespace Retalix.Wholefoods.Contracts.Generated.WfmEmployeeManagement
{
    using Retalix.Contracts.Generated.Common;
    using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "10.100.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/XMLSchema.xsd")]
    public partial class RetalixCommonHeaderTypeAuthentication1
    {
        
        private object itemField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("ActiveDirectory", typeof(ActiveDirectoryCredentialType))]
        [System.Xml.Serialization.XmlElementAttribute("AuthenticatedClaim", typeof(AuthenticatedClaimType))]
        [System.Xml.Serialization.XmlElementAttribute("Barcode", typeof(BarcodeCredentialType))]
        [System.Xml.Serialization.XmlElementAttribute("TouchPointIdentifier", typeof(TouchPointCredentialType))]
        [System.Xml.Serialization.XmlElementAttribute("UserNamePassword", typeof(UserNamePasswordCredentialType))]
        [System.Xml.Serialization.XmlElementAttribute("UserNamePin", typeof(UserNamePinCredentialType))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }
}
