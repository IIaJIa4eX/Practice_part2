using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Booking
{
    public class BookingRequestModel
    {

        public Guid OrderId { get; private set; }

        public Guid ClientId { get; private set; }

        public DateTime CreationDate { get; set; }
        public string messageID { get; set; }

        private List<string> _messagesIDs = new List<string>();
        //To DO
        public BookingRequestModel(Guid orderId, Guid clientId, DateTime creationDate, string messID)
        {
            _messagesIDs.Add(messID);
            OrderId = orderId;
            ClientId = clientId;
            CreationDate = creationDate;
        }

        public BookingRequestModel Update(BookingRequestModel model, string messageID)
        {
            _messagesIDs.Add(messageID);
            OrderId = model.OrderId;
            ClientId = model.ClientId;
            CreationDate = model.CreationDate;

            return this;
        }

        public bool CheckId(string messageId)
        {
            return _messagesIDs.Contains(messageId);
        }
    }
}
