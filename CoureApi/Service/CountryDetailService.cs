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
        //private readonly ICountryDetails _coutry;

        public CountryDetailService(DataContext context)
        {
            _context = context;
            //_coutry = coutry;
        }
        public CountryDetailDto AddUpdate(CountryDetailsModel model)
        {
            var request = _context.CountryDetails.FirstOrDefault(x => x.Opeartor == model.Opeartor);
            if (request == null)
            {
                request = new CountryDetails()
                {
                    //Id = model.Id,
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

        //public bool Delete(int Id)
        //{
        //    var request = _context.CountryDetails.FirstOrDefault(x => x.Id == Id);
        //    if(request != null)
        //    {
        //        _context.CountryDetails.Remove(request);
        //        return true;
        //    }
        //    return false;
        //}

        public GetResponse Get(string PhoneNumber)
        {
            var res = new GetResponse();
            var get = _context.Country.Include(x => x.CountryDetails).FirstOrDefault(x => x.CountryCode == new string(PhoneNumber.Take(3).ToArray()));
            var details = _context.CountryDetails.Include(x => x.Country).Where(x => x.CountryId == x.Country.Id).ToList();

            if (get != null && details != null)
            {

                foreach (var m in details.ToList())
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
                        GetCountryDetails = new List<GetCountryDetails>
                        {
                            new GetCountryDetails
                            {
                                Operator = details.FirstOrDefault(x => x.Id == m.Id).Opeartor,
                                OperatorCode = details.FirstOrDefault(x => x.Id == m.Id).OperatorCode,
                            },
                        }.ToList()
                    };
                }
            }
            return res;
        }
    }
}
        
 
     
