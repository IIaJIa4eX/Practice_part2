using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wcf_Service.Interfaces
{
    public interface IStatisticService
    {
        int SuccessTasks { get; set; }

        int ErrorTasks { get; set; }

        int AllTasks { get; set; }
    }
}
