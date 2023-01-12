using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ServiceLibWeb.Models
{    //for review

    public enum SearchType
    {
        [Display(Name = "Заголовок")]
        Title,
        [Display(Name = "Автор")]
        Author,
        [Display(Name = "Категория")]
        Category
    }
}
