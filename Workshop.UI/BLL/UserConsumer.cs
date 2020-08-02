using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using Workshop.UI.Models.Category;
using Workshop.UI.Models.Users;

namespace Workshop.UI.BLL
{
    public class UserConsumer
    {
        string ApiURL = "";
        public UserConsumer()
        {
            ApiURL = ConfigurationManager.AppSettings["ApiUrl"];
        }

        public CategoriesResponse Login()
        {
            CategoriesResponse categoriesResponse = new CategoriesResponse();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiURL);
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                //HTTP GET
                var responseTask = client.GetAsync("category");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CategoriesResponse>();
                    readTask.Wait();

                    categoriesResponse = readTask.Result;
                    return categoriesResponse;
                }
                else //web api sent error response 
                {
                    //log response status here..
                    return new CategoriesResponse();
                }
            }
        }
    }
}