using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface IPricePredictionRequestObject
    {
        //A void method with a object of type PricePredictionRequestObject as inputparameter
        void PredictPrice(PricePredictionRequestObject pricePredictionRequestObject);
    }
}
