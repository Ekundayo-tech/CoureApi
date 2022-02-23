using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoureApi.Data.Entity
{
    public class CountryDetails
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Opeartor { get; set; }
        public string OperatorCode { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
    }
}
