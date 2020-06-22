﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace University.Services.UniversityofSheffieldReference {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SheffieldWebServiceSoap", Namespace="http://tempuri.org/")]
    public partial class SheffieldWebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SheffCoursesOperationCompleted;
        
        private System.Threading.SendOrPostCallback SheffCoursesInShortOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SheffieldWebService() {
            this.Url = global::University.Services.Properties.Settings.Default.University_Services_UniversityofSheffieldReference_SheffieldWebService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event SheffCoursesCompletedEventHandler SheffCoursesCompleted;
        
        /// <remarks/>
        public event SheffCoursesInShortCompletedEventHandler SheffCoursesInShortCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SheffCourses", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ShefCourse[] SheffCourses() {
            object[] results = this.Invoke("SheffCourses", new object[0]);
            return ((ShefCourse[])(results[0]));
        }
        
        /// <remarks/>
        public void SheffCoursesAsync() {
            this.SheffCoursesAsync(null);
        }
        
        /// <remarks/>
        public void SheffCoursesAsync(object userState) {
            if ((this.SheffCoursesOperationCompleted == null)) {
                this.SheffCoursesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSheffCoursesOperationCompleted);
            }
            this.InvokeAsync("SheffCourses", new object[0], this.SheffCoursesOperationCompleted, userState);
        }
        
        private void OnSheffCoursesOperationCompleted(object arg) {
            if ((this.SheffCoursesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SheffCoursesCompleted(this, new SheffCoursesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SheffCoursesInShort", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ShortSheffCourse[] SheffCoursesInShort() {
            object[] results = this.Invoke("SheffCoursesInShort", new object[0]);
            return ((ShortSheffCourse[])(results[0]));
        }
        
        /// <remarks/>
        public void SheffCoursesInShortAsync() {
            this.SheffCoursesInShortAsync(null);
        }
        
        /// <remarks/>
        public void SheffCoursesInShortAsync(object userState) {
            if ((this.SheffCoursesInShortOperationCompleted == null)) {
                this.SheffCoursesInShortOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSheffCoursesInShortOperationCompleted);
            }
            this.InvokeAsync("SheffCoursesInShort", new object[0], this.SheffCoursesInShortOperationCompleted, userState);
        }
        
        private void OnSheffCoursesInShortOperationCompleted(object arg) {
            if ((this.SheffCoursesInShortCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SheffCoursesInShortCompleted(this, new SheffCoursesInShortCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ShefCourse {
        
        private int idField;
        
        private string nameField;
        
        private string descriptionField;
        
        private string entryReqField;
        
        private System.Nullable<int> tarifField;
        
        private string universityField;
        
        private System.Nullable<int> nSSField;
        
        private string qualificationField;
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public string EntryReq {
            get {
                return this.entryReqField;
            }
            set {
                this.entryReqField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> Tarif {
            get {
                return this.tarifField;
            }
            set {
                this.tarifField = value;
            }
        }
        
        /// <remarks/>
        public string University {
            get {
                return this.universityField;
            }
            set {
                this.universityField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> NSS {
            get {
                return this.nSSField;
            }
            set {
                this.nSSField = value;
            }
        }
        
        /// <remarks/>
        public string Qualification {
            get {
                return this.qualificationField;
            }
            set {
                this.qualificationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3190.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ShortSheffCourse {
        
        private int idField;
        
        private string nameField;
        
        private string descriptionField;
        
        private string entryReqField;
        
        private string qualificationField;
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public string EntryReq {
            get {
                return this.entryReqField;
            }
            set {
                this.entryReqField = value;
            }
        }
        
        /// <remarks/>
        public string Qualification {
            get {
                return this.qualificationField;
            }
            set {
                this.qualificationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    public delegate void SheffCoursesCompletedEventHandler(object sender, SheffCoursesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SheffCoursesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SheffCoursesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ShefCourse[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ShefCourse[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    public delegate void SheffCoursesInShortCompletedEventHandler(object sender, SheffCoursesInShortCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3190.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SheffCoursesInShortCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SheffCoursesInShortCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ShortSheffCourse[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ShortSheffCourse[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591