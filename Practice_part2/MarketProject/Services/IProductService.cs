using DataBaseDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.Services
{
    public interface IProductService
    {
       Task<Product> AddAsync(decimal price, string category, string name);
    }
}
