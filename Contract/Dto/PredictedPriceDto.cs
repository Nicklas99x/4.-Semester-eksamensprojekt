using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Dto
{
    public class PredictedPriceDto
    {
        //DataTransferObject which transfers data between Api and frontend
        public float PredictedPrice { get; set; }
    }
}
