using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Naf_Bel.DATA.Repositories;
using nafibel.DATA.Models.Entities;
using nafibel.SERVICE.Dtos;
using Nafibel.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nafibel.Services.Implematations
{
    public class HairStyleNameLocaleService : IHairStyleNameLocaleService
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly ILogger<HairStyleNameLocaleService> _logger;

        public HairStyleNameLocaleService(ApplicationDbContext dbContext, ILogger<HairStyleNameLocaleService> logger)
        {
            this._DbContext = dbContext;
            this._logger = logger;
        }

        //POST
        public async Task<Result<HairStyleNameLocaleDto>> CreateHairStyleLocalName(CreateHairStyleNameLocaleRequestDto request)
        {
            try
            {
                _logger.LogInformation("Creating new HairStyle local name");

                
                var hairstyleId = request.HairstyleId;
                var existingHairStyle = await _DbContext.HairStyles.FindAsync(hairstyleId);
                if (existingHairStyle == null)
                {
                    return new Result<HairStyleNameLocaleDto>(false, $"HairStyle with ID {request.HairstyleId} not found.");
                }

               
                var hairStyleNameLocale = new HairStyleNameLocale
                {
                    Id = Ulid.NewUlid(),
                    Description = request.Description,
                    Locale = request.Locale,
                    Name = request.Name,
                    HairstyleId = hairstyleId 
                };

                
                _DbContext.HairStyleNameLocales.Add(hairStyleNameLocale);
                await _DbContext.SaveChangesAsync();


                var response = new HairStyleNameLocaleDto(hairStyleNameLocale);
               

                return new Result<HairStyleNameLocaleDto>(true) { Model = response };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating HairStyleNameLocale");
                return new Result<HairStyleNameLocaleDto>(false, "Saving Error");
            }
        }

        public async Task<Result> DeleteById(Ulid id)
        {
            try
            {
                _logger.LogInformation("Delete HairStyle from db");
                var hairStyleNameLocal = await _DbContext.HairStyleNameLocales.FindAsync(id);
                if (hairStyleNameLocal == null)
                {
                    return new Result<HairStyleNameLocaleDto>(false, $"NameLocal with Id {id} not found");
                }

                _DbContext.HairStyleNameLocales.Remove(hairStyleNameLocal);
                await _DbContext.SaveChangesAsync();


                return new Result<HairStyleNameLocaleDto>(true) { };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Delete");
                return new Result<HairStyleNameLocaleDto>(false, "Error delete db");
            }

        }

        public async Task<Result<List<HairStyleNameLocaleDto>>> GetAll()
        {
            try
            {
                _logger.LogInformation("Get HairStyles from db");
                var hairStyleNameLocal = await _DbContext.HairStyleNameLocales.ToListAsync();

                var list = hairStyleNameLocal.Select(hairStyleNameLocal => new HairStyleNameLocaleDto(hairStyleNameLocal));
               

                return new Result<List<HairStyleNameLocaleDto>>(true) { Model = list.ToList() };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAll");
                return new Result<List<HairStyleNameLocaleDto>>(false, "Error fetching from db");
            }
        }

        public async Task<Result<HairStyleNameLocaleDto>> GetById(Ulid id)
        {
            try
            {
                _logger.LogInformation("Get HairStyle from db");
                var hairStyleNameLocal = await _DbContext.HairStyleNameLocales.FindAsync(id);

                if(hairStyleNameLocal == null)
                {
                    return new Result<HairStyleNameLocaleDto>(false, $"HairStyleNameLocal {id}");
                }

                var response = new HairStyleNameLocaleDto(hairStyleNameLocal);
        

                return new Result<HairStyleNameLocaleDto>(true) { Model = response };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateHiarStyleNameLocal");
                return new Result<HairStyleNameLocaleDto>(false, "Error fecthing db");
            }
        }
    }
}
