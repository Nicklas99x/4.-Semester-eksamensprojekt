using Machine_Learning.Interfaces;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ModelScoreRequestObject : IModelScoreRequestObject
    {
        //Property
        public double ModelEvaluation { get; set; }
        //DependencyInjection
        protected readonly IDataLoader _dataLoader;
        protected readonly IDataManager _dataManager;
        protected readonly IMLPipeline _mlPipeline;
        protected readonly IModelTrainer _modelTrainer;
        protected readonly IModelEvaluator _modelEvaluator;
        protected readonly IPricePredictor _pricePredictor;

        public ModelScoreRequestObject()
        {
        }

        //ConstructorInjection
        public ModelScoreRequestObject(
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
        public ModelScoreRequestObject GetModel()
        {
            //Calling methods from the implementation of the injected interfaces
            var data = _dataLoader.LoadDataset();
            var dataSplit = _dataManager.SplitDataIntoTwoGroups(data);
            var trainData = _dataManager.CreateTrainingSet(dataSplit);
            var testData = _dataManager.CreateTestSet(dataSplit);
            var pipeline = _mlPipeline.CreateMlPipeline();
            var mlModel = _modelTrainer.TrainModel(trainData, pipeline);
            var result = _modelEvaluator.EvaluateModel(testData, mlModel);
            //Make a new request object per request
            ModelScoreRequestObject request = new ModelScoreRequestObject();
            //Set the property ModelEvaluation to be equal to the result of the method
            //EvauateModel which returns a value as type double. This value will be returned
            //To the frontend via the API
            request.ModelEvaluation = result;
            //Return the created requestobject which now holds the value of the parameter result
            return request;

        }
    }
}
