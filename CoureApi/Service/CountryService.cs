using CoureApi.Data.Entity;
using CoureApi.Dtos;
using CoureApi.Interface;
using CoureApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoureApi.Service
{
    public class CountryService: ICountry
    {
        private readonly DataContext _context;
        public CountryService(DataContext context)
        {
            _context = context;
        }

        public CountryDto AddUpdate(CountryModel model)
        {
            var request = _context.Country.FirstOrDefault(x => x.Id == model.Id);
            if(request == null)
            {
                request = new Country()
                {
                    Id = model.Id,
                    CountryCode = model.CountryCode,
                    CountryIso = model.CountryIso,
                    Name = model.Name
                };
                _context.Country.Add(request);
            }
            else
            {
                request.CountryCode = model.CountryCode;
                request.CountryIso = model.CountryIso;
                request.Name = model.Name;
            }
            _context.SaveChanges();
            return new CountryDto { Id = request.Id, Name = request.Name, CountryCode = request.CountryCode, CountryIso = request.CountryIso };
        }


        //public bool Delete(int Id)
        //{
        //    var request = _context.CountryDetails.FirstOrDefault(x => x.Id == Id);
        //    if (request != null)
        //    {
        //        _context.CountryDetails.Remove(request);
        //        return true;
        //    }
        //    return false;
        //}

        public CountryDto Get(string PhoneNumber)
        {
            var rse = new CountryDto();
            var request = _context.Country.FirstOrDefault(x => x.CountryCode == new string(PhoneNumber.Take(3).ToArray()));
            if (request != null)
            {
                rse = new CountryDto
                {
                    Id = request.Id,
                    CountryCode = request.CountryCode,
                    CountryIso = request.CountryIso,
                    Name = request.Name
                };
            }
            return rse;
        }
    }
}
