using lesson_3_patterns_part3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_3_patterns_part3
{
    //for review
    public sealed class WordScanOutputStrategy : IScanOutputStrategy
    {
        public void ScanAndSave(IScannerDevice scannerDevice, string outputFileName)
        {
            scannerDevice.Scan();
            Console.WriteLine($"File{outputFileName} saved!");
        }
    }
}
