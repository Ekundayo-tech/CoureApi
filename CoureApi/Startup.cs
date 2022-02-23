using CoureApi.Data.Entity;
using CoureApi.Interface;
using CoureApi.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoureApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoureApi", Version = "v1" });
            });
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("CoureDbApis"));

            //services.AddScoped<DbContext, DataContext>();
            services.AddTransient<ICountry, CountryService>();
            services.AddTransient<ICountryDetails, CountryDetailService>();
            //services.AddScoped<DataContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //using (var context = app.ApplicationServices.GetService<DataContext>())
            //{
            //    AddTestData(context);
            //}

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoureApi v1"));
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        //private void AddTestData(DataContext context)
        //{
        //    var testUser1 = new List<Country>
        //    {
        //        new Country
        //        {
        //            Id = 1,
        //            CountryCode = "234",
        //            Name = "Nigeria",
        //            CountryIso = "NG"
        //        },
        //        new Country
        //        {
        //            Id = 2,
        //            CountryCode = "233",
        //            Name = "Ghana",
        //            CountryIso = "GH"
        //        },
        //        new Country
        //        {
        //            Id = 3,
        //            CountryCode = "229",
        //            Name = "Benin Republic",
        //            CountryIso = "BN"
        //        },
        //        new Country
        //        {
        //            Id = 4,
        //            CountryCode = "225",
        //            Name = "Côte d'Ivoire ",
        //            CountryIso = "CIV"
        //        } 
        //    };

        //    context.Country.AddRange(testUser1);

        //    var testPost1 = new List<CountryDetails>
        //    {
        //        new CountryDetails
        //        {
        //            Id = 1,
        //            CountryId = "1",
        //            Opeartor = "MTN Nigeria",
        //            OperatorCode = "MTN NG"
        //        },
        //        new CountryDetails
        //        {
        //            Id = 2,
        //            CountryId = "1",
        //            Opeartor = "1 Airtel Nigeria",
        //            OperatorCode = "ANG"
        //        },
        //        new CountryDetails
        //        {
        //            Id = 3,
        //            CountryId = "1",
        //            Opeartor = "9 Mobile Nigeria",
        //            OperatorCode = "ETN"
        //        },
        //        new CountryDetails
        //        {
        //            Id = 4,
        //            CountryId = "1",
        //            Opeartor = "Globacom Nigeria",
        //            OperatorCode = "Globacom NG"
        //        },
        //        new CountryDetails
        //        {
        //            Id = 5,
        //            CountryId = "2",
        //            Opeartor = "Vodafone GH",
        //            OperatorCode = "Vodafone Ghana"
        //        },
        //        new CountryDetails
        //        {
        //            Id = 6,
        //            CountryId = "2",
        //            Opeartor = "MTN Ghana",
        //            OperatorCode = "MTN Ghana"
        //        },
        //        new CountryDetails
        //        {
        //            Id = 7,
        //            CountryId = "2",
        //            Opeartor = "Tigo Ghana",
        //            OperatorCode = "Tigo Ghana"
        //        },
        //        new CountryDetails
        //        {
        //            Id = 8,
        //            CountryId = "3",
        //            Opeartor = "MTN Benin",
        //            OperatorCode = "MTN Benin"
        //        },
        //        new CountryDetails
        //        {
        //            Id = 9,
        //            CountryId = "3",
        //            Opeartor = "Moov Benin",
        //            OperatorCode = "Moov Benin"
        //        },
        //        new CountryDetails
        //        {
        //            Id = 10,
        //            CountryId = "4",
        //            Opeartor = "MTN Côte d'Ivoire",
        //            OperatorCode = "MTN CIV"
        //        },

        //    };

        //    context.CountryDetails.AddRange(testPost1);

        //    context.SaveChanges();
        //}
    }
} 
 
 
 
 
 
 
