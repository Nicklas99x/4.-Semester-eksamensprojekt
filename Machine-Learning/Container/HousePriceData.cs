using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine_Learning
{
    public class HousePriceData
    {
        //Model of the dataset which is used to train and evaluate the model
        [LoadColumn(0)]
        public string Id { get; set; }
        [LoadColumn(1)]
        public string Date { get; set; }
        //his is the LabelColumn
        [LoadColumn(2), ColumnName("Label")]
        public float Price { get; set; }
        [LoadColumn(3)]
        public string Bedrooms { get; set; }
        [LoadColumn(4)]
        public string Bathrooms { get; set; }
        [LoadColumn(5)]
        public string Sqft_living { get; set; }
        [LoadColumn(6)]
        public string Sqft_lot { get; set; }
        [LoadColumn(7)]
        public string Floors { get; set; }
        [LoadColumn(8)]
        public string Waterfront { get; set; }
        [LoadColumn(9)]
        public string View { get; set; }
        [LoadColumn(10)]
        public string Condition { get; set; }
        [LoadColumn(11)]
        public string Grade { get; set; }
        [LoadColumn(12)]
        public string Sqft_above { get; set; }
        [LoadColumn(13)]
        public string Sqft_basement { get; set; }
        [LoadColumn(14)]
        public string Yr_built { get; set; }
        [LoadColumn(15)]
        public string Yr_renovated { get; set; }
        [LoadColumn(16)]
        public string Zipcode { get; set; }
        [LoadColumn(17)]
        public string Lat { get; set; }
        [LoadColumn(18)]
        public string Long1 { get; set; }
        [LoadColumn(19)]
        public string Sqft_living15 { get; set; }
        [LoadColumn(20)]
        public string Sqft_lot15 { get; set; }
    }
}
