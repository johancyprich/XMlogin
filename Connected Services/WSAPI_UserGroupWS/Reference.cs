﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XMlogin.WSAPI_UserGroupWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="uStoreWSAPI", ConfigurationName="WSAPI_UserGroupWS.UserGroupWSSoap")]
    public interface UserGroupWSSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="uStoreWSAPI/GetUserGroupList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ReturnObject))]
        XMlogin.WSAPI_UserGroupWS.UserGroup[] GetUserGroupList(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="uStoreWSAPI/GetUserGroupList", ReplyAction="*")]
        System.Threading.Tasks.Task<XMlogin.WSAPI_UserGroupWS.UserGroup[]> GetUserGroupListAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="uStoreWSAPI/GetUserGroupListForUser", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ReturnObject))]
        XMlogin.WSAPI_UserGroupWS.UserGroup[] GetUserGroupListForUser(string username, string password, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="uStoreWSAPI/GetUserGroupListForUser", ReplyAction="*")]
        System.Threading.Tasks.Task<XMlogin.WSAPI_UserGroupWS.UserGroup[]> GetUserGroupListForUserAsync(string username, string password, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="uStoreWSAPI/GetUserGroup", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ReturnObject))]
        XMlogin.WSAPI_UserGroupWS.UserGroup GetUserGroup(string username, string password, int userGroupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="uStoreWSAPI/GetUserGroup", ReplyAction="*")]
        System.Threading.Tasks.Task<XMlogin.WSAPI_UserGroupWS.UserGroup> GetUserGroupAsync(string username, string password, int userGroupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="uStoreWSAPI/GetUserListByGroup", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ReturnObject))]
        XMlogin.WSAPI_UserGroupWS.User[] GetUserListByGroup(string username, string password, int userGroupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="uStoreWSAPI/GetUserListByGroup", ReplyAction="*")]
        System.Threading.Tasks.Task<XMlogin.WSAPI_UserGroupWS.User[]> GetUserListByGroupAsync(string username, string password, int userGroupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="uStoreWSAPI/AddUserToGroup", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ReturnObject))]
        void AddUserToGroup(string username, string password, int userId, int userGroupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="uStoreWSAPI/AddUserToGroup", ReplyAction="*")]
        System.Threading.Tasks.Task AddUserToGroupAsync(string username, string password, int userId, int userGroupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="uStoreWSAPI/RemoveUserFromGroup", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ReturnObject))]
        void RemoveUserFromGroup(string username, string password, int userId, int userGroupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="uStoreWSAPI/RemoveUserFromGroup", ReplyAction="*")]
        System.Threading.Tasks.Task RemoveUserFromGroupAsync(string username, string password, int userId, int userGroupId);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="uStoreWSAPI")]
    public partial class UserGroup : ReturnObject {
        
        private int userGroupIDField;
        
        private int parentGroupIdField;
        
        private string nameField;
        
        private string descriptionField;
        
        private bool isAnonymousField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int UserGroupID {
            get {
                return this.userGroupIDField;
            }
            set {
                this.userGroupIDField = value;
                this.RaisePropertyChanged("UserGroupID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int ParentGroupId {
            get {
                return this.parentGroupIdField;
            }
            set {
                this.parentGroupIdField = value;
                this.RaisePropertyChanged("ParentGroupId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("Name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("Description");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public bool IsAnonymous {
            get {
                return this.isAnonymousField;
            }
            set {
                this.isAnonymousField = value;
                this.RaisePropertyChanged("IsAnonymous");
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(User))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UserGroup))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="uStoreWSAPI")]
    public abstract partial class ReturnObject : object, System.ComponentModel.INotifyPropertyChanged {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="uStoreWSAPI")]
    public partial class User : ReturnObject {
        
        private int userIDField;
        
        private string loginField;
        
        private string firstNameField;
        
        private string lastNameField;
        
        private string emailField;
        
        private int createdLoginSessionIDField;
        
        private System.DateTime createdDateField;
        
        private int modifiedLoginSessionIDField;
        
        private System.DateTime modifiedDateField;
        
        private int statusIDField;
        
        private string externalIDField;
        
        private string phoneNumberField;
        
        private string mobileNumberField;
        
        private string faxNumberField;
        
        private string companyNameField;
        
        private string departmentField;
        
        private string jobTitleField;
        
        private bool isActivatedField;
        
        private bool isLockedField;
        
        private int assignedToStoreIDField;
        
        private int genderIDField;
        
        private System.DateTime birthDayField;
        
        private string custom1Field;
        
        private string custom2Field;
        
        private string custom3Field;
        
        private string custom4Field;
        
        private string custom5Field;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int UserID {
            get {
                return this.userIDField;
            }
            set {
                this.userIDField = value;
                this.RaisePropertyChanged("UserID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Login {
            get {
                return this.loginField;
            }
            set {
                this.loginField = value;
                this.RaisePropertyChanged("Login");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string FirstName {
            get {
                return this.firstNameField;
            }
            set {
                this.firstNameField = value;
                this.RaisePropertyChanged("FirstName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string LastName {
            get {
                return this.lastNameField;
            }
            set {
                this.lastNameField = value;
                this.RaisePropertyChanged("LastName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
                this.RaisePropertyChanged("Email");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int CreatedLoginSessionID {
            get {
                return this.createdLoginSessionIDField;
            }
            set {
                this.createdLoginSessionIDField = value;
                this.RaisePropertyChanged("CreatedLoginSessionID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public System.DateTime CreatedDate {
            get {
                return this.createdDateField;
            }
            set {
                this.createdDateField = value;
                this.RaisePropertyChanged("CreatedDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int ModifiedLoginSessionID {
            get {
                return this.modifiedLoginSessionIDField;
            }
            set {
                this.modifiedLoginSessionIDField = value;
                this.RaisePropertyChanged("ModifiedLoginSessionID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public System.DateTime ModifiedDate {
            get {
                return this.modifiedDateField;
            }
            set {
                this.modifiedDateField = value;
                this.RaisePropertyChanged("ModifiedDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int StatusID {
            get {
                return this.statusIDField;
            }
            set {
                this.statusIDField = value;
                this.RaisePropertyChanged("StatusID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string ExternalID {
            get {
                return this.externalIDField;
            }
            set {
                this.externalIDField = value;
                this.RaisePropertyChanged("ExternalID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string PhoneNumber {
            get {
                return this.phoneNumberField;
            }
            set {
                this.phoneNumberField = value;
                this.RaisePropertyChanged("PhoneNumber");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string MobileNumber {
            get {
                return this.mobileNumberField;
            }
            set {
                this.mobileNumberField = value;
                this.RaisePropertyChanged("MobileNumber");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string FaxNumber {
            get {
                return this.faxNumberField;
            }
            set {
                this.faxNumberField = value;
                this.RaisePropertyChanged("FaxNumber");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string CompanyName {
            get {
                return this.companyNameField;
            }
            set {
                this.companyNameField = value;
                this.RaisePropertyChanged("CompanyName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string Department {
            get {
                return this.departmentField;
            }
            set {
                this.departmentField = value;
                this.RaisePropertyChanged("Department");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string JobTitle {
            get {
                return this.jobTitleField;
            }
            set {
                this.jobTitleField = value;
                this.RaisePropertyChanged("JobTitle");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public bool IsActivated {
            get {
                return this.isActivatedField;
            }
            set {
                this.isActivatedField = value;
                this.RaisePropertyChanged("IsActivated");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public bool IsLocked {
            get {
                return this.isLockedField;
            }
            set {
                this.isLockedField = value;
                this.RaisePropertyChanged("IsLocked");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public int AssignedToStoreID {
            get {
                return this.assignedToStoreIDField;
            }
            set {
                this.assignedToStoreIDField = value;
                this.RaisePropertyChanged("AssignedToStoreID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public int GenderID {
            get {
                return this.genderIDField;
            }
            set {
                this.genderIDField = value;
                this.RaisePropertyChanged("GenderID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public System.DateTime BirthDay {
            get {
                return this.birthDayField;
            }
            set {
                this.birthDayField = value;
                this.RaisePropertyChanged("BirthDay");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        public string Custom1 {
            get {
                return this.custom1Field;
            }
            set {
                this.custom1Field = value;
                this.RaisePropertyChanged("Custom1");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
        public string Custom2 {
            get {
                return this.custom2Field;
            }
            set {
                this.custom2Field = value;
                this.RaisePropertyChanged("Custom2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=24)]
        public string Custom3 {
            get {
                return this.custom3Field;
            }
            set {
                this.custom3Field = value;
                this.RaisePropertyChanged("Custom3");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=25)]
        public string Custom4 {
            get {
                return this.custom4Field;
            }
            set {
                this.custom4Field = value;
                this.RaisePropertyChanged("Custom4");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=26)]
        public string Custom5 {
            get {
                return this.custom5Field;
            }
            set {
                this.custom5Field = value;
                this.RaisePropertyChanged("Custom5");
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface UserGroupWSSoapChannel : XMlogin.WSAPI_UserGroupWS.UserGroupWSSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserGroupWSSoapClient : System.ServiceModel.ClientBase<XMlogin.WSAPI_UserGroupWS.UserGroupWSSoap>, XMlogin.WSAPI_UserGroupWS.UserGroupWSSoap {
        
        public UserGroupWSSoapClient() {
        }
        
        public UserGroupWSSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserGroupWSSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserGroupWSSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserGroupWSSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public XMlogin.WSAPI_UserGroupWS.UserGroup[] GetUserGroupList(string username, string password) {
            return base.Channel.GetUserGroupList(username, password);
        }
        
        public System.Threading.Tasks.Task<XMlogin.WSAPI_UserGroupWS.UserGroup[]> GetUserGroupListAsync(string username, string password) {
            return base.Channel.GetUserGroupListAsync(username, password);
        }
        
        public XMlogin.WSAPI_UserGroupWS.UserGroup[] GetUserGroupListForUser(string username, string password, int userId) {
            return base.Channel.GetUserGroupListForUser(username, password, userId);
        }
        
        public System.Threading.Tasks.Task<XMlogin.WSAPI_UserGroupWS.UserGroup[]> GetUserGroupListForUserAsync(string username, string password, int userId) {
            return base.Channel.GetUserGroupListForUserAsync(username, password, userId);
        }
        
        public XMlogin.WSAPI_UserGroupWS.UserGroup GetUserGroup(string username, string password, int userGroupId) {
            return base.Channel.GetUserGroup(username, password, userGroupId);
        }
        
        public System.Threading.Tasks.Task<XMlogin.WSAPI_UserGroupWS.UserGroup> GetUserGroupAsync(string username, string password, int userGroupId) {
            return base.Channel.GetUserGroupAsync(username, password, userGroupId);
        }
        
        public XMlogin.WSAPI_UserGroupWS.User[] GetUserListByGroup(string username, string password, int userGroupId) {
            return base.Channel.GetUserListByGroup(username, password, userGroupId);
        }
        
        public System.Threading.Tasks.Task<XMlogin.WSAPI_UserGroupWS.User[]> GetUserListByGroupAsync(string username, string password, int userGroupId) {
            return base.Channel.GetUserListByGroupAsync(username, password, userGroupId);
        }
        
        public void AddUserToGroup(string username, string password, int userId, int userGroupId) {
            base.Channel.AddUserToGroup(username, password, userId, userGroupId);
        }
        
        public System.Threading.Tasks.Task AddUserToGroupAsync(string username, string password, int userId, int userGroupId) {
            return base.Channel.AddUserToGroupAsync(username, password, userId, userGroupId);
        }
        
        public void RemoveUserFromGroup(string username, string password, int userId, int userGroupId) {
            base.Channel.RemoveUserFromGroup(username, password, userId, userGroupId);
        }
        
        public System.Threading.Tasks.Task RemoveUserFromGroupAsync(string username, string password, int userId, int userGroupId) {
            return base.Channel.RemoveUserFromGroupAsync(username, password, userId, userGroupId);
        }
    }
}
