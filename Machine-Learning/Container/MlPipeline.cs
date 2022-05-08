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
    public class MlPipeline : IMLPipeline
    {
        protected readonly MLContext context = new MLContext();
        public EstimatorChain<RegressionPredictionTransformer<Microsoft.ML.Trainers.LinearRegressionModelParameters>> CreateMlPipeline()
        {
            var pipeline = context.Transforms.Text.FeaturizeText("Text", "Grade")
                        .Append(context.Transforms.Concatenate("Features", "Text"))
                        .Append(context.Regression.Trainers.Sdca());
            return pipeline;
        }
    }
}
