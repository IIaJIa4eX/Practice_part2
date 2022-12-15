using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Booking
{
    //for__review
    public interface IBookingExpire
    {
        public Guid OrderId { get; }
    }
}
