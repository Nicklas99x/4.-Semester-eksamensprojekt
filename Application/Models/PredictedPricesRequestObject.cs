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
        //Property
        public float PredictedPrices;
        //Method to get prices that are persisted in a datasource outside the application (Sql DB)
        public List<PredictedPricesRequestObject> GetPredictedPrices()
        {
            //Make a list to collect records
            List<PredictedPricesRequestObject> predictedPrices = new List<PredictedPricesRequestObject>();

            //Connectionstring (this needs to be moved later)
            var connString = "Data Source=NICKLASPC;Initial Catalog=EksamensprojektDB;User ID=Machine-Learner25;Password=Mir@cleUser234987";

            //Performing sql action
            using (SqlConnection connection = new SqlConnection(connString))
            {
                //Using a stored procedure which is defined outside of the application
                //To get the records that will be returned in the list
                string cmdText = $"SelectAllPredictedPrices";
                SqlCommand cmd = new SqlCommand(cmdText, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                //Make a reader that can read the data from the DB
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Read and add each record in the DB to the list
                    //Each record found will be added to the list through a request object
                    //These request objects contain the property PredictedPrices which will
                    //Store the value that we pick up from each DB record
                    //This object is then added to the list
                    //Do this until the reader no longer reads from the DB therefor the while loop is used
                    PredictedPricesRequestObject predictedPrice = new PredictedPricesRequestObject();
                    predictedPrice.PredictedPrices = Convert.ToSingle(reader["Price"].ToString());
                    predictedPrices.Add(predictedPrice);
                }
                connection.Close();
                //Return the list of predictedprices
                return predictedPrices;
            }
        }
    }
}
