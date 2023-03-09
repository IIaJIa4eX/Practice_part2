using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Wcf_Service.Interfaces
{
    //for_review
    [ServiceContract]
    public interface IWcf_Callback
    {
        [OperationContract]
        void UpdateStatistics(StatisticService stats);
    }
}
