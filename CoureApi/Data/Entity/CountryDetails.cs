﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoureApi.Data.Entity
{
    public class CountryDetails
    {
        public int Id { get; set; }
        public string CountryId { get; set; }
        public string Opeartor { get; set; }
        public string OperatorCode { get; set; }
    }
}
