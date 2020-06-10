using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleODataAPI.Models;
using SampleODataAPI.Data;

namespace SampleODataAPI.Services
{
    public class AccountRepository : IAccount
    {
        private AccountsDbContext accountsDbContext;
        public AccountRepository(AccountsDbContext _accountsDbContext)
        {
            accountsDbContext = _accountsDbContext;
        }
        public IQueryable<Account> GetAccounts()
        {
            return accountsDbContext.Accounts;
        }
    }
}
