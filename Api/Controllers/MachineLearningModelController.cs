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
        //DependencyInjection
        protected IModelScoreRequestObject _requestObject;

        public MachineLearningModelController(IModelScoreRequestObject requestObject)
        {
            _requestObject = requestObject;
        }
        //GetModelScore HttpGetRequest that gets the modelscore from the Ml model
        // GET: api/<MachineLearningModelController>
        [HttpGet("/ModelAccuracy")]
        public ModelEvaluationDto GetModelScore()
        {
            //Get modelscore
            var modelScore = _requestObject.GetModel();

            //Make a new Dto
            var modelDto = new ModelEvaluationDto();
            {
                //Set the Dto porperty to be equal to the requestobject which contains
                //The value that needs to be returned by the GetRequest
                modelDto.RSquare = modelScore.ModelEvaluation;
            }
            return modelDto;
        }
    }
}
