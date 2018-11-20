using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

        //static private Dictionary<string, string> Cheeses = new Dictionary<string, string>();
        static private List<Cheese> Cheeses = new List<Cheese>();
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.cheeses = Cheeses;
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(string name, string description)
        {
            Cheese newCheese = new Cheese(name, description);
            // Add the new cheese to my existing cheeses
            Cheeses.Add(newCheese);
            return Redirect("/Cheese");
        }

        public IActionResult Delete()
        {
            ViewBag.cheeses = Cheeses;
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Delete")]
        public IActionResult DeleteCheese(string[] cheeseToDelete)
        {
            foreach (string cheese in cheeseToDelete)
            {
                for (int i=0; i<Cheeses.Count; i++)
                {
                    if (Cheeses[i].Name == cheese)
                        Cheeses.Remove(Cheeses[i]);
                }

                
            }
            return Redirect("/Cheese");

        }
    }
}
