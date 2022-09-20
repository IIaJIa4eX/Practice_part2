using lesson_3_patterns_part3.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_3_patterns_part3.Scanners
{
    public class HPScanner1 : IScannerDevice
    {

        public byte[] Scan()
        {

            Console.WriteLine("GettingBytes... HPScanner1");

            return new byte[10];
        }
    }
}
