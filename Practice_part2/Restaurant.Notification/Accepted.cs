using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Notification
{
    [Flags]
    public enum Accepted
    {
        Kitchen = 1,
        Booking = 2,
        All = 3,
        RejectedKitchen = 4,
        RejectedBooking = 5,
        Rejected = 9

        
    }
}
