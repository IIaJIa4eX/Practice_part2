using LibraryServiceReference;

namespace ServiceLibWeb.Models
{
    public class BookCategoryViewModel
    {    //for review

        public Book[] Books { get; set; }
        public SearchType SearchType { get; set; }
        public string? SearchString { get; set; }
    }
}
