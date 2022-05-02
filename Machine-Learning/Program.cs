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
            //LoadStoredProcedure();
            LoadDataset();
            Console.ReadLine();
        }
        public static void LoadDataset()
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

            Console.WriteLine($"R^2 {metrics.RSquared}");
        }
        public class HousePriceData
        {
            [LoadColumn(0)]
            public float id { get; set; }
            [LoadColumn(1)]
            public string date { get; set; }
            [LoadColumn(2), ColumnName("Label")]
            public float price { get; set; }
            [LoadColumn(3)]
            public float bedrooms { get; set; }
            [LoadColumn(4)]
            public float bathrooms { get; set; }
            [LoadColumn(5)]
            public float sqft_living { get; set; }
            [LoadColumn(6)]
            public float sqft_lot { get; set; }
            [LoadColumn(7)]
            public float floors { get; set; }
            [LoadColumn(8)]
            public float waterfront { get; set; }
            [LoadColumn(9)]
            public float view { get; set; }
            [LoadColumn(10)]
            public float condition { get; set; }
            [LoadColumn(11)]
            public float grade { get; set; }
            [LoadColumn(12)]
            public float sqft_above { get; set; }
            [LoadColumn(13)]
            public float sqft_basement { get; set; }
            [LoadColumn(14)]
            public float yr_built { get; set; }
            [LoadColumn(15)]
            public float yr_renovated { get; set; }
            [LoadColumn(16)]
            public float zipcode { get; set; }
            [LoadColumn(17)]
            public float lat { get; set; }
            [LoadColumn(18)]
            public float long1 { get; set; }
            [LoadColumn(19)]
            public float sqft_living15 { get; set; }
            [LoadColumn(20)]
            public float sqft_lot15 { get; set; }
        }
        //public static void LoadStoredProcedure()
        //{
        //    string connString = "Data Source=NICKLASPC;Initial Catalog=EksamensprojektDB;User ID=Machine-Learner25;Password=Mir@cleUser234987";

        //    SqlConnection connection = new SqlConnection(connString);
        //    SqlCommand cmd = new SqlCommand("load_data", connection);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    connection.Open();

        //    using (SqlDataReader reader = cmd.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            string Id = reader["Id"].ToString();
        //        }
        //    }
        //    connection.Close();
        //}
    }
}
