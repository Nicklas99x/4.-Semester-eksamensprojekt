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

            //var connString = "Data Source=NICKLASPC;Initial Catalog=EksamensprojektDB;User ID=Machine-Learner25;Password=Mir@cleUser234987";

            //using (SqlConnection connection = new SqlConnection(connString))
            //{
            //    string cmdText = "execute load_data";
            //    SqlCommand cmd = new SqlCommand(cmdText, connection);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    string sqlData = cmd.CommandText.ToString();
            //    var dataLoader = context.Data.CreateDatabaseLoader<HousePriceData>();
            //    var dbSource = new DatabaseSource(SqlClientFactory.Instance, connString, sqlData);
            //    var data = dataLoader.Load(dbSource);
            //    return data;
            //}

        }
    }
}
