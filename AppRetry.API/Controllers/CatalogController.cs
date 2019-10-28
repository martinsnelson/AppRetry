

using System;
using System.Threading.Tasks;
using AppRetry.API.Interfce.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppRetry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private ICatalogService _iCatalogService;
        private ILogger _iLogger;

        public CatalogController(ICatalogService iCatalogService, ILogger iLogger)
        {
            _iCatalogService = iCatalogService;
            _iLogger = iLogger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetPage()
        {
            try
            {
                var pageContent = await _iCatalogService.GetPage();

                Console.WriteLine(pageContent.Substring(0, 500));
            }
            catch (Exception ex)
            {
                _iLogger.LogError(ex.ToString());
            }

            return Ok();
        }


        [Route("GetCatalogItems")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCatalogItems(int? BrandFilterApplied, int? TypesFilterApplied, int? page, [FromQuery]string errorMsg)
        {
            var itemsPage = 10;
            var catalog = await _iCatalogService.GetCatalogItems(page ?? 0, itemsPage, BrandFilterApplied, TypesFilterApplied);
            //… Additional code
            return Ok();
        }

    }
}