using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleODataAPI.Models;

namespace SampleODataAPI.Services
{
    public interface IAccount
    {
        // CRUD operations
        IQueryable<Account> GetAccounts();
    }
}
