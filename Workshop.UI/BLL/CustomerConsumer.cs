using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using Workshop.Entities.ApiModels.Customer.Response;
using Workshop.Entities.DTO;

namespace Workshop.UI.BLL
{
    public class CustomerConsumer
    {
        public static CustomersResponse GetAllCustomers()
        {
            CustomersResponse customers = new CustomersResponse();
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
                client.BaseAddress = new Uri(apiUrl);
                //string token = HttpContext.Current.Session["token"] as string;
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var taskResponse = client.GetAsync("customer").Result;
                if (taskResponse.IsSuccessStatusCode)
                {
                    customers = taskResponse.Content.ReadAsAsync<CustomersResponse>().Result;
                }
                else
                {
                    return new CustomersResponse();
                }
                return customers;
            }
        }

        public static CustomerResponse GetCustomerById(int id)
        {
            CustomerResponse customers = new CustomerResponse();
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
                client.BaseAddress = new Uri(apiUrl);
                //string token = HttpContext.Current.Session["token"] as string;
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var taskResponse = client.GetAsync("customer/" + id).Result;
                if (taskResponse.IsSuccessStatusCode)
                {
                    customers = taskResponse.Content.ReadAsAsync<CustomerResponse>().Result;
                }
                else
                {
                    return new CustomerResponse();
                }
                return customers;
            }
        }

        public static void CreateCustomer(CustomerDTO customerDTO)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
                client.BaseAddress = new Uri(apiUrl);
                string token = HttpContext.Current.Session["token"] as string;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(customerDTO);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var taskResponse = client.PostAsync("customer", content).Result;
            }
        }

        public static void EditCustomer(CustomerDTO customerDTO)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
                client.BaseAddress = new Uri(apiUrl);
                string token = HttpContext.Current.Session["token"] as string;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(customerDTO);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var taskResponse = client.PutAsync("customer", content).Result;
            }
        }

        public static void DeleteCustomer(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
                client.BaseAddress = new Uri(apiUrl);
                string token = HttpContext.Current.Session["token"] as string;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var taskResponse = client.DeleteAsync("customer/" + id).Result;
            }
        }
    }
}