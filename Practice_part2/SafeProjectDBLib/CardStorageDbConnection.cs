using Microsoft.EntityFrameworkCore;
using SafeProjectDBLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeProjectDBLib
{
    public  class CardStorageDbConnection : DbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public DbSet<AccountSession> AccountSessions { get; set; }

        public CardStorageDbConnection(DbContextOptions options) : base(options) { }
        
    }
}
