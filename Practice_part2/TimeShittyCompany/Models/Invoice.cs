using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeShittyCompany.Models
{
    //_for review
    public class Invoice
    {
        public Guid Id { get; private set; }
        public DateTime Registered { get; private set; }
        public int Amount { get; private set; }

        public List<Sheet> Sheets { get; set; }


        public void Create(int amount)
        {

            Amount = amount;
            Id = Guid.NewGuid();
            Registered = DateTime.Now;
        }


        public void IncludeOneSheet(Sheet sheet)
        {
            if (sheet != null)
            {
                Sheets.Add(sheet);
            }
        }

        public void IncludeSheets(List<Sheet> sheetsToInclude)
        {
            if (sheetsToInclude != null)
            {
                foreach (Sheet item in sheetsToInclude)
                {
                    Sheets.Add(item);
                }
            }
        }

    }
}
