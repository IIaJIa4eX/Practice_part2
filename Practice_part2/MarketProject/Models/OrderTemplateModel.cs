using DataBaseDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.Models
{
    //for_review
    public class OrderTemplateModel
    {
        public string OrderNumber { get; set; } = null!;

        public DateTime CreationDate { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public int Total { get; set; }
    }
}
