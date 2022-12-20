using MassTransit;
using Restaurant.Kitchen.Inerfaces;
using Restaurant.Messages;
using Restaurant.Messages.Interfaces;


namespace Restaurant.Booking.Consumers
{
    //for__review
    public class RestaurantBookingRequestConsumer : IConsumer<IBookingRequest>
    {
        private readonly RestaurantPlace _restaurant;
        private readonly IInMemoryRepository<BookingRequestModel> _repository;

        public RestaurantBookingRequestConsumer(RestaurantPlace restaurant, IInMemoryRepository<BookingRequestModel> repository)
        {
            _restaurant = restaurant;
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<IBookingRequest> context)
        {
            //for testing
            var rep = _repository.Get();
            var model = _repository.Get().FirstOrDefault(i => i.OrderId == context.Message.OrderId);
            
            if(model != null && model.CheckId(context.Message.OrderId.ToString()))
            {
                Console.WriteLine($"{context.MessageId} Это сообщение уже приходило");
                Console.WriteLine($"Номер заказа {context.Message.OrderId}");
                return;
            }


            var requestModel = new BookingRequestModel(context.Message.OrderId, context.Message.ClientId, context.Message.CreationDate, context.MessageId.ToString());


            Console.WriteLine($"{context.MessageId} Сообщение пришло первый раз!");
            Console.WriteLine($"Заказ прилетел {context.Message.OrderId}");

            var resultModel = model?.Update(requestModel, context.MessageId.ToString()) ?? requestModel;

            _repository.AddOrUpdate(resultModel);
            
            var result = await _restaurant.BookFreeTableAsync(1);
            
            if(result == null )
            {
                throw new Exception("Столов для заказа нет!");
            }

            await context.Publish<ITableBooked>(new TableBooked(context.Message.OrderId, context.Message.ClientId, result ?? false));
        }
    }
}
