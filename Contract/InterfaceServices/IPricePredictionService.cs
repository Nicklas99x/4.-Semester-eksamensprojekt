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
        Task<PricePredictionDto> PredictPrice(PricePredictionDto pricePredictionDto);
        Task<List<PredictedPriceDto>> GetPredictedPrices();
    }
}
