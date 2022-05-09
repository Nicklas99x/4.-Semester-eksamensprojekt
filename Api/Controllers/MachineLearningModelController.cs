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
        protected readonly IDataLoader _dataLoader;
        protected readonly IDataManager _dataManager;
        protected readonly IMLPipeline _mlPipeline;
        protected readonly IModelTrainer _modelTrainer;
        protected readonly IModelEvaluator _modelEvaluator;
        protected readonly IPricePredictor _pricePredictor;

        public MachineLearningModelController(
            IDataLoader dataLoader,
            IDataManager dataManager, 
            IMLPipeline mlPipeline,
            IModelTrainer modelTrainer, 
            IModelEvaluator modelEvaluator,
            IPricePredictor pricePredictor)
        {
            _dataLoader = dataLoader;
            _dataManager = dataManager;
            _mlPipeline = mlPipeline;
            _modelTrainer = modelTrainer;
            _modelEvaluator = modelEvaluator;
            _pricePredictor = pricePredictor;
        }



        // GET: api/<MachineLearningModelController>
        [HttpGet("/ModelAccuracy")]
        public double GetModelScore()
        {
            IDataView data = _dataLoader.LoadDataset();
            DataOperationsCatalog.TrainTestData dataSplit = _dataManager.SplitDataIntoTwoGroups(data);
            var trainData = _dataManager.CreateTrainingSet(dataSplit);
            var testData = _dataManager.CreateTestSet(dataSplit);
            var pipeline = _mlPipeline.CreateMlPipeline();
            var mlModel = _modelTrainer.TrainModel(trainData, pipeline);
            var result = _modelEvaluator.EvaluateModel(testData, mlModel);
            return result;
        }

        // GET api/<MachineLearningModelController>/5
        [HttpGet("/Price")]
        public Single GetPredictedHousePrice()
        {
            IDataView data = _dataLoader.LoadDataset();
            DataOperationsCatalog.TrainTestData dataSplit = _dataManager.SplitDataIntoTwoGroups(data);
            var trainData = _dataManager.CreateTrainingSet(dataSplit);
            var pipeline = _mlPipeline.CreateMlPipeline();
            var mlModel = _modelTrainer.TrainModel(trainData, pipeline);
            var predictedPrice = _pricePredictor.MakePredictionWithTheModel(mlModel);
            return predictedPrice;
        }

        // POST api/<MachineLearningModelController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}
    }
}
