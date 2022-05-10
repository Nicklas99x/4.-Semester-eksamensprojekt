using Application.Models;
using Contract;
using Machine_Learning.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineLearningModelController : ControllerBase
    {
        protected IModelScoreRequestObject _requestObject;

        public MachineLearningModelController(IModelScoreRequestObject requestObject)
        {
            _requestObject = requestObject;
        }
        // GET: api/<MachineLearningModelController>
        [HttpGet("/ModelAccuracy")]
        public ModelEvaluationDto GetModelScore()
        {
            var modelScore = _requestObject.getModel();

            var modelDto = new ModelEvaluationDto();
            {
                modelDto.RSquare = modelScore.ModelEvaluation;
                modelDto.PricePrediction = modelScore.ModelPricePrediction;
            }
            return modelDto;
        }

        // GET api/<MachineLearningModelController>/5
        //[HttpGet("/Price")]
        //public Single GetPredictedHousePrice()
        //{
            
        //    return predictedPrice;
        //}

        // POST api/<MachineLearningModelController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}
    }
}
