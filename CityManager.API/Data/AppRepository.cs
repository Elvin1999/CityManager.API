﻿using CityManager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CityManager.API.Data
{
    public class AppRepository : IAppRepository
    {
        private DataContext _context;

        public AppRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public List<City> GetCities()
        {
            var cities=_context
                .Cities
                .Include(p=>p.Photos)
                .ToList();

            return cities;
        }

        public City GetCityById(int cityId)
        {
            var city=_context
                .Cities
                .Include(_p => _p.Photos)
                .FirstOrDefault(c=>c.Id == cityId);
            return city;
        }

        public Photo GetPhotoById(int photoId)
        {
            var photo=_context
                .Photos.FirstOrDefault(p=>p.Id == photoId); 
            return photo;
        }

        public List<Photo> GetPhotosByCityId(int cityId)
        {
            var photos = _context
                .Photos
                .Where(p => p.CityId == cityId)
                .ToList();
            return photos;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
