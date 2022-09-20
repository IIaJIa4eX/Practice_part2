using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_3_patterns_part3.Interfaces
{
    public interface IScanOutputStrategy
    {
        public void ScanAndSave(IScannerDevice scannerDevice, string outputFileName);
    }
}
