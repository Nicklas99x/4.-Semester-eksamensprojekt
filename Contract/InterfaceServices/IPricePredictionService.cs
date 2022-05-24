using Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.InterfaceServices
{
    public interface IPricePredictionService
    {
        //Interface that demands the methods with the following returntypes:
        //Task<PricePredictionDto> this also has a PricePredictionDto as inputparameter
        //Task<List<PredictedPriceDto>>
        Task<PricePredictionDto> PredictPrice(PricePredictionDto pricePredictionDto);
        Task<List<PredictedPriceDto>> GetPredictedPrices();
    }
}
