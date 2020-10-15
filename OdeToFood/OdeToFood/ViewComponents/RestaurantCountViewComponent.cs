using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data.Interfaces;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData _restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            var restaurantsCount = _restaurantData.GetCount();

            return View(restaurantsCount);
        }
    }
}
