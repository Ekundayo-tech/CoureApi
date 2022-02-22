using CoureApi.Data.Entity;
using CoureApi.Dtos;
using CoureApi.Interface;
using CoureApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoureApi.Service
{
    public class CountryDetailService : ICountryDetails
    {
        private readonly DataContext _context;
        private readonly ICountryDetails _coutry;
 
        public CountryDetailService(DataContext context, ICountryDetails coutry)
        {
            _context = context;
            _coutry = coutry;
        }
        public CountryDetailDto AddUpdate(CountryDetailsModel model)
        {
            var request = _context.CountryDetails.FirstOrDefault(x => x.Id == model.Id);
            if (request == null)
            {
                request = new CountryDetails()
                {
                    Id = model.Id,
                    CountryId = model.CountryId,
                    Opeartor = model.Opeartor,
                    OperatorCode = model.OperatorCode
                };
                _context.CountryDetails.Add(request);
            }
            else
            {
                request.CountryId = model.CountryId;
                request.Opeartor = model.Opeartor;
                request.OperatorCode = model.OperatorCode;
            }
            _context.SaveChanges();
            return new CountryDetailDto { Id = request.Id, CountryId = request.CountryId, Opeartor = request.Opeartor, OperatorCode = request.OperatorCode };
        }

        public GetResponse Get(string PhoneNumber)
        {
            var res = new GetResponse();
            var get = _context.Country.Include(x=>x.CountryDetails).FirstOrDefault(x => x.CountryCode == new string(PhoneNumber.Take(3).ToArray()));
            //var details = _context.CountryDetails.FirstOrDefault(x=>x.CountryId == get.CountryDetails.CountryId);
            var details = _coutry.Get(PhoneNumber);
            if(get != null)
            {
                res = new GetResponse
                {
                    Number = PhoneNumber,
                    GetCountry = new GetCountry
                    {
                        CountryCode = get.CountryCode,
                        Name = get.Name,
                        CountryIso = get.CountryIso

                    },
                    GetCountryDetails = new GetCountryDetails
                    {
                        Operator = details.Opeartor,
                        OperatorCode = details.OperatorCode
                    }
                };
            };
                
            return res;
        }

    }

}
