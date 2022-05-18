using Contract.Dto;
using Contract.InterfaceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    [Authorize()]
    public class PredictionController : Controller
    {
        private readonly IPricePredictionService _pricePredictionService;

        public PredictionController(IPricePredictionService pricePredictionService)
        {
            _pricePredictionService = pricePredictionService;
        }


        // GET: PredictionController
        public async Task<IActionResult> GetPredictions()
        {
            var predictedPrices = await _pricePredictionService.GetPredictedPrices();
            return View(predictedPrices);
        }

        // GET: PredictionController/Create
        public IActionResult PredictNewPrice()
        {
            return View();
        }

        // POST: PredictionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PredictNewPrice(IFormCollection collection, PricePredictionDto pricePredictionDto)
        {
            try
            {
                var price = await _pricePredictionService.PredictPrice(pricePredictionDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PredictionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PredictionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: PredictionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PredictionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
