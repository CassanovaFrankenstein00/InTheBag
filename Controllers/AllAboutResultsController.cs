using Microsoft.AspNetCore.Mvc;

namespace InTheBag.Controllers
{
    public class AllAboutResultsController : Controller
    {
        public IActionResult Index()
        {
            var weekday = DateTime.Now.DayOfWeek;
            var day = weekday.ToString();
            var time = DateTime.Now.Hour;

            //day = "Wednesday";

            if (time <= 6)
            {
                ViewBag.Greeting = "It is too early to be up!";
            }
            else if (time <= 12)
            {
                ViewBag.Greeting = "Good morning!";
            }
            else if (time <= 18)
            {
                ViewBag.Greeting = "Good afternoon!";
            }
            else
            {
                ViewBag.Greeting = "Good evening!";
            }
            int route = 0;

            switch(day)
            {
                case "Monday":
                case "Tuesday":
                    route = 1;
                    ViewData["dayMessage"] = "The work week just started! Stay focused, you have a lor to do this week!";
                    break;
                case "Wednesday":
                    route = 2;
                    ViewData["dayMessage"] = "Halfway to the weekend!";
                    break;
                case "Thursday":
                    route = 3;
                    ViewData["dayMessage"] = "Isn't it friday somewhere?";
                    break;
                case "Friday":
                    route = 4;
                    ViewData["dayMessage"] = "Woo hoo TGIF!";
                    break;
                default:
                    ViewData["dayMessage"] = "Ahhhhh the weekend!";
                    route = 5;
                    break;
            }
            if (route == 1)
            {
                return RedirectToAction("Weekday", "AllAboutResults");
            }
            else if (route == 2 || route == 3)
            {
                return Redirect("https://lisabalbach.com/CIT218/chapter8/HappyWednesday.html");
            }
            else
            {
                return View();
            }
                
        }
        public IActionResult Weekday()
        {
            ViewBag.Greeting = "Congratulations, the work week just started and you have been rerouted!";
            return View();
        }
    }
}
