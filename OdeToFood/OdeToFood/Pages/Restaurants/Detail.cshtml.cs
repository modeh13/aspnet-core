using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core.Entities;
using OdeToFood.Data.Interfaces;
using System;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        public Restaurant Restaurant { get; set; }

        public DetailModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData ?? throw new ArgumentNullException(nameof(restaurantData));
        }

        public void OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetById(restaurantId);
        }
    }
}
