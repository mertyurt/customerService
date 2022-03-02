using CustomerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CustomerService
{
    // NOT: "IService1" arabirim adını kodda ve yapılandırma dosyasında birlikte değiştirmek için "Yeniden Düzenle" menüsündeki "Yeniden Adlandır" komutunu kullanabilirsiniz.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(
            Method ="POST",
            RequestFormat =WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            //BodyStyle = WebMessageBodyStyle.Bare
            UriTemplate = "create-customer/")]
        Customer CreateCustomer(ReqCreateCustomer value);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate ="get-customer/{id=null}/")]
        Customer GetCustomer(string id);

        [OperationContract]
        [WebInvoke(
            Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            //BodyStyle = WebMessageBodyStyle.Bare
            UriTemplate = "update-customer/{id=null}/")]
        Customer UpdateCustomer(string id, ReqCreateCustomer customer);

        [OperationContract]
        [WebInvoke(
            Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            //BodyStyle = WebMessageBodyStyle.Bare
            UriTemplate = "delete-customer/{id=null}/")]
        void DeleteCustomer(string Id);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "get-qualified/{nation=null}/")]
        List<Customer> GetQualifiedCustomers(string nation);
    }
}
