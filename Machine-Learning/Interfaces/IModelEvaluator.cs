using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine_Learning.Interfaces
{
    public interface IModelEvaluator
    {
        double EvaluateModel(IDataView testData, TransformerChain<RegressionPredictionTransformer<Microsoft.ML.Trainers.LinearRegressionModelParameters>> mLModel);
    }
}
