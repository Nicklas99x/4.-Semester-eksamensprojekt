using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Machine_Learning
{
    class Program
    {
        static void Main(string[] args)
        {
            HousePriceData hpd = new HousePriceData();
            hpd.LoadDataset();
            Console.ReadLine();
        }
    }
}
