using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleODataAPI.Models;
using SampleODataAPI.Data;
using SampleODataAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.OData;

namespace SampleODataAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class AccountsController : ODataController
    {
        private IAccount accountsRepo;
        public AccountsController(IAccount _accountsRepo)
        {
            accountsRepo = _accountsRepo;
        }
        [HttpGet]
        [EnableQuery]
        public IQueryable<Account> Get()
        {
            return accountsRepo.GetAccounts();
        }
    }
}
