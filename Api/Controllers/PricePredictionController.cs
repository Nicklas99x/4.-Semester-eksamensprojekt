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
        private readonly IPricePredictionRequestObject _pricePredictionRequestObject;
        private readonly IPredictedPricesRequestObject _predictedPricesRequestObject;

        public PricePredictionController(IPricePredictionRequestObject pricePredictionRequestObject, IPredictedPricesRequestObject predictedPricesRequestObject)
        {
            _pricePredictionRequestObject = pricePredictionRequestObject;
            _predictedPricesRequestObject = predictedPricesRequestObject;
        }

        // GET: api/<PricePredictionController>
        [HttpGet("/GetPricePrediction")]
        public List<PredictedPriceDto> Get()
        {
            var predictedPrices = _predictedPricesRequestObject.GetPredictedPrices();
            var dto = new List<PredictedPriceDto>();
            predictedPrices.ForEach(a => dto.Add(new PredictedPriceDto
            {
                PredictedPrice = a.PredictedPrices
            }));
            return dto;
        }

        //// GET api/<PricePredictionController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<PricePredictionController>
        [HttpPost("/Prediction")]
        public void Post([FromBody] PricePredictionDto pricePredictionDto)
        {
            
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

        //// DELETE api/<PricePredictionController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
