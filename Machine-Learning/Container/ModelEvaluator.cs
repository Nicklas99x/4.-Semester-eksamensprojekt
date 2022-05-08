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
    public class ModelEvaluator : IModelEvaluator
    {
        protected readonly MLContext context = new MLContext();
        public void EvaluateModel(IDataView testData, TransformerChain<RegressionPredictionTransformer<Microsoft.ML.Trainers.LinearRegressionModelParameters>> mLModel)
        {
            IDataView predictions = mLModel.Transform(testData);
            var metrics = context.Regression.Evaluate(predictions);

            Console.WriteLine($"R^2 the RSquare coefficient value of this model is: {metrics.RSquared}");
        }
    }
}
