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

namespace Machine_Learning.Container
{
    public class DataLoader : IDataLoader
    {
        protected readonly MLContext context = new MLContext();
        protected readonly HousePriceData _housePriceData;

        public DataLoader()
        {
        }

        public DataLoader(HousePriceData housePriceData)
        {
            _housePriceData = housePriceData;
        }
        public IDataView LoadDataset()
        {
            IDataView data = context.Data.LoadFromTextFile<HousePriceData>("C:/Users/nicklas/source/repos/4.-Semester-eksamensprojekt/Machine-Learning/Data/kc_house_data.csv",
                hasHeader: true,
                separatorChar: ',');
            return data;
        }
    }
}
