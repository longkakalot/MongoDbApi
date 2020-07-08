using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMongoDb.Models;
using ApiMongoDb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _sinhVienContext;

        public AccountController(AccountService sinhVienContext)
        {
            _sinhVienContext = sinhVienContext;
        }

        [HttpPost]
        [Route("Login")]
        public List<Account> IsAuthenticated(Account objUser)
        {
            try
            {
                var list = _sinhVienContext.IsAuthenticate(objUser);
                //_logger.LogInformation("Xác thực thành công");
                return list;
            }
            catch (Exception ex)
            {
                //_logger.LogError($"IsAuthenticated: {ex}");
                return null;
            }            
        }
    }
}