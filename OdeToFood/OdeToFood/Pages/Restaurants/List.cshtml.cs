using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core.Entities;
using OdeToFood.Data.Interfaces;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IRestaurantData _restaurantData;
        private readonly ILogger<ListModel> _logger;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration configuration,
                         IRestaurantData restaurantData,
                         ILogger<ListModel> logger)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _restaurantData = restaurantData ?? throw new ArgumentNullException(nameof(restaurantData));
            _logger = logger;
        }

        // ASP.NET Core will map the parameter searchTerm from the View using the name attribute of input.
        //public void OnGet(string searchTerm)
        //{
        //    Message = _configuration["Message"];
        //    Restaurants = _restaurantData.GetByName(searchTerm);
        //}

        public void OnGet()
        {
            _logger.LogError("Executing ListModel");
            Message = _configuration["Message"];
            Restaurants = _restaurantData.GetByName(SearchTerm);
        }
    }
}
