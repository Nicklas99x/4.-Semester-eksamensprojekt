using Machine_Learning.Interfaces;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine_Learning.Container
{
    public class DataManager : IDataManager
    {
        protected readonly MLContext context = new MLContext();

        public DataOperationsCatalog.TrainTestData SplitDataIntoTwoGroups(IDataView data)
        {
            var split = context.Data.TrainTestSplit(data, testFraction: 0.2);

            return split;
        }
        public IDataView CreateTrainingSet(DataOperationsCatalog.TrainTestData split)
        {
            var trainData = split.TrainSet;
            return trainData;
        }
        public IDataView CreateTestSet(IDataView trainData, DataOperationsCatalog.TrainTestData split)
        {
            var testData = split.TestSet;
            return testData;
        }
    }
}
