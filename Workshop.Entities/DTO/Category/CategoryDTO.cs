using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Entities.DTO.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string CategoryNameAr { get; set; }
        public string CategoryNameEn { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
