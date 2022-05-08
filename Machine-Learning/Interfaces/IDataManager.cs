﻿using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine_Learning.Interfaces
{
    public interface IDataManager
    {
        DataOperationsCatalog.TrainTestData SplitDataIntoTwoGroups(IDataView data);
        IDataView CreateTrainingSet(DataOperationsCatalog.TrainTestData split);
        IDataView CreateTestSet(IDataView trainData, DataOperationsCatalog.TrainTestData split);
    }
}