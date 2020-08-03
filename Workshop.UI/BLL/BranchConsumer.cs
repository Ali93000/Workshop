using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using Workshop.UI.Models.Branch;

namespace Workshop.UI.BLL
{
    public class BranchConsumer
    {
        string ApiURL = "";
        public BranchConsumer()
        {
            ApiURL = ConfigurationManager.AppSettings["ApiUrl"];
        }

        public BranchesResponse GetAllBranchesForCompany(int? compId)
        {
            BranchesResponse branchesResponse = new BranchesResponse();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiURL);
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                var responseTask = client.GetAsync("branchs?compId="+ compId).Result;
                if (responseTask.IsSuccessStatusCode)
                {
                    branchesResponse = responseTask.Content.ReadAsAsync<BranchesResponse>().Result;
                    return branchesResponse;
                }
                else
                {
                    return new BranchesResponse();
                }
            }
        }
    }
}