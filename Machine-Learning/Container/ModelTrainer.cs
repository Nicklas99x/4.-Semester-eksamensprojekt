using Machine_Learning.Interfaces;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine_Learning.Container
{
    public class ModelTrainer : IModelTrainer
    {
        protected readonly MLContext context = new MLContext();
        public TransformerChain<RegressionPredictionTransformer<Microsoft.ML.Trainers.LinearRegressionModelParameters>> TrainModel(IDataView trainData, EstimatorChain<RegressionPredictionTransformer<Microsoft.ML.Trainers.LinearRegressionModelParameters>> pipeline)
        {
            var mLModel = pipeline.Fit(trainData);
            return mLModel;
        }
    }
}
