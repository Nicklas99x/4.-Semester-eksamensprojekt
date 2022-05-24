using Application.Models;
using Contract.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricePredictionController : ControllerBase
    {
        //DependencyInjection
        private readonly IPricePredictionRequestObject _pricePredictionRequestObject;
        private readonly IPredictedPricesRequestObject _predictedPricesRequestObject;

        public PricePredictionController(IPricePredictionRequestObject pricePredictionRequestObject, IPredictedPricesRequestObject predictedPricesRequestObject)
        {
            _pricePredictionRequestObject = pricePredictionRequestObject;
            _predictedPricesRequestObject = predictedPricesRequestObject;
        }

        // GET: api/<PricePredictionController>
        [HttpGet("/GetPricePrediction")]
        //GetRequest
        public List<PredictedPriceDto> Get()
        {
            //GetPrices
            var predictedPrices = _predictedPricesRequestObject.GetPredictedPrices();
            var dto = new List<PredictedPriceDto>();
            predictedPrices.ForEach(a => dto.Add(new PredictedPriceDto
            {
                PredictedPrice = a.PredictedPrices
            }));
            return dto;
        }

        // POST api/<PricePredictionController>
        [HttpPost("/Prediction")]
        //HttpPostRequest
        public void Post([FromBody] PricePredictionDto pricePredictionDto)
        {
            //Make a new PricepredictionDto
            //and set its propery values to be equal to the values found
            //inside the request object
            _pricePredictionRequestObject.PredictPrice(new PricePredictionRequestObject 
            {
                Id = pricePredictionDto.Id,
                Date = pricePredictionDto.Date,
                Bedrooms = pricePredictionDto.Bedrooms,
                Bathrooms = pricePredictionDto.Bathrooms,
                Sqft_living = pricePredictionDto.Sqft_living,
                Sqft_lot = pricePredictionDto.Sqft_lot,
                Floors = pricePredictionDto.Floors,
                Waterfront = pricePredictionDto.Waterfront,
                View = pricePredictionDto.View,
                Condition = pricePredictionDto.Condition,
                Grade = pricePredictionDto.Grade,
                Sqft_above = pricePredictionDto.Sqft_above,
                Sqft_basement = pricePredictionDto.Sqft_basement,
                Yr_built = pricePredictionDto.Yr_built,
                Yr_renovated = pricePredictionDto.Yr_renovated,
                Zipcode = pricePredictionDto.Zipcode,
                Lat = pricePredictionDto.Lat,
                Long1 = pricePredictionDto.Long1,
                Sqft_living15 = pricePredictionDto.Sqft_living15,
                Sqft_lot15 = pricePredictionDto.Sqft_lot15
            });
        }
    }
}
