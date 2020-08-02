using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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

        public UserLoginInfoResponse Login(UserLogin userLogin)
        {
            UserLoginInfoResponse userLoginInfoResponse = new UserLoginInfoResponse();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiURL);
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                //HTTP POST
                var json = JsonConvert.SerializeObject(userLogin);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var responseTask = client.PostAsync("users/login", stringContent);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UserLoginInfoResponse>();
                    readTask.Wait();

                    userLoginInfoResponse = readTask.Result;
                    return userLoginInfoResponse;
                }
                else //web api sent error response 
                {
                    //log response status here..
                    return new UserLoginInfoResponse();
                }
            }
        }
    }
}