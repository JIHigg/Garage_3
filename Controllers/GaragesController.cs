using Garage_3.Data;
using Garage_3.Models.Entites;
using Garage_3.Models;
using Garage_3.ViewModels;
using Garage_3.ViewModels;
using Garage_3.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Garage_3.Controllers
{
    public class GaragesController : Controller
    {
        private readonly Garage_3Context dbGarage;

        public GaragesController(Garage_3Context context)
        {
            dbGarage = context;
        }

        // GET: Garages
        public async Task<IActionResult> Index()
        {
            return View(await dbGarage.Garage.ToListAsync());
        }

        // GET: Garages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garage = await dbGarage.Garage
                .FirstOrDefaultAsync(m => m.GarageId == id);
            if (garage == null)
            {
                return NotFound();
            }

            var model = dbGarage.Vehicle.Select(v => v)
                                        .Include(m => m.Membership)
                                        .Include(t => t.VehicleType)
                                        .Where(i => i.VehicleId == id)
                                        .Select(d => new DetailsViewModel 
                                        { 
                                            Id = d.VehicleId,
                                            FirstName = d.Membership.FirstName,
                                            LastName = d.Membership.LastName,
                                            MemberNumber = d.Membership.MembershipId,
                                            RegistrationNumber = d.RegistrationNumber,
                                            VehicleTypeName = d.VehicleType.Type_Name,
                                        })
                                        .FirstOrDefaultAsync();

            //var model = dbGarage.Garage
            //    .Include(m => m.Memberships)
            //    .Select(m => new DetailsViewModel
            //    { 
                    
            //    })
            //    .ThenInclude(v => v.Vehicles)
            //    .ThenInclude(vt => vt.VehicleType)
            //    .FirstOrDefaultAsync(g => g.GarageId == id);

            return View(await model);
        }

        // GET: Garages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Garages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GarageId,GarageName,NumberOfParkingPlaces")] Garage garage)
        {
            if (ModelState.IsValid)
            {
                dbGarage.Add(garage);
                await dbGarage.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(garage);
        }

        // GET: Garages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garage = await dbGarage.Garage.FindAsync(id);
            if (garage == null)
            {
                return NotFound();
            }
            return View(garage);
        }

        // POST: Garages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GarageId,GarageName,NumberOfParkingPlaces")] Garage garage)
        {
            if (id != garage.GarageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbGarage.Update(garage);
                    await dbGarage.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarageExists(garage.GarageId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(garage);
        }

        // GET: Garages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garage = await dbGarage.Garage
                .FirstOrDefaultAsync(m => m.GarageId == id);
            if (garage == null)
            {
                return NotFound();
            }

            return View(garage);
        }

        // GET: Garages/Delete/5
        /// <summary>
        /// TO do list:
        /// 1) Find the vehicle with that id
        /// 2) change it's parked properties to be falsed
        /// 3) Find the parking spot the vehicle is connected to
        /// 4) Make sure that there is not connection between the ParkingPlace and Vehicle
        /// 5) Change the ocuppied properties to null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> UnParked(int? id)
        {

            id = 1;
            // Find the vehicle id
            var vehicle = await dbGarage.Vehicle.FirstOrDefaultAsync(m => m.VehicleId == id);
            vehicle.IsParked = false; 

            if (id == null)
            {
                return NotFound();
            }

            var garage = await dbGarage.Garage
                .FirstOrDefaultAsync(m => m.GarageId == id);
            if (garage == null)
            {
                return NotFound();
            }

            

            if (vehicle == null)
            {
                return NotFound();
            }

            return View(garage);
        }



        // POST: Garages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)//Todo -Add to Remove action for Receipt
        {

            //Create Receipt
            ReceiptViewModel receipt = null;

            var vehicle = await dbGarage.Vehicle.FindAsync(id);
            if(vehicle != null)
            {
                var member = dbGarage.Membership
                                .FirstOrDefault(m=>m.MembershipId == vehicle.MembershipId);
                receipt = new ReceiptViewModel
                {
                    Id = vehicle.VehicleId,
                    RegistrationNumber = vehicle.RegistrationNumber,
                    MemberNumber = member.Personnummer,
                    CheckIn = vehicle.CheckInTime,
                    StayPro = member.StayPro,
                    IsPro = VehicleHelper.IsPro(member),
                    MemberSpaces = dbGarage.Vehicle.Where(v => v.IsParked && v.MembershipId == member.MembershipId)
                                                   .Select(v => v.VehicleType.Size)
                                                   .Count()
                };
            }

            dbGarage.Vehicle.Update(vehicle);
            await dbGarage.SaveChangesAsync();
            TempData["message"] = $"You have unparked your {vehicle.VehicleType}!";
            return View("Receipt", receipt);
        }

        //GET: Garages/Register   -new Membership
        /// <summary>
        /// Displays Member Registration Page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RegisterMember()
        {
            var model = new MembershipViewModel();
            model.IsGarageFull = IsGarageFull();
            return View(model);
        }

        //POST Garages/Register
        /// <summary>
        /// Adds valid Membership model to Database
        /// </summary>
        /// <param name="newMember"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterMember([Bind("Personnummer,FirstName,LastName,Address,PostNumber,City,IsPro")] MembershipViewModel newMember)
        {
            if (ModelState.IsValid)
            {
                Membership member = new Membership
                {
                    Personnummer = newMember.Personnummer,
                    FirstName = newMember.FirstName,
                    LastName = newMember.LastName,
                    RegistrationDate = DateTime.Now,
                    Birthdate = VehicleHelper.ConvertBirthdayFromPersonnummer(newMember.Personnummer),
                    Address = newMember.Address,
                    PostNumber = newMember.PostNumber,
                    City = newMember.City,
                    StayPro = newMember.StayPro
                };
                dbGarage.Membership.Add(member);
                await dbGarage.SaveChangesAsync();
                TempData["message"] = $"Thank you, {member.FirstName} for joining our garage! Enjoy your 30 days of free Pro Membership!";
                return RedirectToAction(nameof(Index));

            }

            return View(newMember);
        }

        
        public IActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }


        [HttpPost]
        public IActionResult Login(string personnummer)
        {
            if (ModelState.IsValid)
            {
                var member = dbGarage.Membership.FirstOrDefault(m => m.Personnummer == personnummer);

                if (member == null)
                {
                    return View("RegisterMember");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View("Login");
        }

        /// <summary>
        /// Method check i garage is full or not
        /// </summary>
        /// <returns>true if garage is full. Else false</returns>
        private bool IsGarageFull()
        {
            bool bFull = false;
            int iNumberOfFreeParkingPlaces = 0;

            // Hämta antal fordon i garaget
            int numberOfVehicles = dbGarage.Vehicle.Count();

            // Hämta garaget
            var garage = dbGarage.Garage.FirstOrDefault();
            if (garage != null)
                iNumberOfFreeParkingPlaces = garage.NumberOfParkingPlaces - numberOfVehicles;

            bFull = iNumberOfFreeParkingPlaces <= 0 ? true : false;
            return bFull;
        }


        public JsonResult CompareFirstName(string fName, string lName)
        {
            bool match = false;
            if (fName.ToLower() == lName.ToLower())
                match = true;
            return Json(match);
        }
        private bool GarageExists(int id)
        {
            return dbGarage.Garage.Any(e => e.GarageId == id);
        }

    }
}
