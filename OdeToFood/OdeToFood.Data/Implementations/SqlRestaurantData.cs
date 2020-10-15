using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core.Entities;
using OdeToFood.Data.Interfaces;

namespace OdeToFood.Data.Implementations
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext _odeToFoodDbContext;

        public SqlRestaurantData(OdeToFoodDbContext odeToFoodDbContext)
        {
            _odeToFoodDbContext = odeToFoodDbContext;
        }

        public int Commit()
        {
            return _odeToFoodDbContext.SaveChanges();
        }

        public Restaurant Create(Restaurant restaurant)
        {
            _odeToFoodDbContext.Add(restaurant);
            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);

            if (restaurant != null) _odeToFoodDbContext.Restaurants.Remove(restaurant);

            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return _odeToFoodDbContext.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetByName(string name)
        {
            var restaurants = from restaurant in _odeToFoodDbContext.Restaurants
                              where restaurant.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                              orderby restaurant.Name
                              select restaurant;

            return restaurants;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = _odeToFoodDbContext.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;

            return updatedRestaurant;
        }

        public int GetCount()
        {
            return _odeToFoodDbContext.Restaurants.Count();
        }
    }
}
