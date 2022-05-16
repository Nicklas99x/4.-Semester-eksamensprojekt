using Contract.InterfaceServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class PriceController : Controller
    {
        private readonly IModelEvaluationService _modelEvaluationService;

        public PriceController(IModelEvaluationService modelEvaluationService)
        {
            _modelEvaluationService = modelEvaluationService;
        }
        // GET: PriceController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _modelEvaluationService.GetModelScore();
            return View(data);
        }

        // GET: PriceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PriceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PriceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
