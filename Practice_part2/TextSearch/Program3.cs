using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextSearch.Services.Impl;

namespace TextSearch
{
    public class Program3
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

                    #endregion


                })
                .Build();


            //FullTextIndexV1 fullTextIndexV1 = new FullTextIndexV1(host.Services.GetService<DbContextText>());
            //fullTextIndexV1.BuildIndex();
            BenchmarkSwitcher.FromAssembly(typeof(Program3).Assembly).Run(args, new BenchmarkDotNet.Configs.DebugInProcessConfig());
            BenchmarkRunner.Run<SearchBenchmarkV2>();
        }

        [MemoryDiagnoser]
        [WarmupCount(1)]
        [IterationCount(5)]
        public class SearchBenchmarkV2
        {

            public readonly FullTextIndexV3 _index;
            public readonly string[] _documentsSet;

            [Params("girls", "for", "Russia")]
            public string Query { get; set; }

            public SearchBenchmarkV2()
            {
                _documentsSet = DocumentExtractor.DocumentsSet().Take(10000).ToArray();
                _index = new FullTextIndexV3();
                foreach (var item in _documentsSet)
                    _index.AddStringToIndex(item);

            }

            [Benchmark(Baseline = true)]
            public void SimpleSearch()
            {
                new SimpleSearcherV2().SearchV3(Query, _documentsSet).ToArray();
            }

            [Benchmark]
            public void FullTextIndexSearch()
            {
                _index.SearchTest(Query).ToArray();
            }

        }
    }
}
