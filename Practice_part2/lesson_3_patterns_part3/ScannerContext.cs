using lesson_3_patterns_part3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_3_patterns_part3
{
    //for review
    public sealed class ScannerContext
    {
        private readonly IScannerDevice _device;
        private IScanOutputStrategy _currentStrategy;
        public ScannerContext(IScannerDevice device)
        {
            _device = device;
        }

        public void SetupOutputScanStrategy(IScanOutputStrategy strategy)
        {
            _currentStrategy = strategy;
        }

        public void Execute(string outputFileName = "")
        {
            if (_device is null)
            {
                throw new ArgumentNullException("Device can not be null");
            }
            if (_currentStrategy is null)
            {
                throw new ArgumentNullException("Current scan strategy can not be null");
            }
            if (string.IsNullOrWhiteSpace(outputFileName))
            {
                outputFileName = Guid.NewGuid().ToString();
            }
            _currentStrategy.ScanAndSave(_device, outputFileName);
        }
    }
}
