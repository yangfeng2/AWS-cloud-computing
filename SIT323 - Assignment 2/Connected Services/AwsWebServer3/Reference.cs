﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIT323___Assignment_2.AwsWebServer3 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AwsWebServer3.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAllocations", ReplyAction="http://tempuri.org/IService/GetAllocationsResponse")]
        ClassLibrary.ConfigData GetAllocations(ClassLibrary.ConfigData cd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAllocations", ReplyAction="http://tempuri.org/IService/GetAllocationsResponse")]
        System.Threading.Tasks.Task<ClassLibrary.ConfigData> GetAllocationsAsync(ClassLibrary.ConfigData cd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/printknapSack", ReplyAction="http://tempuri.org/IService/printknapSackResponse")]
        void printknapSack(int W, int[] wt, int[] val, int n, int[] output);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/printknapSack", ReplyAction="http://tempuri.org/IService/printknapSackResponse")]
        System.Threading.Tasks.Task printknapSackAsync(int W, int[] wt, int[] val, int n, int[] output);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetIPAddress", ReplyAction="http://tempuri.org/IService/GetIPAddressResponse")]
        string GetIPAddress();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetIPAddress", ReplyAction="http://tempuri.org/IService/GetIPAddressResponse")]
        System.Threading.Tasks.Task<string> GetIPAddressAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : SIT323___Assignment_2.AwsWebServer3.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<SIT323___Assignment_2.AwsWebServer3.IService>, SIT323___Assignment_2.AwsWebServer3.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ClassLibrary.ConfigData GetAllocations(ClassLibrary.ConfigData cd) {
            return base.Channel.GetAllocations(cd);
        }
        
        public System.Threading.Tasks.Task<ClassLibrary.ConfigData> GetAllocationsAsync(ClassLibrary.ConfigData cd) {
            return base.Channel.GetAllocationsAsync(cd);
        }
        
        public void printknapSack(int W, int[] wt, int[] val, int n, int[] output) {
            base.Channel.printknapSack(W, wt, val, n, output);
        }
        
        public System.Threading.Tasks.Task printknapSackAsync(int W, int[] wt, int[] val, int n, int[] output) {
            return base.Channel.printknapSackAsync(W, wt, val, n, output);
        }
        
        public string GetIPAddress() {
            return base.Channel.GetIPAddress();
        }
        
        public System.Threading.Tasks.Task<string> GetIPAddressAsync() {
            return base.Channel.GetIPAddressAsync();
        }
    }
}
