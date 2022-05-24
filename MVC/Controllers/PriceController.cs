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
    public class PriceController : Controller
    {
        //Dependency injection of interface so that methods
        //from this interface's implementation can be accessed by this controller
        private readonly IModelEvaluationService _modelEvaluationService;

        public PriceController(IModelEvaluationService modelEvaluationService)
        {
            _modelEvaluationService = modelEvaluationService;
        }
        // GET: PriceController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //Call method GetModelScore
            var data = await _modelEvaluationService.GetModelScore();
            return View(data);
        }
    }
}
