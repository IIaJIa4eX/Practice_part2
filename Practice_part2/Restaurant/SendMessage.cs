using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    //for review
    public class SendMessage
    {
        public SendMessage()
        {

        }

        public void SendMessageAsync(string message)
        {
            Task.Run(async () =>
            {
                   await Task.Delay(1000 * 5);
                   Console.WriteLine(message);
            });
        }

    }
}
