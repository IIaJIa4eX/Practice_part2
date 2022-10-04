using System;

namespace ScanFile
{
    //for review
    public class ScanHandler
    {
        private readonly byte[] _stream;
        public ScanHandler(byte [] stream)
        {
            _stream = stream;
        }


        public void SaveAsPDf()
        {
            Console.WriteLine("Saving as pdf...");
        }

        public void SaveAsPWord()
        {
            Console.WriteLine("Saving as word...");
        }

    }
}
