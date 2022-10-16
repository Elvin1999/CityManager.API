using CityManager.API.Data;
using CityManager.API.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IAppRepository _appRepository;

        public CitiesController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }
        [HttpGet]
        public IActionResult GetCities()
        {
            var cities = _appRepository
                .GetCities()
                .Select(c => new CityForListDto
                {
                    Description = c.Description,
                    Id = c.Id,
                    Name = c.Name,
                    PhotoUrl = c.Photos.FirstOrDefault(p=>p.IsMain).Url,
                });
            return Ok(cities);
        }

    }
}
