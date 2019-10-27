using System;
using System.Globalization;
using System.Threading.Tasks;
using AppRetry.API.DTO;
using AppRetry.API.Infra.Context;
using AppRetry.API.Infra.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppRetry.API.Controllers
{

    [Route("v1/api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserRepository _iUserRepository;
        
        public HomeController(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }


        /// <summary>
        /// Return Version, Pais, Machine Name, Sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object get()
        {
            return new
            {
                Version = "0.0.1",
                CultureInfo = CultureInfo.CurrentCulture.DisplayName,
                Environment.MachineName,
                Sistema = Environment.OSVersion.VersionString
            };
        }
    }
}