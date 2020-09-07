using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core.Entities;
using OdeToFood.Core.Enums;
using OdeToFood.Data.Interfaces;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData,
                         IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData ?? throw new ArgumentNullException(nameof(restaurantData));
            _htmlHelper = htmlHelper ?? throw new ArgumentNullException(nameof(htmlHelper));

            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
        }

        public IActionResult OnGet(int? restaurantId)
        {
            Restaurant = restaurantId.HasValue ?
                _restaurantData.GetById(restaurantId.Value) : 
                new Restaurant();
            
            if (Restaurant == null) return RedirectToPage("NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            // PGR - Post-Get-Redirect pattern.
            if (ModelState.IsValid)
            {
                Restaurant = Restaurant.Id > 0 ?
                    _restaurantData.Update(Restaurant) :
                    _restaurantData.Create(Restaurant);

                _restaurantData.Commit();

                TempData["Message"] = "Restaurant saved!";
                return RedirectToPage("./Detail", new {restaurantId = Restaurant.Id});
            }
            
            return Page();
        }
    }
}