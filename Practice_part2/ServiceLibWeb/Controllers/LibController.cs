using LibraryServiceReference;
using Microsoft.AspNetCore.Mvc;
using ServiceLibWeb.Models;

namespace ServiceLibWeb.Controllers
{
    public class LibController : Controller
    {
        public IActionResult Index(SearchType searchType, string searchString)
        {
            TestWebServiceSoapClient client =
                new TestWebServiceSoapClient(TestWebServiceSoapClient.EndpointConfiguration.TestWebServiceSoap);

            if (!string.IsNullOrEmpty(searchString) && searchString.Length >= 3)
                switch (searchType)
                {
                    case SearchType.Title:
                        return View(new BookCategoryViewModel() { Books = client.GetBooksByTitle(searchString) });
                    case SearchType.Category:
                        return View(new BookCategoryViewModel() { Books = client.GetBooksByCategory(searchString) });
                    case SearchType.Author:
                        return View(new BookCategoryViewModel() { Books = client.GetBooksByAuthor(searchString) });
                }

            return View(new BookCategoryViewModel() { Books = new Book[] { } });
        }
    }
}
