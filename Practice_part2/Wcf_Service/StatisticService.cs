using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wcf_Service.Interfaces;

namespace Wcf_Service
{
    public class StatisticService : IStatisticService
    {
        public int SuccessTasks { get; set; }
        public int ErrorTasks { get; set; }
        public int AllTasks { get; set; }
    }
}