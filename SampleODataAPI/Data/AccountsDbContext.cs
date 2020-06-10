using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleODataAPI.Models;

namespace SampleODataAPI.Data
{
    public class AccountsDbContext : DbContext
    {
        public AccountsDbContext(DbContextOptions<AccountsDbContext> options) : base(options)
        { }
        public DbSet<Account> Accounts { get; set; }
    }
}
