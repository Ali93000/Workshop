using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Entities.ApiModels.Customer
{
    public class CustomerReq
    {
        public int Id { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Mobil1 { get; set; }
        public string Mobil2 { get; set; }
        public string CustomerAddress { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Remarks { get; set; }
    }
}
