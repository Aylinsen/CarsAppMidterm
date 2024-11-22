using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services;
using BLL.Models;

// Generated from Custom Template.

namespace MVC.Controllers
{
    public class TypeCarsController : MvcController
    {
        // Service injections:
        private readonly ITypeService _typeCarService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public TypeCarsController(
			ITypeService typeCarService

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _typeCarService = typeCarService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: TypeCars
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _typeCarService.Query().ToList();
            return View(list);
        }

        // GET: TypeCars/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _typeCarService.Query().SingleOrDefault(q => q.Record.Id==id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
           


            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: TypeCars/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: TypeCars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TypeCarModel typeCar)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _typeCarService.Create(typeCar.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;

                    return RedirectToAction(nameof(Details), new { id = typeCar.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(typeCar);
        }

        // GET: TypeCars/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _typeCarService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: TypeCars/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TypeCarModel typeCar)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _typeCarService.Update(typeCar.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = typeCar.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(typeCar);
        }

        // GET: TypeCars/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _typeCarService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: TypeCars/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _typeCarService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
