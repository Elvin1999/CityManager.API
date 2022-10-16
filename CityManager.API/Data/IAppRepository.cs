﻿using CityManager.API.Models;

namespace CityManager.API.Data
{
    public interface IAppRepository
    {
        void Add<T>(T entity) where T:class;
        void Delete<T>(T entity) where T:class;
        bool SaveAll();

        List<City> GetCities();
        List<Photo> GetPhotosByCityId(int cityId);
        City GetCityById(int cityId);
        Photo GetPhotoById(int photoId);

    }
}
