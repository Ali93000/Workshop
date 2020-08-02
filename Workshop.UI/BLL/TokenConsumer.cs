using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using Workshop.UI.Models.Users;

namespace Workshop.UI.BLL
{
    public class TokenConsumer
    {
        public static string GetAccessToken(UserLoginInfoResponse userLoginInfo)
        {
            string accessToken = "";
            using (HttpClient client =new HttpClient())
            {
                string apiURL = ConfigurationManager.AppSettings["ApiUrl"];
                client.BaseAddress = new Uri(apiURL);
                string json = JsonConvert.SerializeObject(userLoginInfo);
                StringContent content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var result = client.PostAsync("users/token", content).Result;
                if (result.IsSuccessStatusCode)
                {
                    accessToken = result.Content.ReadAsAsync<string>().Result;
                }
                return accessToken;
            }
        }
    }
}