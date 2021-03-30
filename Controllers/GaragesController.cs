using Garage_3.Data;
using Garage_3.Models.Entites;
using Garage_3.Models.ViewModel;
using Garage_3.Services;
using Garage_3.Utils;
using Garage_3.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3.Controllers
{
    public class GaragesController : Controller
    {
        private List<VehicleType> m_lsVehicleType = null;
        private readonly IParkVehicleService m_ParkVehicleService;
        private readonly IMemberShipService m_MemberShipService;
        private readonly Garage_3Context dbGarage;

        public GaragesController(Garage_3Context context, IParkVehicleService parkVehicleService, IMemberShipService memberShipService)
        {
            m_ParkVehicleService = parkVehicleService;
            m_MemberShipService = memberShipService;
            dbGarage = context;
        }

        // GET: Garages
        public async Task<IActionResult> Index()
        {
            GetMessageFromTempData();

            var garages = await dbGarage.Garage?.ToListAsync();

            return View(garages);
        }

        public async Task<IActionResult> Members()
        {
            var messageObject = TempData["message"];
            if(messageObject != null)
            {
                ViewBag.Message = messageObject.ToString();
            }
            List<MembersViewModel> members =  await dbGarage.Membership
                                                    .Select(m => new MembersViewModel
                                                    {
                                                        FirstName = m.FirstName,
                                                        LastName = m.LastName,
                                                        Name = $"{m.FirstName} {m.LastName}",
                                                        MembershipId = m.MembershipId,
                                                        Vehicles = m.Vehicles.ToList(),
                                                        TotalVehicles = m.Vehicles.Count()
                                                    }).ToListAsync();
            

            return View( members);
        }

        public async Task<IActionResult> MemberEdit(int? id)
        {
            // TODO

            if (id == null)
            {
                return NotFound();
            }

            var member = await dbGarage.Membership.Where(i => i.MembershipId == id).FirstOrDefaultAsync();

            return View(member);
        }


        public async Task<IActionResult> MemberDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await dbGarage.Membership
                .FirstOrDefaultAsync(m => m.MembershipId == id);
            if (member == null)
            {
                return NotFound();
            }

            var model = new MembersViewModel
            {
                FirstName = member.FirstName,
                LastName = member.LastName,
                MembershipId = member.MembershipId,
                Name = $"{member.FirstName} {member.LastName}",
                TotalVehicles = dbGarage.Vehicle.Where(v=> v.MembershipId == member.MembershipId).Count(),
                Vehicles = dbGarage.Vehicle.Where(v => v.MembershipId == member.MembershipId).ToList()
            };

            return View( model);
        }


        [HttpGet]
        public ActionResult Sort(string sortBy, string sortOrder, string firstName)
        {
            List<MembersViewModel> lsMembers = null;

            if (String.IsNullOrWhiteSpace(sortOrder))
                sortOrder = "asc";

            lsMembers = dbGarage.Membership
                 .Select
                 (n => new MembersViewModel
                 {
                     MembershipId = n.MembershipId,
                     FirstName = n.FirstName,
                     LastName = n.LastName,
                     Name = $"{n.FirstName} {n.LastName}",
                     Vehicles = n.Vehicles.Where(v => v.MembershipId == n.MembershipId).ToList()
                 })
                 .ToList<MembersViewModel>();


            // Sort list with vehicle
            lsMembers = VehicleHelper.Sort(lsMembers, sortBy, sortOrder);

            // Now set up sortOrder for next postback
            if (sortOrder.Equals("desc"))
                sortOrder = "asc";
            else
                sortOrder = "desc";


            // Set ViewBags
            ViewBag.SortOrder = sortOrder;
            ViewBag.OldSortBy = sortBy;

            return View("Members", lsMembers);
        }

        [HttpGet]
        public ActionResult SearchFor(string sortOrder, string oldSortBy, string memberName)
        {
            List<MembersViewModel> lstMembers = null;

            if (String.IsNullOrWhiteSpace(sortOrder))
                sortOrder = "asc";

            if (!String.IsNullOrWhiteSpace(memberName))
            {
                memberName = memberName.Trim();
                memberName = memberName.ToLower();

                ViewBag.SearchFor = memberName;
                lstMembers = dbGarage.Membership.Where(r => r.FirstName.ToLower().Equals(memberName)||r.LastName.ToLower().Equals(memberName))
                   .Select
                    (m => new MembersViewModel
                    {
                        MembershipId = m.MembershipId,
                        FirstName = m.FirstName,
                        LastName = m.LastName,
                        Name = $"{m.FirstName} {m.LastName}",
                        Vehicles = m.Vehicles.Where(v=> v.MembershipId== m.MembershipId).ToList(),
                        TotalVehicles = m.Vehicles.Count()
                    })
                    .ToList<MembersViewModel>();
            }
            else
            {
                lstMembers = dbGarage.Membership
                    .Select
                    (n => new MembersViewModel
                    {
                        MembershipId = n.MembershipId,
                        FirstName = n.FirstName,
                        LastName = n.LastName,
                        Name = $"{n.FirstName} {n.LastName}",
                        Vehicles = n.Vehicles.Where(v=> v.MembershipId==n.MembershipId).ToList(),
                        TotalVehicles = n.Vehicles.Count()
                    })
                    .ToList<MembersViewModel>();
            }

            lstMembers = VehicleHelper.Sort(lstMembers, oldSortBy, sortOrder);

            ViewBag.SortOrder = sortOrder;
            ViewBag.OlderSortBy = oldSortBy;

            return View("Members", lstMembers);
        }

        public async Task<IActionResult> VehicleList()
        {
            var vehicles = await dbGarage.Vehicle.Include("VehicleType").Where(v => v.IsParked == true).ToListAsync();

            return View(vehicles);
        }

        // GET: Garages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await dbGarage.Vehicle
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            var model = await dbGarage.Vehicle.Select(v => v)
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

            return View(model);
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

        // GET: Garages/UnParked/
        public IActionResult UnParkedOLD(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Find the vehicle id
            //var vehicle = await dbGarage.Vehicle.FirstOrDefaultAsync(v => v.VehicleId == id);
            //var parkedV = await dbGarage.ParkingPlace.FirstOrDefaultAsync(p => p.ParkingPlaceId == vehicle.VehicleId);

            // V > -- PPV -- < PP

            var vehicle = dbGarage.Vehicle.Where(i => i.VehicleId == id).FirstOrDefault();
            if(vehicle != null)
            {
                vehicle.CheckOutTime = DateTime.Now;
                vehicle.IsParked = false;
            }


            // find the parking place

            var parkedV = dbGarage.ParkingPlace.Where(pv => pv.VehicleId == id).FirstOrDefault();
            if(parkedV != null)
            {
                parkedV.IsOccupied = false;
                parkedV.VehicleId = null;
            }

            dbGarage.SaveChanges();

            var ppv = dbGarage.ParkingPlaceVehicles.Where(p => p.VehicleId == id).FirstOrDefault();

            if (ppv != null)
            {
                dbGarage.Remove(ppv);
                dbGarage.SaveChanges();
            }

            if (vehicle == null)
            {
                return NotFound();
            }

            return View();
        }


        //[HttpPost, ActionName("UnParkedV")]
        public async Task<IActionResult> UnParkedConfirmed(int id)
        {
            var vehicle = await dbGarage.Vehicle.Where(i => i.VehicleTypeId == id).FirstOrDefaultAsync();
            //ReceiptViewModel receipt = null;
            //var vehicle = await dbGarage.Vehicle.FindAsync(id);
            //if (vehicle != null)
            //{
            //    receipt = new ReceiptViewModel();
            //    receipt.CheckIn = vehicle.CheckInTime;
            //    receipt.Id = vehicle.VehicleId;
            //    receipt.RegistrationNumber = vehicle.RegistrationNumber;
            //    receipt.Id = vehicle.VehicleTypeId;
            //}

            ////dbGarage.Vehicle.Remove(vehicle); // TODO fix the unparked
            //await dbGarage.SaveChangesAsync();
            //TempData["message"] = $"You have successfully unparked your {vehicle.VehicleType}!";
            //return View("Receipt", receipt);
            ////return RedirectToAction(nameof(Receipt));
            ///

            return View("UnParked", vehicle);

        }

        private void UnparkTheVehicle(int? id)
        {
            var vehicle = dbGarage.Vehicle.Where(i => i.VehicleId == id).FirstOrDefault();
            if (vehicle != null)
            {
                vehicle.CheckOutTime = DateTime.Now;
                vehicle.IsParked = false;
            }

            // find the parking place
            var parkedV = dbGarage.ParkingPlace.Where(pv => pv.VehicleId == id).FirstOrDefault();
            if (parkedV != null)
            {
                parkedV.IsOccupied = false;
                parkedV.VehicleId = null;
            }

            dbGarage.SaveChanges();

            var ppv = dbGarage.ParkingPlaceVehicles.Where(p => p.VehicleId == id).FirstOrDefault();

            if (ppv != null)
            {
                dbGarage.Remove(ppv);
                dbGarage.SaveChanges();
            }
        }



        // POST: Garages/Delete/5
        //[HttpPost, ActionName("UnParked")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> UnparkVehicle(int? id)//Todo -Add to Remove action for Receipt
        {
            // Unpark. Updates Vehicle and ParkingPlace in db
            UnparkTheVehicle(id);

            //Create Receipt
            ReceiptViewModel receipt = null;

            var vehicle = await dbGarage.Vehicle.FindAsync(id);
            if (vehicle != null)
            {
                var member = dbGarage.Membership
                                .FirstOrDefault(m => m.MembershipId == vehicle.MembershipId);
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

                dbGarage.Vehicle.Update(vehicle);
                await dbGarage.SaveChangesAsync();
                TempData["message"] = $"You have unparked your {vehicle.VehicleType}!";
                return View("Receipt", receipt);
            }
            return View();
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
                return RedirectToAction("Home", nameof(Index));
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
            while (lName != null)
            {
                if (fName.ToLower() == lName.ToLower())
                    match = true;
            }
            return Json(match);
        }
        private bool GarageExists(int id)
        {
            return dbGarage.Garage.Any(e => e.GarageId == id);
        }



        //public async Task<IActionResult> MemberDetail(int id)
        //{
        // Vet ej om jag behöver göra view
        //    var member = dbGarage.Membership.Where(i => i.MembershipId == id).FirstOrDefault();
        //    if(member != null)
        //    {
        //        var vehicles = await dbGarage.Vehicle.Where(i => i.MembershipId == member.MembershipId).ToListAsync();
        //    }

        //    return View();
        //}

        public IActionResult ParkedVehicleDetails(int id)
        {
            var vehicle = dbGarage.Vehicle.Where(v => v.VehicleId == id).Select(a => new VehicleDetailsViewModel
            {
                CheckInTime = a.CheckInTime,
                CheckOutTime = a.CheckOutTime,
                Color = a.Color,
                IsParked = a.IsParked,
                Make = a.Make,
                Model = a.Model,
                NumberOfWheels = a.NumberOfWheels,
                RegistrationNumber = a.RegistrationNumber,
                VehicleId = a.VehicleId,
                Year = a.Year,
                VehicleTypeId = a.VehicleTypeId,
                MemberShipId = a.MembershipId
            }).FirstOrDefault();


            // Update with more information
            if (vehicle != null)
            {
                var vehicleType = dbGarage.VehicleType.Where(i => i.VehicleTypeId == vehicle.VehicleTypeId).FirstOrDefault();
                if (vehicleType != null)
                    vehicle.VehicleType = vehicleType.Type_Name;

                vehicle.Parked = vehicle.IsParked ? "Parked" : "Not parked";
            }

            return View(vehicle);
        }

        public IActionResult VehicleDetails(int id, string backTo)
        {            
            var vehicle = dbGarage.Vehicle.Where(v => v.VehicleId == id).Select(a => new VehicleDetailsViewModel { 
                CheckInTime = a.CheckInTime,
                CheckOutTime = a.CheckOutTime,
                Color = a.Color,
                IsParked = a.IsParked,
                Make = a.Make,
                Model = a.Model,
                NumberOfWheels = a.NumberOfWheels,
                RegistrationNumber = a.RegistrationNumber,
                VehicleId = a.VehicleId,
                Year = a.Year,
                VehicleTypeId = a.VehicleTypeId
            }).FirstOrDefault();


            // Update with more information
            if(vehicle != null)
            {
                var vehicleType = dbGarage.VehicleType.Where(i => i.VehicleTypeId == vehicle.VehicleTypeId).FirstOrDefault();
                if(vehicleType != null)
                    vehicle.VehicleType = vehicleType.Type_Name;

                vehicle.Parked = vehicle.IsParked ? "Parked" : "Not parked";
            }

            // Hack
            if(!String.IsNullOrWhiteSpace(backTo))
                ViewBag.BackTo = backTo;

            return View(vehicle);
        }

        #region Create a new vehicle and park it
        public async Task<IActionResult> AddNewVehicleType([Bind("NewVehicleType", "NewVehicleTypeSize", "RegistrationNumber", "NumberOfWheels", "Year", "Model", "Make", "Color", "VehicleTypesId", "MembershipId", "MemberName")] ParkVehicleCreateViewModel parkVehicleCreateViewModel)
        {
            bool bVehicleTypeExist = m_ParkVehicleService.IsVehicleTypeExisting(parkVehicleCreateViewModel.NewVehicleType);

            if (bVehicleTypeExist)
            {
                TempData["message"] = "Vehicle type already exist";
                TempData["typeOfMessage"] = "error";

                //var member = await dbGarage.Membership.Where(i => i.MembershipId == parkVehicleCreateViewModel.MembershipId).FirstOrDefaultAsync();

                // Set up viewbag with messages
                GetMessageFromTempData();

                var model = new ParkVehicleCreateViewModel();
                model.VehicleId = parkVehicleCreateViewModel.VehicleId;
                model.VehicleTypesId = parkVehicleCreateViewModel.VehicleTypesId;
                model.RegistrationNumber = parkVehicleCreateViewModel.RegistrationNumber;
                model.NumberOfWheels = parkVehicleCreateViewModel.NumberOfWheels;
                model.Year = parkVehicleCreateViewModel.Year;
                model.Model = parkVehicleCreateViewModel.Model;
                model.Make = parkVehicleCreateViewModel.Make;
                model.Color = parkVehicleCreateViewModel.Color;
                model.NewVehicleType = parkVehicleCreateViewModel.NewVehicleType;
                model.NewVehicleTypeSize = parkVehicleCreateViewModel.NewVehicleTypeSize;
                model.MemberName = parkVehicleCreateViewModel.MemberName;

                //if (member != null)
                //    model.MemberName = member.FirstName + " " + member.LastName;

                model.MembershipId = parkVehicleCreateViewModel.MembershipId;
                model.ParkingPlaceId = parkVehicleCreateViewModel.ParkingPlaceId;
                model.MembershipId = parkVehicleCreateViewModel.MembershipId;
                model.VehicleTypes = m_ParkVehicleService.CreateVehicleTypeDropDown();
                model.IsGarageFull = m_ParkVehicleService.IsGarageFull();
                model.FreeParkingPlaces = m_ParkVehicleService.CreateFreeParkingPlaceDropDown();

                return View(nameof(ParkNewVehicle), model);
            }

            VehicleType vehicleType = new VehicleType();
            vehicleType.Size = 1;// TODO. Size is optional. parkVehicleCreateViewModel.NewVehicleTypeSize;
            vehicleType.Type_Name = parkVehicleCreateViewModel.NewVehicleType;
            dbGarage.VehicleType.Add(vehicleType);
            dbGarage.SaveChanges();

            TempData["message"] = $"Has added Vehicle type {parkVehicleCreateViewModel.NewVehicleType}";
            TempData["typeOfMessage"] = "info";

            return RedirectToAction(nameof(ParkNewVehicle));
        }


        public async Task<IActionResult> ParkCreatedVehicle([Bind("MembershipId", "ParkingPlaceId", "RegistrationNumber", "NumberOfWheels", "Year", "Model", "Make", "Color", "VehicleTypesId")] ParkVehicleCreateViewModel parkVehicleCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var parkingPlace = await dbGarage.ParkingPlace.Where(i => i.ParkingPlaceId == parkVehicleCreateViewModel.ParkingPlaceId).FirstOrDefaultAsync();
                if (parkingPlace != null)
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle.RegistrationNumber = parkVehicleCreateViewModel.RegistrationNumber;
                    vehicle.NumberOfWheels = parkVehicleCreateViewModel.NumberOfWheels;
                    vehicle.Year = parkVehicleCreateViewModel.Year;
                    vehicle.Model = parkVehicleCreateViewModel.Model;
                    vehicle.Make = parkVehicleCreateViewModel.Make;
                    vehicle.Color = parkVehicleCreateViewModel.Color;
                    vehicle.CheckInTime = DateTime.Now;
                    vehicle.IsParked = true;
                    vehicle.MembershipId = parkVehicleCreateViewModel.MembershipId;
                    vehicle.VehicleTypeId = parkVehicleCreateViewModel.VehicleTypesId;
                    vehicle.CheckInTime = DateTime.Now;

                    // TODO. För närvarande kan ett fordon bara parkera i en parkeringsplats. Flera platser är överkurs..
                    vehicle.ParkingPlaceId = parkVehicleCreateViewModel.ParkingPlaceId;

                    try
                    {
                        dbGarage.Vehicle.Add(vehicle);
                        await dbGarage.SaveChangesAsync();

                        parkingPlace.IsOccupied = true;
                        parkingPlace.VehicleId = vehicle.VehicleId;
                        await dbGarage.SaveChangesAsync();

                        TempData["message"] = "You have parked vehicle " + parkVehicleCreateViewModel.RegistrationNumber;
                        TempData["typeOfMessage"] = "info";

                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception e)
                    {
                    }
                }

                TempData["message"] = "We cant park vehicle";
                TempData["typeOfMessage"] = "error";
            }

            return RedirectToAction(nameof(ParkNewVehicle));
        }

        public async Task<IActionResult> ParkNewVehicle(int MembershipId)
        {
            // Set up viewbag with messages
            GetMessageFromTempData();

            var model = new ParkVehicleCreateViewModel();

            var member = await dbGarage.Membership.Where(i => i.MembershipId == MembershipId).FirstOrDefaultAsync();
            if (member != null)
                model.MemberName = member.FirstName + " " + member.LastName;

            model.MembershipId = MembershipId;
            model.VehicleTypes = m_ParkVehicleService.CreateVehicleTypeDropDown();
            model.IsGarageFull = m_ParkVehicleService.IsGarageFull();
            model.FreeParkingPlaces = m_ParkVehicleService.CreateFreeParkingPlaceDropDown();

            return View(model);
        }

        #endregion // End of region Create a new vehicle and park it

        #region Park a vehicle that already exist in database
        /// <summary>
        /// Fourth step of parking a vehicle at a parking place
        /// Now member has selected vehicle and parking place. Time to park and save to database
        /// </summary>
        /// <param name="parkVehicleSelectParkingPlaceViewModel"></param>
        /// <returns>View</returns>
        public async Task<IActionResult> ParkTheVehicle([Bind("ParkingPlaceId", "MembershipId", "VehicleId")] ParkVehicleSelectParkingPlaceViewModel parkVehicleSelectParkingPlaceViewModel)
        {
            var vehicle = await dbGarage.Vehicle.Where(i => i.VehicleId == parkVehicleSelectParkingPlaceViewModel.VehicleId).FirstOrDefaultAsync();
            var parkingPlace = await dbGarage.ParkingPlace.Where(i => i.ParkingPlaceId == parkVehicleSelectParkingPlaceViewModel.ParkingPlaceId).FirstOrDefaultAsync();

            if (vehicle != null && parkingPlace != null)
            {
                // Update objects
                vehicle.IsParked = true;
                vehicle.CheckInTime = DateTime.Now;
                vehicle.ParkingPlaceId = parkingPlace.ParkingPlaceId;
                parkingPlace.IsOccupied = true;
                parkingPlace.VehicleId = vehicle.VehicleId;

                await dbGarage.SaveChangesAsync();

                TempData["message"] = $"We have parked {vehicle.RegistrationNumber} at parking place {parkingPlace.ParkingPlaceId}";
                TempData["typeOfMessage"] = "info";
            }
            else
            {
                TempData["message"] = $"We cant park {vehicle.RegistrationNumber}";
                TempData["typeOfMessage"] = "error";
            }

            return RedirectToAction("Index", "Home");
        }


        /// <summary>
        /// Third action when you want to park a vehicle
        /// Now member has selected a vehicle. Now its time to select free parking place
        /// </summary>
        /// <param name="VehicleId">Id for selected vehicle</param>
        /// <returns>View</returns>
        public async Task<IActionResult> ParkVehicleSelectParkingPlace([Bind("VehicleId")] int VehicleId)
        {
            var vehicle = await dbGarage.Vehicle.Include("Membership").Where(v => v.VehicleId == VehicleId).FirstOrDefaultAsync();

            var model = new ParkVehicleSelectParkingPlaceViewModel();
            model.Vehicle = vehicle;
            model.VehicleId = vehicle.VehicleId;
            model.MemberShip = vehicle.Membership;
            model.MemberName = vehicle.Membership.FirstName + " " + vehicle.Membership.LastName;
            model.MembershipId = vehicle.Membership.MembershipId;
            model.FreeParkingPlaces = m_ParkVehicleService.CreateFreeParkingPlaceDropDown();

            return View("ParkVehicleSelectParkingPlace", model);
        }

        /// <summary>
        /// Second action when you want to park a vehicle
        /// Member shall select a vehicle that shall be parked
        /// </summary>
        /// <returns>View</returns>
        public async Task<IActionResult> ParkingVehicleSelectVehicle(int MemberShipId)
        {
            var model = new ParkVehicleSelectVehicleViewModel();

            model.MemberShip = await dbGarage.Membership.Where(m => m.MembershipId == MemberShipId).FirstOrDefaultAsync();
            // Get all vehicle that is not parked
            model.Vehicles = await dbGarage.Vehicle.Where(m => m.MembershipId == MemberShipId && m.IsParked == false).ToListAsync();

            return View("ParkVehicleSelectVehicle", model);
        }

        /// <summary>
        /// Second action when you want to park a vehicle
        /// Member shall select a vehicle that shall be parked
        /// </summary>
        /// <param name="parkVehicleSelectMemberViewModel"></param>
        /// <returns>View</returns>
        public async Task<IActionResult> ParkVehicleSelectVehicle([Bind("MemberShipId")] ParkVehicleSelectMemberViewModel parkVehicleSelectMemberViewModel)
        {
            var model = new ParkVehicleSelectVehicleViewModel();

            // We already have client side validation of this
            //if (parkVehicleSelectMemberViewModel.MemberShipId <= 0)
            if (parkVehicleSelectMemberViewModel.MemberShipId <= 0)
            {
                var model1 = new ParkVehicleSelectMemberViewModel();
                model1.Members = m_MemberShipService.CreateMemberDropDown();

                ModelState.AddModelError("MemberShipId", "You have to select a membership");

                return View("ParkVehicle", model1);
            }
            else
            {
                model.MemberShip = await dbGarage.Membership.Where(m => m.MembershipId == parkVehicleSelectMemberViewModel.MemberShipId).FirstOrDefaultAsync();
                // Get all vehicle that is not parked
                model.Vehicles = await dbGarage.Vehicle.Where(m => m.MembershipId == parkVehicleSelectMemberViewModel.MemberShipId && m.IsParked == false).ToListAsync();
            }

            return View(model);
        }


        /// <summary>
        /// First action when you want to park a vehicle
        /// Here user select a membership
        /// </summary>
        /// <returns>View</returns>
        public IActionResult ParkVehicle()
        {
            var model = new ParkVehicleSelectMemberViewModel();
            model.Members = m_MemberShipService.CreateMemberDropDown();

            return View(model);
        }

        #endregion // End of region Park a vehicle that already exist in database

        #region Garage information

        public async Task<IActionResult>ShowGarage()
        {
            // TODO Hard code to GarageId = 1
            int iGarageId = 1;

            var garage = await dbGarage.Garage.AsNoTracking().Where(i => i.GarageId == iGarageId).FirstOrDefaultAsync();
            var members = await dbGarage.Membership.AsNoTracking().Where(i => i.GarageId == iGarageId).ToListAsync();
            int iNumberOfOccupiedParkingPlaces = await dbGarage.ParkingPlace.Where(g => g.GarageId == garage.GarageId && g.IsOccupied).CountAsync();
            var vehicleTypes = dbGarage.VehicleType.AsNoTracking().ToList();

            // TODO Check if algo is ok in another test project
            // Now i want to know a members type of membership
            foreach (var member in members)
                member.TypeOfMembersShip = MemberShipHelper.GetTypeOfMemberShip(member);


            var results = await dbGarage.ParkingPlace
                .Join(
                dbGarage.Vehicle,
                parkingPlace => parkingPlace.ParkingPlaceId,
                vehicle => vehicle.ParkingPlaceId,
                (parkingPlace, vehicle) => new GarageVehiclesInfoViewModel
                {
                    VehicleId = vehicle.VehicleId,
                    RegistrationNumber = vehicle.RegistrationNumber,
                    CheckInTime = vehicle.CheckInTime,
                    CheckOutTime = DateTime.Now,
                    IsParked = vehicle.IsParked,
                    VehicleTypeId = vehicle.VehicleTypeId,
                    VehicleType = String.Empty,
                    MemberShipId = vehicle.MembershipId,
                    Make = vehicle.Make,
                    Model = vehicle.Model,
                    Year = vehicle.Year,
                    ParkingPlaceId = parkingPlace.ParkingPlaceId,
                    GarageId = parkingPlace.GarageId
                })
                .Where(n => n.GarageId == iGarageId && n.IsParked == true)
                .ToListAsync();

            // Get data i dident get in the join
            Membership memberShip = null;
            VehicleType vehicleType = null;            

            foreach (var result in results)
            {
                // Get members first and last name
                memberShip = members.Where(m => m.MembershipId == result.MemberShipId).FirstOrDefault();
                if(memberShip != null)
                {
                    result.MemberFirstName = memberShip.FirstName;
                    result.MemberLastName = memberShip.LastName;
                }

                // Get the vehicle type
                vehicleType = vehicleTypes.Where(v => v.VehicleTypeId == result.VehicleTypeId).FirstOrDefault();
                if(vehicleType != null)
                    result.VehicleType = vehicleType.Type_Name;

                result.ParkedTime = VehicleHelper.CalculateParkedTime(result.CheckInTime);
            }

            var model = new ShowGarageViewModel();
            model.GarageName = garage.GarageName;
            model.NumberOfParkingPlaces = garage.NumberOfParkingPlaces;
            model.NumberOfVehiclesInGarage = iNumberOfOccupiedParkingPlaces;
            model.Members = members;
            model.VehiclesInfo = results;

            return View(model);
        }

        #endregion // End of Garage information

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
