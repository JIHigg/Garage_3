using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage_3.Data;
using Garage_3.Models.Entites;
using Garage_3.Models;
using Garage_3.ViewModels;

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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var garage = await dbGarage.Garage.FindAsync(id);
            dbGarage.Garage.Remove(garage);
            await dbGarage.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }

        private bool GarageExists(int id)
        {
            return dbGarage.Garage.Any(e => e.GarageId == id);
        }

    }
}
