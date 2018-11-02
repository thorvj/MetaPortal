using MetaPortal.Models;
using MetaPortal.Services;
using Microsoft.AspNetCore.Mvc;
using MetaPortal.ViewModels;

namespace MetaPortal.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = "ISI Portal";
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        /*
        public IActionResult Create(int id, string name)
        {
            var model = _restaurantData.Create(id, name);            
            return View(model);
        }
        */
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            if(ModelState.IsValid)
            { 
                var newRestaurant = new Restaurant();
                newRestaurant.Name = model.Name;
                newRestaurant.Status = model.Status;
                newRestaurant = _restaurantData.Add(newRestaurant);
                return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });
            }
            else
            {
                return View();
            }
        }
    }
}