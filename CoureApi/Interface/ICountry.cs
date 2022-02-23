using CoureApi.Dtos;
using CoureApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoureApi.Interface
{
    public interface ICountry
    {
        CountryDto AddUpdate(CountryModel model);
        //bool Delete(int Id);
        CountryDto Get(string PhoneNumber);
    }
}
