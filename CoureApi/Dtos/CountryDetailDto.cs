﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoureApi.Dtos
{
    public class CountryDetailDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Opeartor { get; set; }
        public string OperatorCode { get; set; }
    }
}
