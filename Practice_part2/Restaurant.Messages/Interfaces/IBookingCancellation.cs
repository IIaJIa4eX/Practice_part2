using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Messages.Interfaces
{
    public interface IBookingCancellation
    {

        public Guid OrderId { get; }

        public Guid ClientId { get; }

        public DateTime CancellationDate { get; set; }
    }
}
