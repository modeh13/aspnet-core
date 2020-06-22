using System.Collections.Generic;
using OdeToFood.Core.Entities;

namespace OdeToFood.Data.Interfaces
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }
}