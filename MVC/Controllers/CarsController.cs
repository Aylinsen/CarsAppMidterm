using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services;
using BLL.Models;
using BLL.DAL;
using BLL.Services.Bases;

// Generated from Custom Template.

namespace MVC.Controllers
{
    public class CarsController : MvcController
    {
        // Service injections:
        private readonly IService<Car,CarModel> _carService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public CarsController(
            IService<Car, CarModel> carService

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _carService = carService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: Cars
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _carService.Query().ToList();
            return View(list);
        }

        // GET: Cars/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _carService.Query().SingleOrDefault(q => q.record.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            ViewData["CarTypeId"] = new SelectList(_carService.Query().ToList(), "record.Id", "Brand");
            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarModel car)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _carService.Create(car.record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = car.record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(car);
        }

        // GET: Cars/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _carService.Query().SingleOrDefault(q => q.record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Cars/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CarModel car)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _carService.Update(car.record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = car.record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(car);
        }

        // GET: Cars/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _carService.Query().SingleOrDefault(q => q.record.Id == id);
            return View(item);
        }

        // POST: Cars/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _carService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
