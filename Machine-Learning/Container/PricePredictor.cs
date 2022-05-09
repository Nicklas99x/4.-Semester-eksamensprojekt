using Machine_Learning.Interfaces;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine_Learning
{
    public class PricePredictor : IPricePredictor
    {
        protected readonly MLContext context = new MLContext();
        protected readonly HousePriceData _housePriceData;
        protected readonly PredictionOutput _predictionOutput;

        public PricePredictor()
        {
        }

        public PricePredictor(HousePriceData housePriceData, PredictionOutput predictionOutput)
        {
            _housePriceData = housePriceData;
            _predictionOutput = predictionOutput;
        }
        public Single MakePredictionWithTheModel(TransformerChain<RegressionPredictionTransformer<Microsoft.ML.Trainers.LinearRegressionModelParameters>> mLModel)
        {
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
            var predictionResult = predictionWithData.Score;
            return predictionResult;
        }
    }
}
