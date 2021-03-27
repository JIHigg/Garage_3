﻿using Garage_3.Data;
using Garage_3.Models.Entites;
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

            return View(garage);
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

        // POST: Garages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)//Todo -Add to Remove action for Receipt
        {
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
                    IsPro = member.IsPro
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
                    IsPro = newMember.IsPro
                };
                dbGarage.Membership.Add(member);
                await dbGarage.SaveChangesAsync();
                TempData["message"] = $"Thank you, {member.FirstName} for joining our garage! Enjoy your 30 days of free Pro Membership!";
                return RedirectToAction(nameof(Index));

            }

            return View(newMember);
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

        private bool GarageExists(int id)
        {
            return dbGarage.Garage.Any(e => e.GarageId == id);
        }
    }
}
