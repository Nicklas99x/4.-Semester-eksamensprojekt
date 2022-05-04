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
        //[LoadColumn(0)]
        //public float Id { get; set; }
        //[LoadColumn(1)]
        //public string Date { get; set; }
        [LoadColumn(2), ColumnName("Label")]
        public float Price { get; set; }
        [LoadColumn(3)]
        public int Bedrooms { get; set; }
        [LoadColumn(4)]
        public int Bathrooms { get; set; }
        [LoadColumn(5)]
        public int Sqft_living { get; set; }
        [LoadColumn(6)]
        public int Sqft_lot { get; set; }
        [LoadColumn(7)]
        public int Floors { get; set; }
        [LoadColumn(8)]
        public int Waterfront { get; set; }
        [LoadColumn(9)]
        public int View { get; set; }
        //[LoadColumn(10)]
        //public int Condition { get; set; }
        [LoadColumn(11)]
        public string Grade { get; set; }
        [LoadColumn(12)]
        public int Sqft_above { get; set; }
        [LoadColumn(13)]
        public int Sqft_basement { get; set; }
        //[LoadColumn(14)]
        //public int Yr_built { get; set; }
        //[LoadColumn(15)]
        //public int Yr_renovated { get; set; }
        //[LoadColumn(16)]
        //public int Zipcode { get; set; }
        //[LoadColumn(17)]
        //public int Lat { get; set; }
        //[LoadColumn(18)]
        //public int Long1 { get; set; }
        [LoadColumn(19)]
        public int Sqft_living15 { get; set; }
        //[LoadColumn(20)]
        //public int Sqft_lot15 { get; set; }
        public void LoadDataset()
        {
            MLContext context = new MLContext();

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

            var predictionData = context.Model.CreatePredictionEngine<HousePriceData, Output>(mLModel);

            var input = new HousePriceData
            {
                //Id = 7129300520,
                //Date = "2014-10-13",
                Price = 221900,
                Bedrooms = 3,
                Bathrooms = 1,
                Sqft_living = 1180,
                Sqft_lot = 5650,
                Floors = 1,
                Waterfront = 0,
                View = 0,
                //Condition = 3,
                //Grade = 7,
                Sqft_above = 1180,
                Sqft_basement = 0,
                //Yr_built = 1955,
                //Yr_renovated = 0,
                //Zipcode = 98178,
                //Lat = 47,
                //Long1 = -122,
                Sqft_living15 = 1340,
                //Sqft_lot15 = 5650

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
