using lesson_3_patterns_part3.Scanners;
using ScanFile;
using System;
using System.Threading;

namespace lesson_3_patterns_part3
{
    class Program
    {
        static void Main(string[] args)
        {

            ScannerContext pdfContext = new ScannerContext(new HPScanner1());
            pdfContext.SetupOutputScanStrategy(new PdfScanOutputStrategy());
            pdfContext.Execute("PdfFile!");
            ScannerContext wordContext = new ScannerContext(new HPScanner2());
            wordContext.SetupOutputScanStrategy(new WordScanOutputStrategy());
            wordContext.Execute("WordFile!");

            Thread.Sleep(3000);

            ScanHandler scan1 = new ScanHandler(new HPScanner1().Scan());
            scan1.SaveAsPDf();

            ScanHandler scan2 = new ScanHandler(new HPScanner2().Scan());
            scan2.SaveAsPWord();

        }
    }
}
