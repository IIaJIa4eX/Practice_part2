using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TextSearch.Entities;
using Document = TextSearch.Entities.Document;

namespace TextSearch
{
        public class DbContextText : DbContext
        {
            public virtual DbSet<Document> Documents { get; set; }
            public virtual DbSet<Word> Words { get; set; }
            public virtual DbSet<WordDocument> WordDocuments { get; set; }
            public DbContextText(DbContextOptions options) : base(options) { }

        }
}
