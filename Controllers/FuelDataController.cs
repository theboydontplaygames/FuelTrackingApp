using Microsoft.AspNetCore.Mvc;
using Fuel_Tracking_application.Models.Domain;
using Fuel_Tracking_application.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Fuel_Tracking_application.Data;
using Microsoft.EntityFrameworkCore;

namespace Fuel_Tracking_application.Controllers
{
    public class FuelDataController : Controller
    {
        private readonly FuelDbContext fuelDbContext;

        public FuelDataController(FuelDbContext fuelDbContext)
        {
            this.fuelDbContext = fuelDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var fuel = await fuelDbContext.FuelData.ToListAsync();
            return View(fuel);
        }

        [HttpGet] 
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddFuelDataModel addFuelDataRequest)
        {
            var fuel = new Fuel()
            {
                dataId = Guid.NewGuid(),
                reportingEmployee = addFuelDataRequest.reportingEmployee,
                Date = addFuelDataRequest.Date,
                odometerTotal = addFuelDataRequest.odometerTotal,  
                filled = addFuelDataRequest.filled,
                filledVolume = addFuelDataRequest.filledVolume,
                fuelPrice = addFuelDataRequest.fuelPrice

            };

            await fuelDbContext.FuelData.AddAsync(fuel);
            await fuelDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id) 
        {
           var fueldata = await fuelDbContext.FuelData.FirstOrDefaultAsync(x => x.dataId == id);

             
            if (fueldata != null)
            {
                var viewModel = new UpdateFuelDataModel()
                {
                    dataId = fueldata.dataId,
                    reportingEmployee = fueldata.reportingEmployee,
                    Date = fueldata.Date,
                    odometerTotal = fueldata.odometerTotal,
                    filled = fueldata.filled,
                    filledVolume = fueldata.filledVolume,
                    fuelPrice = fueldata.fuelPrice
                };

                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> View(UpdateFuelDataModel model)
        {
            var fuel = await fuelDbContext.FuelData.FindAsync(model.dataId);

            if (fuel != null)
            {
                fuel.reportingEmployee = model.reportingEmployee;
                fuel.Date = model.Date;
                fuel.odometerTotal = model.odometerTotal;
                fuel.filled = model.filled;
                fuel.filledVolume = model.filledVolume;

                await fuelDbContext.SaveChangesAsync();

                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateFuelDataModel model)
        {
            var fuel = fuelDbContext.FuelData.Find(model.dataId);

            if (fuel != null) 
            {
                fuelDbContext.FuelData.Remove(fuel);
                await fuelDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
