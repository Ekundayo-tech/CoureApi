using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoureApi.Model
{
    public class GetResponse 
    { 
        public string Number { get; set; }
        public GetCountry GetCountry { get; set; }
        public List<GetCountryDetails> GetCountryDetails { get; set; }
    }
    public class GetCountry
    {
        public string CountryCode { get; set; }
        public string Name  { get; set; }
        public string CountryIso { get; set; }
    }
    public class GetCountryDetails
    {
        public string Operator { get; set; }
        public string OperatorCode { get; set; } 
    }
}
