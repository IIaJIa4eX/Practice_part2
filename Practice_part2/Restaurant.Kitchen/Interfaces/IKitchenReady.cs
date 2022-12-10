using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Kitchen.Inerfaces
{
    public interface IKitchenReady
    {
        public Guid OrderId { get; set; }

        public bool isReady { get; set; }
    }
}
