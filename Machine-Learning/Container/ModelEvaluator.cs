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
        //Evaluating the model
        public double EvaluateModel(IDataView testData, TransformerChain<RegressionPredictionTransformer<Microsoft.ML.Trainers.FastTree.FastTreeRegressionModelParameters>> mLModel)
        {
            IDataView predictions = mLModel.Transform(testData);
            //Evaluate the model
            var metrics = context.Regression.Evaluate(predictions);

            //Store the result of the evaluation in a variable of type double
            var result = metrics.RSquared;
            //Return the modelevaluationscore so that it may be accesed by other parts of the application
            return result;
        }
    }
}
