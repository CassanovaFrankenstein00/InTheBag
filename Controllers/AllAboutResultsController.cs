using System;
using Microsoft.AspNetCore.Http;
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
                HttpContext.Session.SetString("greet", "It is too early to be up!");
            }
            else if (time <= 12)
            {
                HttpContext.Session.SetString("greet", "Good morning!");
            }
            else if (time <= 18)
            {
                HttpContext.Session.SetString("greet", "Good afternoon!");
            }
            else
            {
                HttpContext.Session.SetString("greet", "Good evening!");
            }
            int route = 0;

            switch(day)
            {
                case "Monday":
                case "Tuesday":
                    HttpContext.Session.SetString("dayMsg", "The work week just started! Stay focused, you have a lor to do this week!");
                    route = 1;
                    break;
                case "Wednesday":
                    route = 2;
                    HttpContext.Session.SetString("dayMsg", "Halfway to the weekend!");
                    break;
                case "Thursday":
                    route = 3;
                    HttpContext.Session.SetString("dayMsg", "Isn't it friday somewhere?");
                    break;
                case "Friday":
                    route = 4;
                    HttpContext.Session.SetString("dayMsg", "Woo hoo TGIF!");
                    break;
                default:
                    HttpContext.Session.SetString("dayMsg", "Ahhhhh the weekend!");
                    route = 5;
                    break;
            }
            //route=4;
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
            HttpContext.Session.SetString("greet", "Congratulations, the work week just started and you have been rerouted!");
            return View();
        }
    }
}
