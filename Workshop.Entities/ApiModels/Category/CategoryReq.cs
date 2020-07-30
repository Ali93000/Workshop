using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Entities.ApiModels.Category
{
    public class CategoryReq
    {
        public int Id { get; set; }
        public string CategoryNameAr { get; set; }
        public string CategoryNameEn { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
