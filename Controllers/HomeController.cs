using Garage_3.Data;
using Garage_3.Models;
using Garage_3.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace Garage_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Garage_3Context _dbGarage_3;

        public HomeController(ILogger<HomeController> logger, Garage_3Context context)
        {
            _logger = logger;
            _dbGarage_3 = context;
        }

        public IActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();
            var garage = _dbGarage_3.Garage.FirstOrDefault();
            if (garage != null)
            {
                viewModel.GarageName = garage.GarageName;
                viewModel.NumberOfParkingPlaces = garage.NumberOfParkingPlaces;
                //viewModel.NumberOfVehiclesInGarage = _dbGarage_3.Vehicle.Count();
                //viewModel.Personnummer = _dbGarage_3.Personnummer;
            }

            return View(viewModel);
           
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
