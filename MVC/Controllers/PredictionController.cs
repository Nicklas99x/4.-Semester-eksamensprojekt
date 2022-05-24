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
        //Dependency injection of interface so that methods
        //from this interface's implementation can be accessed by this controller
        private readonly IPricePredictionService _pricePredictionService;

        public PredictionController(IPricePredictionService pricePredictionService)
        {
            _pricePredictionService = pricePredictionService;
        }


        // GET: PredictionController
        public async Task<IActionResult> GetPredictions()
        {
            //Call method GetPredictedPrices
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
        //Prevent crosssite request forgery
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PredictNewPrice(IFormCollection collection, PricePredictionDto pricePredictionDto)
        {
            try
            {
                //Call method PredictPrice
                var price = await _pricePredictionService.PredictPrice(pricePredictionDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
