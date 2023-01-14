using ClientWCF.WCFServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWCF
{
    public class CallBackHandler : IWcf_ServiseCallback
    {
        public void UpdateStatistics(StatisticService stats)
        {
            Console.Clear();
            Console.WriteLine("Инфо");
            Console.WriteLine($"Errors: {stats.ErrorTasks}");
            Console.WriteLine($"Succss: {stats.SuccessTasks}");
            Console.WriteLine($"AllTasks: {stats.AllTasks}");

        }
    }
}
