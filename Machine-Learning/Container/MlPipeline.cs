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
        //Acces MlContext
        protected readonly MLContext context = new MLContext();
        public EstimatorChain<RegressionPredictionTransformer<Microsoft.ML.Trainers.FastTree.FastTreeRegressionModelParameters>> CreateMlPipeline()
        {
            //Make a pipeline which prepares the data before training the model
            //All data input from the file is in the string format
            //which must be converted to Float/Single inorder to be
            //Compatible with MlNet
            var pipeline = context.Transforms.Text.FeaturizeText("Text", "Id")
                        .Append(context.Transforms.Text.FeaturizeText("Text2", "Date"))
                        .Append(context.Transforms.Text.FeaturizeText("Text3", "Bedrooms"))
                        .Append(context.Transforms.Text.FeaturizeText("Text4", "Bathrooms"))
                        .Append(context.Transforms.Text.FeaturizeText("Text5", "Sqft_living"))
                        .Append(context.Transforms.Text.FeaturizeText("Text6", "Sqft_lot"))
                        .Append(context.Transforms.Text.FeaturizeText("Text7", "Floors"))
                        .Append(context.Transforms.Text.FeaturizeText("Text8", "Waterfront"))
                        .Append(context.Transforms.Text.FeaturizeText("Text9", "View"))
                        .Append(context.Transforms.Text.FeaturizeText("Text10", "Condition"))
                        .Append(context.Transforms.Text.FeaturizeText("Text11", "Grade"))
                        .Append(context.Transforms.Text.FeaturizeText("Text12", "Sqft_above"))
                        .Append(context.Transforms.Text.FeaturizeText("Text13", "Sqft_basement"))
                        .Append(context.Transforms.Text.FeaturizeText("Text14", "Yr_built"))
                        .Append(context.Transforms.Text.FeaturizeText("Text15", "Yr_renovated"))
                        .Append(context.Transforms.Text.FeaturizeText("Text16", "Zipcode"))
                        .Append(context.Transforms.Text.FeaturizeText("Text17", "Lat"))
                        .Append(context.Transforms.Text.FeaturizeText("Text18", "Long1"))
                        .Append(context.Transforms.Text.FeaturizeText("Text19", "Sqft_living15"))
                        .Append(context.Transforms.Text.FeaturizeText("Text20", "Sqft_lot15"))
                        .Append(context.Transforms.Concatenate("Features", "Text", "Text2", "Text3", "Text4", "Text5", "Text6", "Text7", "Text8", "Text9", "Text10", "Text11", "Text12", "Text13", "Text14", "Text15", "Text16", "Text17", "Text18", "Text19", "Text20"))
                        //Using FastTreeRegression as the algoritm for training this prediction model
                        .Append(context.Regression.Trainers.FastTree());
            return pipeline;
        }
    }
}
