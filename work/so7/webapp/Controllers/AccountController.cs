using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webapp.Models;
using webapp.Services;

namespace webapp.Controllers
{
    [ApiController]
    [Route("api/[controller]/{number}")]
    public class AccountController : ControllerBase
    {
        public AccountController(JsonFileAccountService accountService)
        {
            AccountService = accountService;
        }

        public JsonFileAccountService AccountService { get; }

        [HttpGet]
        public string Get(int number)
        {
            
            Account account = AccountService.GetAccount(number);
            if(account == null)
                return  "{\"Code\" : 404, \"Message\" : \"Not Found\"}";
            else return account.ToString();
        }
    }
}
