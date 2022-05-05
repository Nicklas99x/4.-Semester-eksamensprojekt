using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine_Learning
{
    public class MachineLearningModel
    {
        private readonly HousePriceData _housePriceData;
        private readonly PredictionOutput _predictionOutput;

        public MachineLearningModel()
        {
        }

        public MachineLearningModel(HousePriceData housePriceData, PredictionOutput predictionOutput)
        {
            _housePriceData = housePriceData;
            _predictionOutput = predictionOutput;
        }
        MLContext context = new MLContext();
        public void LoadDataset()
        {
            IDataView data = context.Data.LoadFromTextFile<HousePriceData>("C:/Users/nicklas/source/repos/4.-Semester-eksamensprojekt/Machine-Learning/Data/kc_house_data.csv",
                hasHeader: true,
                separatorChar: ',');

            var split = context.Data.TrainTestSplit(data, testFraction: 0.2);
            var trainData = split.TrainSet;
            var testData = split.TestSet;

            var pipeline = context.Transforms.Text.FeaturizeText("Text", "Grade")
                .Append(context.Transforms.Concatenate("Features", "Text"))
                .Append(context.Regression.Trainers.Sdca());

            var mLModel = pipeline.Fit(trainData);

            IDataView predictions = mLModel.Transform(testData);

            var metrics = context.Regression.Evaluate(predictions);

            Console.WriteLine($"R^2 the RSquare coefficient value of this model is: {metrics.RSquared}");

            var predictionData = context.Model.CreatePredictionEngine<HousePriceData, PredictionOutput>(mLModel);

            var input = new HousePriceData
            {
                Price = 2000000,
                Bedrooms = 3,
                Bathrooms = 2,
                Sqft_living = 75,
                Sqft_lot = 3050,
                Floors = 1,
                Waterfront = 0,
                View = 4,
                Grade = "9",
                Sqft_basement = 720,
                Sqft_living15 = 4110

            };

            var predictionWithData = predictionData.Predict(input);

            Console.WriteLine($"The predicted price of the house is {predictionWithData.Score}");
        }
    }
}
