using System.Collections.Generic;
using OdeToFood.Core.Entities;

namespace OdeToFood.Data.Interfaces
{
    public interface IRestaurantData
    {
        Restaurant GetById(int id);

        IEnumerable<Restaurant> GetByName(string name);

        Restaurant Create(Restaurant restaurant);

        Restaurant Update(Restaurant updatedRestaurant);

        Restaurant Delete(int id);

        int GetCount();

        int Commit();
    }
}