using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class PredictedPricesRequestObject : IPredictedPricesRequestObject
    {
        public float PredictedPrices;
        public List<PredictedPricesRequestObject> GetPredictedPrices()
        {
            List<PredictedPricesRequestObject> predictedPrices = new List<PredictedPricesRequestObject>();

            var connString = "Data Source=NICKLASPC;Initial Catalog=EksamensprojektDB;User ID=Machine-Learner25;Password=Mir@cleUser234987";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                string cmdText = $"SelectAllPredictedPrices";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PredictedPricesRequestObject predictedPrice = new PredictedPricesRequestObject();
                    predictedPrice.PredictedPrices = Convert.ToSingle(reader["Price"].ToString());
                    predictedPrices.Add(predictedPrice);
                }
                connection.Close();
                return predictedPrices;
            }
        }
    }
}
