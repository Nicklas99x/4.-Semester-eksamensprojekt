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
        public double ModelEvaluation { get; set; }
        public float ModelPricePrediction { get; set; }
        protected readonly IDataLoader _dataLoader;
        protected readonly IDataManager _dataManager;
        protected readonly IMLPipeline _mlPipeline;
        protected readonly IModelTrainer _modelTrainer;
        protected readonly IModelEvaluator _modelEvaluator;
        protected readonly IPricePredictor _pricePredictor;

        public ModelScoreRequestObject()
        {
        }

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
        public ModelScoreRequestObject getModel()
        {
            IDataView data = _dataLoader.LoadDataset();
            DataOperationsCatalog.TrainTestData dataSplit = _dataManager.SplitDataIntoTwoGroups(data);
            var trainData = _dataManager.CreateTrainingSet(dataSplit);
            var testData = _dataManager.CreateTestSet(dataSplit);
            var pipeline = _mlPipeline.CreateMlPipeline();
            var mlModel = _modelTrainer.TrainModel(trainData, pipeline);
            var result = _modelEvaluator.EvaluateModel(testData, mlModel);
            var priceprediction = _pricePredictor.MakePredictionWithTheModel(mlModel);
            ModelScoreRequestObject request = new ModelScoreRequestObject();
            request.ModelEvaluation = result;
            request.ModelPricePrediction = priceprediction;
            return request;

        }
    }
}
