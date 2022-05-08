using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine_Learning.Interfaces
{
    public interface IDataLoader
    {
        IDataView LoadDataset();
    }
}
