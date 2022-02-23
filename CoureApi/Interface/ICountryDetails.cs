using CoureApi.Dtos;
using CoureApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoureApi.Interface
{
    public interface ICountryDetails
    {
        CountryDetailDto AddUpdate(CountryDetailsModel model);
        //bool Delete(int Id);
        List<GetResponse> Get(string PhoneNumber); 
 
    }
}
