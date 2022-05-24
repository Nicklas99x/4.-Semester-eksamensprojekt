using Machine_Learning;
using Machine_Learning.Interfaces;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class PricePredictionRequestObject : IPricePredictionRequestObject
    {
        //Properies that match a model from the core of this app (HousePriceData)
        public string Id { get; set; }
        public string Date { get; set; }
        public double Price { get; set; }
        public string Bedrooms { get; set; }
        public string Bathrooms { get; set; }
        public string Sqft_living { get; set; }
        public string Sqft_lot { get; set; }
        public string Floors { get; set; }
        public string Waterfront { get; set; }
        public string View { get; set; }
        public string Condition { get; set; }
        public string Grade { get; set; }
        public string Sqft_above { get; set; }
        public string Sqft_basement { get; set; }
        public string Yr_built { get; set; }
        public string Yr_renovated { get; set; }
        public string Zipcode { get; set; }
        public string Lat { get; set; }
        public string Long1 { get; set; }
        public string Sqft_living15 { get; set; }
        public string Sqft_lot15 { get; set; }
        //Inject dependencies
        protected readonly IDataLoader _dataLoader;
        protected readonly IDataManager _dataManager;
        protected readonly IMLPipeline _mlPipeline;
        protected readonly IModelTrainer _modelTrainer;
        //Add HousePriceData and PredictionOutput which are defined under the project
        //Machine-Learning
        protected readonly HousePriceData _housePriceData;
        protected readonly PredictionOutput _predictionOutput;
        //Add an instance of MlContext to perform prediction
        protected readonly MLContext context = new MLContext();

        public PricePredictionRequestObject()
        {
        }

        //Constructor injection of dependencies
        public PricePredictionRequestObject(
            IDataLoader dataLoader,
            IDataManager dataManager,
            IMLPipeline mlPipeline,
            IModelTrainer modelTrainer)
        {
            _dataLoader = dataLoader;
            _dataManager = dataManager;
            _mlPipeline = mlPipeline;
            _modelTrainer = modelTrainer;
        }

        //Predicting price
        public void PredictPrice(PricePredictionRequestObject pricePredictionRequestObject)
        {
            //Using DI to call these methods
            var data = _dataLoader.LoadDataset();
            var dataSplit = _dataManager.SplitDataIntoTwoGroups(data);
            var trainData = _dataManager.CreateTrainingSet(dataSplit);
            var pipeline = _mlPipeline.CreateMlPipeline();
            var mlModel = _modelTrainer.TrainModel(trainData, pipeline);

            //Create a predictionengine to perform a prediction from our machinelearning model
            var predictionData = context.Model.CreatePredictionEngine<HousePriceData, PredictionOutput>(mlModel);

            //Create prediction input
            var price = new HousePriceData
            {
                //Set the input to the inserted input from the frontend which is
                //Picked up by the Api and sent into here
                Id = pricePredictionRequestObject.Id,
                Date = pricePredictionRequestObject.Date,
                Bedrooms = pricePredictionRequestObject.Bedrooms,
                Bathrooms = pricePredictionRequestObject.Bathrooms,
                Sqft_living = pricePredictionRequestObject.Sqft_living,
                Sqft_lot = pricePredictionRequestObject.Sqft_lot,
                Floors = pricePredictionRequestObject.Floors,
                Waterfront = pricePredictionRequestObject.Waterfront,
                View = pricePredictionRequestObject.View,
                Condition = pricePredictionRequestObject.Condition,
                Grade = pricePredictionRequestObject.Grade,
                Sqft_above = pricePredictionRequestObject.Sqft_above,
                Sqft_basement = pricePredictionRequestObject.Sqft_basement,
                Yr_built = pricePredictionRequestObject.Yr_built,
                Yr_renovated = pricePredictionRequestObject.Yr_renovated,
                Zipcode = pricePredictionRequestObject.Zipcode,
                Lat = pricePredictionRequestObject.Lat,
                Long1 = pricePredictionRequestObject.Long1,
                Sqft_living15 = pricePredictionRequestObject.Sqft_living15,
                Sqft_lot15 = pricePredictionRequestObject.Sqft_lot15
            };

            //Perform prediction
            var prediction = predictionData.Predict(price);
            //Store the predicted value in this varible of type float
            var Price = prediction.Score;

            //Constring (will be moved later)
            var connString = "Data Source=NICKLASPC;Initial Catalog=EksamensprojektDB;User ID=Machine-Learner25;Password=Mir@cleUser234987";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                //This WONT be sql injected by attackers/hacker
                //Parameterized query
                string cmdText = $"Insert into PredictedPrices (Price) Values(@Price)";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                //Add parameter to protect against SqlInjection
                cmd.Parameters.AddWithValue("Price", Price);
                connection.Open();
                //Execute the query in the SqlCommand
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
