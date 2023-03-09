using ClientWCF.WCFServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientWCF
{
    internal class Program
    {   //for_review
        static void Main(string[] args)
        {
            InstanceContext instance = new InstanceContext(new CallBackHandler());
            Wcf_ServiseClient client = new Wcf_ServiseClient(instance);

            client.UpdateAndCompile(@"C:\Users\Alexander\Desktop\GeekBrains_2\Practice_part2\Practice_part2\Wcf_Service\Scripts\TestScript.txt");
            client.RunScript();

            Console.WriteLine("Нажмите любую клавишу для выхода");
            Console.ReadKey(true);
            client.Close();

        }
    }
}
