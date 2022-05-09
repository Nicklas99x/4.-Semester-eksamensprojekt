using Machine_Learning.Container;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Machine_Learning
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create instances to perform method calls
            DataLoader dataLoader = new DataLoader();
            DataManager dataManager = new DataManager();
            MlPipeline mlPipeline = new MlPipeline();
            ModelTrainer modelTrainer = new ModelTrainer();
            ModelEvaluator modelEvaluator = new ModelEvaluator();
            PricePredictor pricePredictor = new PricePredictor();

            //Perform method calls and store them in variables which are
            //Needed as input in the methods that follow
            var data = dataLoader.LoadDataset();
            var split = dataManager.SplitDataIntoTwoGroups(data);
            var trainingData = dataManager.CreateTrainingSet(split);
            var testData = dataManager.CreateTestSet(split);
            var pipeline = mlPipeline.CreateMlPipeline();
            var mLModel = modelTrainer.TrainModel(trainingData, pipeline);

            var result = modelEvaluator.EvaluateModel(testData, mLModel);
            var predictionResult = pricePredictor.MakePredictionWithTheModel(mLModel);
            Console.WriteLine(result);
            Console.WriteLine(predictionResult);
            //Console readline so that the program doesn't stop
            Console.ReadLine();
        }
    }
}
