using System.Linq;
using System.Collections.Generic;
using OdeToFood.Core.Entities;
using OdeToFood.Core.Enums;
using OdeToFood.Data.Interfaces;

namespace OdeToFood.Data.Implementations
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant{ Id = 1, Name = "Scott's pizza", Location = "Maryland", CuisineType = CuisineType.Italian },
                new Restaurant{ Id = 2, Name = "Cinnanmon Club", Location = "London", CuisineType = CuisineType.Mexican },
                new Restaurant{ Id = 3, Name = "La costa", Location = "California", CuisineType = CuisineType.Mexican }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Restaurant GetById(int id)
        {
            return _restaurants.FirstOrDefault(restaurant => restaurant.Id == id);
        }

        /// <summary>
        /// Get all restaurants by name.
        /// </summary>
        /// <param name="name">Restaurant name.</param>
        /// <returns>A list of <see cref="Restaurant"/></returns>
        public IEnumerable<Restaurant> GetByName(string name)
        {
            return from restaurant in _restaurants
                where string.IsNullOrEmpty(name) || restaurant.Name.StartsWith(name)
                orderby restaurant.Name
                select restaurant;
        }
    }
}