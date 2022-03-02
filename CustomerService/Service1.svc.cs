using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CustomerService.Models;

namespace CustomerService
{
    // NOT: "Service1" sınıf adını kodda, svc'de ve yapılandırma dosyasında birlikte değiştirmek için "Yeniden Düzenle" menüsündeki "Yeniden Adlandır" komutunu kullanabilirsiniz.
    // NOT: Bu hizmeti test etmek üzere WCF Test İstemcisi'ni başlatmak için lütfen Çözüm Gezgini'nde Service1.svc'yi veya Service1.svc.cs'yi seçin ve hata ayıklamaya başlayın.
    public class Service1 : IService1
    {
        public Customer CreateCustomer(ReqCreateCustomer value)
        {
            try
            {
                if (String.IsNullOrEmpty(value.Nationality) || 
                    String.IsNullOrEmpty(value.Status.ToString()) || 
                    value.Status < 0 || value.Status > 3)
                {
                    throw new WebFaultException<string>("Please check your parameters", HttpStatusCode.BadRequest);
                }
                Customer newCustomer = new Customer
                {
                    Id = Guid.NewGuid().ToString(),
                    Nationality = value.Nationality,
                    Status = value.Status
                };
                WebOperationContext context = WebOperationContext.Current;
                context.OutgoingResponse.StatusCode = HttpStatusCode.OK;

                return newCustomer;
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.ToString(), HttpStatusCode.BadRequest);
            }
        }

        public Customer GetCustomer(string id)
        {
            try
            {
                Customer customer = new Customer();
                //get customer from db with the ID

                return customer;
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.ToString(), HttpStatusCode.BadRequest);
            }
        }

        public Customer UpdateCustomer(string Id, ReqCreateCustomer customer)
        {
            try
            {
                if(String.IsNullOrEmpty(Id))
                {
                    throw new WebFaultException<string>("Id field can't be null", HttpStatusCode.BadRequest);
                }
                if (String.IsNullOrEmpty(customer.Nationality) && String.IsNullOrEmpty(customer.Status.ToString()))
                {
                    throw new WebFaultException<string>("Atleast one field needs to be updated.", HttpStatusCode.BadRequest);
                }
                //check if customer in the DB with customer.Id
                //if there's customer update fields
                //if some fields are null do not update those fields
                Customer tempCustomer = new Customer
                {
                    Id = Id,
                    Nationality = customer.Nationality,
                    Status = customer.Status
                };

                WebOperationContext context = WebOperationContext.Current;
                context.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                context.OutgoingResponse.StatusDescription = "Customer updated.";

                return tempCustomer;
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.ToString(), HttpStatusCode.BadRequest);
            }
        }

        public void DeleteCustomer(string Id)
        {
            try
            {
                if (String.IsNullOrEmpty(Id))
                {
                    throw new WebFaultException<string>("Id field can't be null", HttpStatusCode.BadRequest);
                }

                //if there's customer with the given Id find the customer and delete
                WebOperationContext context = WebOperationContext.Current;
                context.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                context.OutgoingResponse.StatusDescription = "Customer deleted.";
                return;
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.ToString(), HttpStatusCode.BadRequest);
            }

        }

        public List<Customer> GetQualifiedCustomers(string nation)
        {
            try
            {
                if (String.IsNullOrEmpty(nation))
                {
                    throw new WebFaultException<string>("Nation field cant be null", HttpStatusCode.BadRequest);
                }
                List<Customer> cusList = new List<Customer>();

                //query db for customers with Status == 1 and nation

                return cusList;
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.ToString(), HttpStatusCode.BadRequest);
            }
        }
    }
}
