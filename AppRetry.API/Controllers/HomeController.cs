using System;
using System.Globalization;
using System.Threading.Tasks;
using AppRetry.API.DTO;
using AppRetry.API.Infra.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppRetry.API.Controllers
{

    [Route("v1/api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// Return Version, Country, Machine Name, System.
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
                System = Environment.OSVersion.VersionString
            };
        }
    }
}