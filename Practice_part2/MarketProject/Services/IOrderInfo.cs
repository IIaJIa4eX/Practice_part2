using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.Services
{
    public interface IOrderInfo
    {
        string OrderNumber { get; set; }
        string OrderDescription { get; set; }
        DateTime CreationDate { get; set; }

        IEnumerable<(int id, string name, string category, decimal price)> Products { get; set; }

        FileInfo Create(string reportTemplateFile);
    }
}
