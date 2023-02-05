using CoureApi.Interface;
using CoureApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoureApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoureController : ControllerBase
    {
        private readonly ICountryDetails _countryDetails;
        private readonly ICountry _country;
        private readonly ILogger<CoureController> _logger;

        public CoureController(ILogger<CoureController> logger, ICountryDetails countryDetails, ICountry country)
        {
            _logger = logger;
            _countryDetails = countryDetails;
            _country = country;
        }

        [HttpGet]
        public IActionResult GetDetails(string PhoneNumber)
        {
            var res = _countryDetails.Get(PhoneNumber);
            return Ok(res);
        }  
        [HttpPost("Details")]
        public IActionResult AddDetails(CountryDetailsModel model)
        {
            var res = _countryDetails.AddUpdate(model);
            return Ok(res);
        }
        [HttpPost]
        public IActionResult AddCountry(CountryModel model)
        {
            var res = _country.AddUpdate(model);
            return Ok(res);
        }
        //[HttpDelete]
        //public IActionResult DeleteCountry(int Id)
        //{
        //    var res = _country.Delete(Id);
        //    return Ok(res);
        //}
        //[HttpDelete("Details")]
        //public IActionResult DelCountryDetails(int Id)
        //{
        //    var res = _country.Delete(Id);
        //    return Ok(res);
        //}
    }
}
