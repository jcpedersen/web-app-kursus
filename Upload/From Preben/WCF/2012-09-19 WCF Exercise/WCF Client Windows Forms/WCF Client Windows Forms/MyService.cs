﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5456
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/WCFService")]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private bool BoolValueField;
        
        private string StringValueField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue
        {
            get
            {
                return this.BoolValueField;
            }
            set
            {
                this.BoolValueField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue
        {
            get
            {
                return this.StringValueField;
            }
            set
            {
                this.StringValueField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IMyService")]
public interface IMyService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/GetData", ReplyAction="http://tempuri.org/IMyService/GetDataResponse")]
    string GetData(int value);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IMyService/GetDataUsingDataContractResponse")]
    WCFService.CompositeType GetDataUsingDataContract(WCFService.CompositeType composite);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/HelloWorld", ReplyAction="http://tempuri.org/IMyService/HelloWorldResponse")]
    string HelloWorld(string name);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/Save", ReplyAction="http://tempuri.org/IMyService/SaveResponse")]
    void Save(string data);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/Load", ReplyAction="http://tempuri.org/IMyService/LoadResponse")]
    string Load();
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IMyServiceChannel : IMyService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class MyServiceClient : System.ServiceModel.ClientBase<IMyService>, IMyService
{
    
    public MyServiceClient()
    {
    }
    
    public MyServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public MyServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public MyServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public MyServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public string GetData(int value)
    {
        return base.Channel.GetData(value);
    }
    
    public WCFService.CompositeType GetDataUsingDataContract(WCFService.CompositeType composite)
    {
        return base.Channel.GetDataUsingDataContract(composite);
    }
    
    public string HelloWorld(string name)
    {
        return base.Channel.HelloWorld(name);
    }
    
    public void Save(string data)
    {
        base.Channel.Save(data);
    }
    
    public string Load()
    {
        return base.Channel.Load();
    }
}
