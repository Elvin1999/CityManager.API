using AutoMapper;
using CityManager.API.Data;
using CityManager.API.Dtos;
using CityManager.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IAppRepository _appRepository;
        private IMapper _mapper;

        public CitiesController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetCities()
        {
            //var cities = _appRepository
            //    .GetCities()
            //    .Select(c => new CityForListDto
            //    {
            //        Description = c.Description,
            //        Id = c.Id,
            //        Name = c.Name,
            //        PhotoUrl = c.Photos.FirstOrDefault(p=>p.IsMain).Url,
            //    });


            var cities = _appRepository.GetCities();
            var citiesToReturn = _mapper.Map<List<CityForListDto>>(cities);
            return Ok(citiesToReturn);
        }


        [HttpPost]
        [Route("add")]
        public IActionResult Add(City city)
        {
            _appRepository.Add(city);
            _appRepository.SaveAll();
            return Ok(city);
        }

        [HttpGet]
        [Route("detail")]
        public IActionResult GetCityById(int id)
        {
            var city = _appRepository.GetCityById(id);
            var cityToReturn = _mapper.Map<CityForDetailDto>(city);

            return Ok(cityToReturn);
        }

        [HttpGet]
        [Route("Photos")]
        public IActionResult GetPhotosByCityId(int cityId)
        {
            var photos=_appRepository.GetPhotosByCityId(cityId);
            return Ok(photos);
        }

    }
}
