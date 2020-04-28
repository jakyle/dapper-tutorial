using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dapper_tutorial.Models;
using dapper_tutorial.Repository;

namespace dapper_tutorial.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICoffeeRepository _coffeeRepository;

        public HomeController(ICoffeeRepository coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Coffees()
        {
            var model = new CoffeesViewModel();

            model.Coffees = _coffeeRepository.SelectAllCoffees()
                .Select(dbo => new CoffeeNameAndId { Name = dbo.Name, ID = dbo.ID })
                .ToList();

            return View(model);
        }

        public IActionResult AddCoffee()
        {
            var model = new CoffeesViewModel();

            return View(model);
        }

        public IActionResult InsertCoffee()
        {
            var model = new CoffeesViewModel();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
