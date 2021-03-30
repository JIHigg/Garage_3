using Garage_3.Data;
using Garage_3.Models;
using Garage_3.Models.ViewModel;
using Garage_3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Garage_3Context _dbGarage_3;
        private readonly IMailService mService;

        public HomeController(ILogger<HomeController> logger, Garage_3Context context, IMailService mailService)
        {
            _logger = logger;
            _dbGarage_3 = context;
            mService = mailService;
        }

        public async Task<IActionResult> Index()
        {
            GetMessageFromTempData();

            HomeViewModel viewModel = new HomeViewModel();
            var garage = await _dbGarage_3.Garage.FirstOrDefaultAsync();
            if (garage != null)
            {
                int iNumberOfOccupiedParkingPlaces = await _dbGarage_3.ParkingPlace.Where(g => g.GarageId == garage.GarageId && g.IsOccupied).CountAsync();
                viewModel.GarageName = garage.GarageName;
                viewModel.NumberOfParkingPlaces = garage.NumberOfParkingPlaces;
                viewModel.NumberOfVehiclesInGarage = iNumberOfOccupiedParkingPlaces;
            }

            return View(viewModel);
           
        }

        public IActionResult About()
        {
            return View();
        }

        //GET
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        //POST

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                mService.SendMessage("abc@outlook.com", model.Subject, $"From: {model.FullName} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Your Mail has been sent succesfully!";
                ModelState.Clear();
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void GetMessageFromTempData()
        {
            var messageObject = TempData["message"];
            if (messageObject != null)
                ViewBag.Message = messageObject as string;

            var typeOfMessageObject = TempData["typeOfMessage"];
            if (typeOfMessageObject != null)
                ViewBag.TypeOfMessage = typeOfMessageObject as string;
            else
                ViewBag.TypeOfMessage = "info";
        }
    }
}
