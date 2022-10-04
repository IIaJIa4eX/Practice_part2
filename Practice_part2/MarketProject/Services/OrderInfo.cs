using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateEngine.Docx;

namespace MarketProject.Services
{
    //for_review
    class OrderInfo : IOrderInfo
    {

        private const string _FieldOrderNumber = "OrderNumber";
        private const string _FieldOrderDescription = "OrderDescription";
        private const string _FieldCreationDate = "CreationDate";


        private const string _FieldProduct = "Product";

        private const string _FieldProductId = "ProductId";
        private const string _FieldProductName = "ProductName";
        private const string _FieldProductCategory = "ProductCategory";
        private const string _FieldProductPrice = "ProductPrice";
        private const string _FieldProductTotal = "ProductTotal";


        private readonly FileInfo _templateFile;


        public DateTime CreationDate { get; set; }
        public IEnumerable<(int id, string name, string category, decimal price)> Products { get; set; }
        public string OrderNumber { get; set; } = null;
        public string OrderDescription { get; set; }

        public OrderInfo(string templateFile)
        {
            _templateFile = new FileInfo(templateFile);
        }

      


        public FileInfo Create(string reportFilePath)
        {
            if (!_templateFile.Exists)
                throw new FileNotFoundException();

            var reportFile = new FileInfo(reportFilePath);
            reportFile.Delete();
            _templateFile.CopyTo(reportFile.FullName);

            var rows = Products.Select(product => new TableRowContent(new List<FieldContent>
            {
                new FieldContent(_FieldProductId, product.id.ToString()),
                new FieldContent(_FieldProductName, product.name),
                new FieldContent(_FieldProductCategory, product.category),
                new FieldContent(_FieldProductPrice, product.price.ToString())


            })).ToArray();

            var content = new Content(
                new FieldContent(_FieldOrderNumber, OrderNumber),
                new FieldContent(_FieldOrderDescription, OrderDescription),
                new FieldContent(_FieldCreationDate, CreationDate.ToString("dd.MM.yyyy HH:mm:ss")),
                TableContent.Create(_FieldProduct, rows),
                new FieldContent(_FieldProductTotal, Products.Sum(product => product.price).ToString("c"))
                );

            using (var templateProcessor = new TemplateProcessor(reportFile.FullName).SetRemoveContentControls(true))
            {
                templateProcessor.FillContent(content);
                templateProcessor.SaveChanges();
                reportFile.Refresh();
                return reportFile;
            }
        }
    }
}
