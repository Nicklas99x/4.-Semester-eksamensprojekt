using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Dto
{
    public class PricePredictionDto
    {
        //DataTransferObject which transfers data between Api and frontend
        public string Id { get; set; }
        public string Date { get; set; }
        public string Bedrooms { get; set; }
        public string Bathrooms { get; set; }
        public string Sqft_living { get; set; }
        public string Sqft_lot { get; set; }
        public string Floors { get; set; }
        public string Waterfront { get; set; }
        public string View { get; set; }
        public string Condition { get; set; }
        public string Grade { get; set; }
        public string Sqft_above { get; set; }
        public string Sqft_basement { get; set; }
        public string Yr_built { get; set; }
        public string Yr_renovated { get; set; }
        public string Zipcode { get; set; }
        public string Lat { get; set; }
        public string Long1 { get; set; }
        public string Sqft_living15 { get; set; }
        public string Sqft_lot15 { get; set; }
    }
}
