using api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ApiContextController : ControllerBase
    {



        public List<Kullanici> getAll()
        {
            using (ApiContextContext context = new ApiContextContext())
            {

                var results = context.Kullanicis.Select(x => new Kullanici
                {
                    KullaniciAdi = x.KullaniciAdi
                }).ToList();

                return results;
            }
        }



    }
}