using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine_Learning
{
    public class HousePriceData
    {
        [LoadColumn(0)]
        public float id { get; set; }
        [LoadColumn(1)]
        public string date { get; set; }
        [LoadColumn(2), ColumnName("Label")]
        public float price { get; set; }
        [LoadColumn(3)]
        public int bedrooms { get; set; }
        [LoadColumn(4)]
        public int bathrooms { get; set; }
        [LoadColumn(5)]
        public int sqft_living { get; set; }
        [LoadColumn(6)]
        public int sqft_lot { get; set; }
        [LoadColumn(7)]
        public int floors { get; set; }
        [LoadColumn(8)]
        public int waterfront { get; set; }
        [LoadColumn(9)]
        public int view { get; set; }
        [LoadColumn(10)]
        public int condition { get; set; }
        [LoadColumn(11)]
        public int grade { get; set; }
        [LoadColumn(12)]
        public int sqft_above { get; set; }
        [LoadColumn(13)]
        public int sqft_basement { get; set; }
        [LoadColumn(14)]
        public int yr_built { get; set; }
        [LoadColumn(15)]
        public int yr_renovated { get; set; }
        [LoadColumn(16)]
        public int zipcode { get; set; }
        [LoadColumn(17)]
        public int lat { get; set; }
        [LoadColumn(18)]
        public int long1 { get; set; }
        [LoadColumn(19)]
        public int sqft_living15 { get; set; }
        [LoadColumn(20)]
        public int sqft_lot15 { get; set; }
        public void LoadDataset()
        {
            MLContext context = new MLContext();

            IDataView data = context.Data.LoadFromTextFile<HousePriceData>("C:/Users/nicklas/source/repos/4.-Semester-eksamensprojekt/Machine-Learning/Data/kc_house_data.csv",
                hasHeader: true,
                separatorChar: ',');

            var split = context.Data.TrainTestSplit(data, testFraction: 0.2);
            var trainData = split.TrainSet;
            var testData = split.TestSet;

            var pipeline = context.Transforms.Text.FeaturizeText("Text", "date")
                .Append(context.Transforms.Concatenate("Features", "Text"))
                .Append(context.Regression.Trainers.Sdca());

            var mLModel = pipeline.Fit(trainData);

            IDataView predictions = mLModel.Transform(testData);

            var metrics = context.Regression.Evaluate(predictions);

            Console.WriteLine($"R^2 the rsquare coefficient value of this model is: {metrics.RSquared}");

            var predictionData = context.Model.CreatePredictionEngine<HousePriceData, Output>(mLModel);

            var input = new HousePriceData
            {
                id = 7129300520,
                date = "2014-10-13",
                price = 221900,
                bedrooms = 3,
                bathrooms = 1,
                sqft_living = 1180,
                sqft_lot = 5650,
                floors = 1,
                waterfront = 0,
                view = 0,
                condition = 3,
                grade = 7,
                sqft_above = 1180,
                sqft_basement = 0,
                yr_built = 1955,
                yr_renovated = 0,
                zipcode = 98178,
                lat = 47,
                long1 = -122,
                sqft_living15 = 1340,
                sqft_lot15 = 5650

            };

            var predictionWithData = predictionData.Predict(input);

            Console.WriteLine($"The predicted price of the house is {predictionWithData.Score}");
        }
    }
    public class Output
    {
        public float Score { get; set; }
    }
}
