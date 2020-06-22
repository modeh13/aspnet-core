using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Data.Interfaces;

namespace MyApp.Namespace
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IRestaurantData _restaurantData;

        public string Message { get; set; }

        public ListModel(IConfiguration configuration,
                         IRestaurantData restaurantData)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _restaurantData = restaurantData ?? throw new ArgumentNullException(nameof(restaurantData));
        }

        public void OnGet()
        {
            Message = _configuration["Message"];
        }
    }
}
