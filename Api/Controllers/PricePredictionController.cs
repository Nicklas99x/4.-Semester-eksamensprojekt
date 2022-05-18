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
        private readonly IPricePredictionRequestObject _pricepredictionRequestObject;

        public PricePredictionController(IPricePredictionRequestObject pricepredictionRequestObject)
        {
            _pricepredictionRequestObject = pricepredictionRequestObject;
        }

        // GET: api/<PricePredictionController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

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
            
            _pricepredictionRequestObject.PredictPrice(new PricePredictionRequestObject 
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

        // PUT api/<PricePredictionController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PricePredictionController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
