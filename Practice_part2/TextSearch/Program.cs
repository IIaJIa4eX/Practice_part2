using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TextSearch.Services;
using TextSearch.Services.Impl;

namespace TextSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services => {

                    #region Configure EF DBContext Service (CardStorageService Database)

                    services.AddDbContext<DbContextText>(options =>
                    {
                        options.UseSqlServer(@"data source=DESKTOP-J3Q493L\SQLEXPRESS;initial catalog=TextSearch;MultipleActiveResultSets=True;App=EntityFramework;Trusted_Connection=True;");
                    });

                    #endregion

                    #region Configure Repositories

                    services.AddTransient<IDocumentRepository, DocumentRepository>();

                    #endregion


                })
                .Build();

            // Сохраним документы в БД
            //host.Services.GetRequiredService<IDocumentRepository>().LoadDocuments();
        }
    }
}