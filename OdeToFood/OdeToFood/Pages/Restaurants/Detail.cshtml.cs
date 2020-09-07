using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Core.Entities;
using OdeToFood.Data.Interfaces;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        
        public Restaurant Restaurant { get; set; }
        
        [TempData]
        public string Message { get; set; }

        public DetailModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData ?? throw new ArgumentNullException(nameof(restaurantData));
        }
        
        public IActionResult OnGet(int restaurantId)
        {
            // OnGet method can work as Action, so it can return IActionResult
            Restaurant = _restaurantData.GetById(restaurantId);

            if (Restaurant == null) return RedirectToPage("NotFound");

            return Page();
        }
    }
}
