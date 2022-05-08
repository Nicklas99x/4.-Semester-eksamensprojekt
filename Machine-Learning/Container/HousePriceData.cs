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
        [LoadColumn(2), ColumnName("Label")]
        public float Price { get; set; }
        [LoadColumn(3)]
        public float Bedrooms { get; set; }
        [LoadColumn(4)]
        public float Bathrooms { get; set; }
        [LoadColumn(5)]
        public float Sqft_living { get; set; }
        [LoadColumn(6)]
        public float Sqft_lot { get; set; }
        [LoadColumn(7)]
        public float Floors { get; set; }
        [LoadColumn(8)]
        public float Waterfront { get; set; }
        [LoadColumn(9)]
        public float View { get; set; }
        [LoadColumn(11)]
        public string Grade { get; set; }
        [LoadColumn(12)]
        public float Sqft_above { get; set; }
        [LoadColumn(13)]
        public float Sqft_basement { get; set; }
        [LoadColumn(19)]
        public float Sqft_living15 { get; set; }
    }
}
