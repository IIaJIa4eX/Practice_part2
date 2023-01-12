﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторного создания кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryServiceReference
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Book", Namespace="http://tempuri.org/")]
    public partial class Book : object
    {
        
        private string IdField;
        
        private string TitleField;
        
        private string CategoryField;
        
        private string LangField;
        
        private int PagesField;
        
        private int AgeLimitField;
        
        private int PublicationDateField;
        
        private LibraryServiceReference.Author[] AuthorsField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Title
        {
            get
            {
                return this.TitleField;
            }
            set
            {
                this.TitleField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Category
        {
            get
            {
                return this.CategoryField;
            }
            set
            {
                this.CategoryField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string Lang
        {
            get
            {
                return this.LangField;
            }
            set
            {
                this.LangField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public int Pages
        {
            get
            {
                return this.PagesField;
            }
            set
            {
                this.PagesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public int AgeLimit
        {
            get
            {
                return this.AgeLimitField;
            }
            set
            {
                this.AgeLimitField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=6)]
        public int PublicationDate
        {
            get
            {
                return this.PublicationDateField;
            }
            set
            {
                this.PublicationDateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public LibraryServiceReference.Author[] Authors
        {
            get
            {
                return this.AuthorsField;
            }
            set
            {
                this.AuthorsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Author", Namespace="http://tempuri.org/")]
    public partial class Author : object
    {
        
        private string NameField;
        
        private string LangField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Lang
        {
            get
            {
                return this.LangField;
            }
            set
            {
                this.LangField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LibraryServiceReference.TestWebServiceSoap")]
    public interface TestWebServiceSoap
    {
        
        // CODEGEN: Создание контракта сообщения, так как имя элемента title из пространства имен http://tempuri.org/ не отмечено как обнуляемое.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetBooksByTitle", ReplyAction="*")]
        LibraryServiceReference.GetBooksByTitleResponse GetBooksByTitle(LibraryServiceReference.GetBooksByTitleRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetBooksByTitle", ReplyAction="*")]
        System.Threading.Tasks.Task<LibraryServiceReference.GetBooksByTitleResponse> GetBooksByTitleAsync(LibraryServiceReference.GetBooksByTitleRequest request);
        
        // CODEGEN: Создание контракта сообщения, так как имя элемента authorName из пространства имен http://tempuri.org/ не отмечено как обнуляемое.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetBooksByAuthor", ReplyAction="*")]
        LibraryServiceReference.GetBooksByAuthorResponse GetBooksByAuthor(LibraryServiceReference.GetBooksByAuthorRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetBooksByAuthor", ReplyAction="*")]
        System.Threading.Tasks.Task<LibraryServiceReference.GetBooksByAuthorResponse> GetBooksByAuthorAsync(LibraryServiceReference.GetBooksByAuthorRequest request);
        
        // CODEGEN: Создание контракта сообщения, так как имя элемента category из пространства имен http://tempuri.org/ не отмечено как обнуляемое.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetBooksByCategory", ReplyAction="*")]
        LibraryServiceReference.GetBooksByCategoryResponse GetBooksByCategory(LibraryServiceReference.GetBooksByCategoryRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetBooksByCategory", ReplyAction="*")]
        System.Threading.Tasks.Task<LibraryServiceReference.GetBooksByCategoryResponse> GetBooksByCategoryAsync(LibraryServiceReference.GetBooksByCategoryRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetBooksByTitleRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetBooksByTitle", Namespace="http://tempuri.org/", Order=0)]
        public LibraryServiceReference.GetBooksByTitleRequestBody Body;
        
        public GetBooksByTitleRequest()
        {
        }
        
        public GetBooksByTitleRequest(LibraryServiceReference.GetBooksByTitleRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetBooksByTitleRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string title;
        
        public GetBooksByTitleRequestBody()
        {
        }
        
        public GetBooksByTitleRequestBody(string title)
        {
            this.title = title;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetBooksByTitleResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetBooksByTitleResponse", Namespace="http://tempuri.org/", Order=0)]
        public LibraryServiceReference.GetBooksByTitleResponseBody Body;
        
        public GetBooksByTitleResponse()
        {
        }
        
        public GetBooksByTitleResponse(LibraryServiceReference.GetBooksByTitleResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetBooksByTitleResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public LibraryServiceReference.Book[] GetBooksByTitleResult;
        
        public GetBooksByTitleResponseBody()
        {
        }
        
        public GetBooksByTitleResponseBody(LibraryServiceReference.Book[] GetBooksByTitleResult)
        {
            this.GetBooksByTitleResult = GetBooksByTitleResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetBooksByAuthorRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetBooksByAuthor", Namespace="http://tempuri.org/", Order=0)]
        public LibraryServiceReference.GetBooksByAuthorRequestBody Body;
        
        public GetBooksByAuthorRequest()
        {
        }
        
        public GetBooksByAuthorRequest(LibraryServiceReference.GetBooksByAuthorRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetBooksByAuthorRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string authorName;
        
        public GetBooksByAuthorRequestBody()
        {
        }
        
        public GetBooksByAuthorRequestBody(string authorName)
        {
            this.authorName = authorName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetBooksByAuthorResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetBooksByAuthorResponse", Namespace="http://tempuri.org/", Order=0)]
        public LibraryServiceReference.GetBooksByAuthorResponseBody Body;
        
        public GetBooksByAuthorResponse()
        {
        }
        
        public GetBooksByAuthorResponse(LibraryServiceReference.GetBooksByAuthorResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetBooksByAuthorResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public LibraryServiceReference.Book[] GetBooksByAuthorResult;
        
        public GetBooksByAuthorResponseBody()
        {
        }
        
        public GetBooksByAuthorResponseBody(LibraryServiceReference.Book[] GetBooksByAuthorResult)
        {
            this.GetBooksByAuthorResult = GetBooksByAuthorResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetBooksByCategoryRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetBooksByCategory", Namespace="http://tempuri.org/", Order=0)]
        public LibraryServiceReference.GetBooksByCategoryRequestBody Body;
        
        public GetBooksByCategoryRequest()
        {
        }
        
        public GetBooksByCategoryRequest(LibraryServiceReference.GetBooksByCategoryRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetBooksByCategoryRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string category;
        
        public GetBooksByCategoryRequestBody()
        {
        }
        
        public GetBooksByCategoryRequestBody(string category)
        {
            this.category = category;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetBooksByCategoryResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetBooksByCategoryResponse", Namespace="http://tempuri.org/", Order=0)]
        public LibraryServiceReference.GetBooksByCategoryResponseBody Body;
        
        public GetBooksByCategoryResponse()
        {
        }
        
        public GetBooksByCategoryResponse(LibraryServiceReference.GetBooksByCategoryResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetBooksByCategoryResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public LibraryServiceReference.Book[] GetBooksByCategoryResult;
        
        public GetBooksByCategoryResponseBody()
        {
        }
        
        public GetBooksByCategoryResponseBody(LibraryServiceReference.Book[] GetBooksByCategoryResult)
        {
            this.GetBooksByCategoryResult = GetBooksByCategoryResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface TestWebServiceSoapChannel : LibraryServiceReference.TestWebServiceSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class TestWebServiceSoapClient : System.ServiceModel.ClientBase<LibraryServiceReference.TestWebServiceSoap>, LibraryServiceReference.TestWebServiceSoap
    {
        
        /// <summary>
        /// Реализуйте этот разделяемый метод для настройки конечной точки службы.
        /// </summary>
        /// <param name="serviceEndpoint">Настраиваемая конечная точка</param>
        /// <param name="clientCredentials">Учетные данные клиента.</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public TestWebServiceSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(TestWebServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), TestWebServiceSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TestWebServiceSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(TestWebServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TestWebServiceSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(TestWebServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TestWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        LibraryServiceReference.GetBooksByTitleResponse LibraryServiceReference.TestWebServiceSoap.GetBooksByTitle(LibraryServiceReference.GetBooksByTitleRequest request)
        {
            return base.Channel.GetBooksByTitle(request);
        }
        
        public LibraryServiceReference.Book[] GetBooksByTitle(string title)
        {
            LibraryServiceReference.GetBooksByTitleRequest inValue = new LibraryServiceReference.GetBooksByTitleRequest();
            inValue.Body = new LibraryServiceReference.GetBooksByTitleRequestBody();
            inValue.Body.title = title;
            LibraryServiceReference.GetBooksByTitleResponse retVal = ((LibraryServiceReference.TestWebServiceSoap)(this)).GetBooksByTitle(inValue);
            return retVal.Body.GetBooksByTitleResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<LibraryServiceReference.GetBooksByTitleResponse> LibraryServiceReference.TestWebServiceSoap.GetBooksByTitleAsync(LibraryServiceReference.GetBooksByTitleRequest request)
        {
            return base.Channel.GetBooksByTitleAsync(request);
        }
        
        public System.Threading.Tasks.Task<LibraryServiceReference.GetBooksByTitleResponse> GetBooksByTitleAsync(string title)
        {
            LibraryServiceReference.GetBooksByTitleRequest inValue = new LibraryServiceReference.GetBooksByTitleRequest();
            inValue.Body = new LibraryServiceReference.GetBooksByTitleRequestBody();
            inValue.Body.title = title;
            return ((LibraryServiceReference.TestWebServiceSoap)(this)).GetBooksByTitleAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        LibraryServiceReference.GetBooksByAuthorResponse LibraryServiceReference.TestWebServiceSoap.GetBooksByAuthor(LibraryServiceReference.GetBooksByAuthorRequest request)
        {
            return base.Channel.GetBooksByAuthor(request);
        }
        
        public LibraryServiceReference.Book[] GetBooksByAuthor(string authorName)
        {
            LibraryServiceReference.GetBooksByAuthorRequest inValue = new LibraryServiceReference.GetBooksByAuthorRequest();
            inValue.Body = new LibraryServiceReference.GetBooksByAuthorRequestBody();
            inValue.Body.authorName = authorName;
            LibraryServiceReference.GetBooksByAuthorResponse retVal = ((LibraryServiceReference.TestWebServiceSoap)(this)).GetBooksByAuthor(inValue);
            return retVal.Body.GetBooksByAuthorResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<LibraryServiceReference.GetBooksByAuthorResponse> LibraryServiceReference.TestWebServiceSoap.GetBooksByAuthorAsync(LibraryServiceReference.GetBooksByAuthorRequest request)
        {
            return base.Channel.GetBooksByAuthorAsync(request);
        }
        
        public System.Threading.Tasks.Task<LibraryServiceReference.GetBooksByAuthorResponse> GetBooksByAuthorAsync(string authorName)
        {
            LibraryServiceReference.GetBooksByAuthorRequest inValue = new LibraryServiceReference.GetBooksByAuthorRequest();
            inValue.Body = new LibraryServiceReference.GetBooksByAuthorRequestBody();
            inValue.Body.authorName = authorName;
            return ((LibraryServiceReference.TestWebServiceSoap)(this)).GetBooksByAuthorAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        LibraryServiceReference.GetBooksByCategoryResponse LibraryServiceReference.TestWebServiceSoap.GetBooksByCategory(LibraryServiceReference.GetBooksByCategoryRequest request)
        {
            return base.Channel.GetBooksByCategory(request);
        }
        
        public LibraryServiceReference.Book[] GetBooksByCategory(string category)
        {
            LibraryServiceReference.GetBooksByCategoryRequest inValue = new LibraryServiceReference.GetBooksByCategoryRequest();
            inValue.Body = new LibraryServiceReference.GetBooksByCategoryRequestBody();
            inValue.Body.category = category;
            LibraryServiceReference.GetBooksByCategoryResponse retVal = ((LibraryServiceReference.TestWebServiceSoap)(this)).GetBooksByCategory(inValue);
            return retVal.Body.GetBooksByCategoryResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<LibraryServiceReference.GetBooksByCategoryResponse> LibraryServiceReference.TestWebServiceSoap.GetBooksByCategoryAsync(LibraryServiceReference.GetBooksByCategoryRequest request)
        {
            return base.Channel.GetBooksByCategoryAsync(request);
        }
        
        public System.Threading.Tasks.Task<LibraryServiceReference.GetBooksByCategoryResponse> GetBooksByCategoryAsync(string category)
        {
            LibraryServiceReference.GetBooksByCategoryRequest inValue = new LibraryServiceReference.GetBooksByCategoryRequest();
            inValue.Body = new LibraryServiceReference.GetBooksByCategoryRequestBody();
            inValue.Body.category = category;
            return ((LibraryServiceReference.TestWebServiceSoap)(this)).GetBooksByCategoryAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.TestWebServiceSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.TestWebServiceSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpsTransportBindingElement httpsBindingElement = new System.ServiceModel.Channels.HttpsTransportBindingElement();
                httpsBindingElement.AllowCookies = true;
                httpsBindingElement.MaxBufferSize = int.MaxValue;
                httpsBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpsBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Не удалось найти конечную точку с именем \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.TestWebServiceSoap))
            {
                return new System.ServiceModel.EndpointAddress("https://localhost:44319/TestWebService.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.TestWebServiceSoap12))
            {
                return new System.ServiceModel.EndpointAddress("https://localhost:44319/TestWebService.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Не удалось найти конечную точку с именем \"{0}\".", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            TestWebServiceSoap,
            
            TestWebServiceSoap12,
        }
    }
}
