﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleFolderWatcherTest.WcfEchoServiceReferenceTest {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Cheque", Namespace="http://schemas.datacontract.org/2004/07/WcfDbEchoLib")]
    [System.SerializableAttribute()]
    public partial class Cheque : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] ArticlesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal DiscountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal SummField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Articles {
            get {
                return this.ArticlesField;
            }
            set {
                if ((object.ReferenceEquals(this.ArticlesField, value) != true)) {
                    this.ArticlesField = value;
                    this.RaisePropertyChanged("Articles");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Discount {
            get {
                return this.DiscountField;
            }
            set {
                if ((this.DiscountField.Equals(value) != true)) {
                    this.DiscountField = value;
                    this.RaisePropertyChanged("Discount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Number {
            get {
                return this.NumberField;
            }
            set {
                if ((object.ReferenceEquals(this.NumberField, value) != true)) {
                    this.NumberField = value;
                    this.RaisePropertyChanged("Number");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Summ {
            get {
                return this.SummField;
            }
            set {
                if ((this.SummField.Equals(value) != true)) {
                    this.SummField = value;
                    this.RaisePropertyChanged("Summ");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://MyWcfSrvs.ServiceModel.Samples", ConfigurationName="WcfEchoServiceReferenceTest.IChequeServiceContract")]
    public interface IChequeServiceContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://MyWcfSrvs.ServiceModel.Samples/IChequeServiceContract/SaveCheque", ReplyAction="http://MyWcfSrvs.ServiceModel.Samples/IChequeServiceContract/SaveChequeResponse")]
        void SaveCheque(ConsoleFolderWatcherTest.WcfEchoServiceReferenceTest.Cheque cheque);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://MyWcfSrvs.ServiceModel.Samples/IChequeServiceContract/SaveCheque", ReplyAction="http://MyWcfSrvs.ServiceModel.Samples/IChequeServiceContract/SaveChequeResponse")]
        System.Threading.Tasks.Task SaveChequeAsync(ConsoleFolderWatcherTest.WcfEchoServiceReferenceTest.Cheque cheque);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://MyWcfSrvs.ServiceModel.Samples/IChequeServiceContract/GetLastCheques", ReplyAction="http://MyWcfSrvs.ServiceModel.Samples/IChequeServiceContract/GetLastChequesRespon" +
            "se")]
        ConsoleFolderWatcherTest.WcfEchoServiceReferenceTest.Cheque[] GetLastCheques(int lastChequeCount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://MyWcfSrvs.ServiceModel.Samples/IChequeServiceContract/GetLastCheques", ReplyAction="http://MyWcfSrvs.ServiceModel.Samples/IChequeServiceContract/GetLastChequesRespon" +
            "se")]
        System.Threading.Tasks.Task<ConsoleFolderWatcherTest.WcfEchoServiceReferenceTest.Cheque[]> GetLastChequesAsync(int lastChequeCount);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChequeServiceContractChannel : ConsoleFolderWatcherTest.WcfEchoServiceReferenceTest.IChequeServiceContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChequeServiceContractClient : System.ServiceModel.ClientBase<ConsoleFolderWatcherTest.WcfEchoServiceReferenceTest.IChequeServiceContract>, ConsoleFolderWatcherTest.WcfEchoServiceReferenceTest.IChequeServiceContract {
        
        public ChequeServiceContractClient() {
        }
        
        public ChequeServiceContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ChequeServiceContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChequeServiceContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChequeServiceContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void SaveCheque(ConsoleFolderWatcherTest.WcfEchoServiceReferenceTest.Cheque cheque) {
            base.Channel.SaveCheque(cheque);
        }
        
        public System.Threading.Tasks.Task SaveChequeAsync(ConsoleFolderWatcherTest.WcfEchoServiceReferenceTest.Cheque cheque) {
            return base.Channel.SaveChequeAsync(cheque);
        }
        
        public ConsoleFolderWatcherTest.WcfEchoServiceReferenceTest.Cheque[] GetLastCheques(int lastChequeCount) {
            return base.Channel.GetLastCheques(lastChequeCount);
        }
        
        public System.Threading.Tasks.Task<ConsoleFolderWatcherTest.WcfEchoServiceReferenceTest.Cheque[]> GetLastChequesAsync(int lastChequeCount) {
            return base.Channel.GetLastChequesAsync(lastChequeCount);
        }
    }
}
