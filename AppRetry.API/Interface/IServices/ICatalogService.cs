using System.Threading.Tasks;
using AppRetry.API.Entities;

namespace AppRetry.API.Interfce.IServices
{
    public interface ICatalogService
    {
        Task<string> GetPage();
        Task<Catalog> GetCatalogItems(int page, int take, int? brand, int? type);
     }
}