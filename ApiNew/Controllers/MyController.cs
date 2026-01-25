using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;
namespace ApiNew.Controllers
{
    [Route("api/[controller]/[action]"  )]
    [ApiController]
    public class SelectController : ControllerBase
    {
        [HttpGet]
        [ActionName("CitySelector")]

        public CityList SelectAllCities()
        {
            CityDB dB = new CityDB();
            CityList cities = dB.SelectAll(); 
            return cities;
        }
    }
}