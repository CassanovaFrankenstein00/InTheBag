using InTheBag.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;


namespace InTheBag.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexViewBag()
        {
            IList<string> WishList = new List<string>();
            WishList.Add("Peace");
            WishList.Add("Health");
            WishList.Add("Happiness");
            ViewBag.WishList = WishList;
            return View();
        }
        public IActionResult IndexViewData()
        {
            IList<string> WishList = new List<string>();
            WishList.Add("Quies");
            WishList.Add("Salutem");
            WishList.Add("Beatitudinem");
            ViewData["WishList"] = WishList;
            return View();
        }
        public IActionResult IndexTempData()
        {
            IList<string> WishList = new List<string>();
            WishList.Add("Paz");
            WishList.Add("Salud");
            WishList.Add("Felicidad");
            TempData["WishList"] = WishList;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult WishIndex()
        {
            Wishes myWishes = new Wishes { ID=1, wish1="Healthy", wish2="Wealthy", wish3="Wise" };
            string jsonWishes = JsonSerializer.Serialize(myWishes);
            HttpContext.Session.SetString("wish", jsonWishes);
            return View();
        }
        public IActionResult NewWishIndex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewWishIndex(int? ID)
        {
            Wishes myWishes = new Wishes
            {
                ID = 2,
                wish1 = Request.Form["Wish1"],
                wish2 = Request.Form["Wish2"],
                wish3 = Request.Form["Wish3"]

            };
            string jsonWishes = JsonSerializer.Serialize(myWishes);
            HttpContext.Session.SetString("wish", jsonWishes);
            return View("WishIndex");
        }
        /*[HttpPost]
        public IActionResult NewWishIndex(Wishes model)
        {
            Wishes myWishes = new Wishes { ID = 2, wish1 = model.wish1, wish2 = model.wish2, wish3 = model.wish3 };
            string jsonWishes = JsonSerializer.Serialize(myWishes);
            HttpContext.Session.SetString("wish", jsonWishes);
            return View("WishIndex");
        }*/
        // type Genie/Create2/name/age/yearsExperience
        // example: /Genie/Create2/Lisa/33/3343
        public IActionResult Create2()
        {
            var name = RouteData.Values["GenieName"];
            var Years = Int32.Parse((string)RouteData.Values["Age"]);
            var numGranted = Int32.Parse((string)RouteData.Values["WishesGranted"]);

            if (numGranted > 5000 || Years > 1000)
                return View("ExperiencedGenie");
            else
                return View("Novice");
        }
    }
}