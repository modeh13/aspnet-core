using System.Linq;
using System.Collections.Generic;
using OdeToFood.Core.Entities;
using OdeToFood.Core.Enums;
using OdeToFood.Data.Interfaces;

namespace OdeToFood.Data.Implementations
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> _restaurants;

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
        /// Get all restaurants.
        /// </summary>
        /// <returns>A list of <see of="Restaurant"></returns>
        public IEnumerable<Restaurant> GetAll()
        {
            return from restaurant in _restaurants
                orderby restaurant.Name
                select restaurant;
        }
    }
}