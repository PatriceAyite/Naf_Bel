using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Naf_Bel.DATA.Repositories;
using nafibel.DATA.Models.Entities;
using nafibel.SERVICE.Dtos;
using Nafibel.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nafibel.Services.Implematations
{
    public class HairDresserService : IHairDresserService
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly ILogger<HairDresserService> _logger;

        public HairDresserService(ApplicationDbContext dbContext, ILogger<HairDresserService> logger)
        {
            this._DbContext = dbContext;
            this._logger = logger;
        }
         public async Task<Result<HairDresserDto>?> CreateHairDresser(CreateHairDresserRequestDto request)
        {

            try
            {
                _logger.LogInformation("Creating HairDresser in Database");

                if (request.Latitude == null || request.Longitude == null)
                {
                    throw new ArgumentException("Invalid latitude or longitude values.");
                }

                var hairdresser = new Hairdresser
                {
                    Id = Ulid.NewUlid(),
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    MiddleName = request.MiddleName,
                    PhoneNumber = request.PhoneNumber,
                    Region =request.Region,
                    State = request.State,
                    CountryCode = request.CountryCode,
                    Dob = request.Dob,
                    ProfileImage = request.ProfileImage,
                    ProfileText = request.ProfileText,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    IsActive = true,
                    type = request.type,
                    CreatedBy = request.CreatedBy,
                    CreatedOn = request.CreatedOn,
                    ModifiedOn = request.CreatedOn,
                    ModifiedBy = request.CreatedBy,
                };

                _DbContext.Hairdressers.Add(hairdresser);
                await _DbContext.SaveChangesAsync();

                return new Result<HairDresserDto>(true)
                {
                    Model = new HairDresserDto(hairdresser)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating HairDresser");
                return new Result<HairDresserDto>(false, "Saving Error (Hairdresser is Allready exist!)");
            }
        }

        public async Task<Result> DeleteById(Ulid id)
        {
            try
            {
                _logger.LogInformation("Delete HairDresser from db");
                var hairDresser = await _DbContext.Hairdressers.FindAsync(id);
                
                if (hairDresser == null)
                {
                    return new Result<HairDresserDto>(false, $"HairDresser with Id {id} not found");
                }


                _DbContext.Hairdressers.Remove(hairDresser);
                await _DbContext.SaveChangesAsync();



                return new Result<HairDresserDto>(true) { };
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Delete");
                return new Result<HairDresserDto>(false, "Error delete db");
            }
        }

        //Get all HairDresser 

        public async Task<Result<List<HairDresserDto>>> GetAll()
        {
            try
            {
                _logger.LogInformation("Get HairDresser from db");
                var hairdressers = await _DbContext.Hairdressers.ToListAsync();

                var list = hairdressers.Select(hairdresser => new HairDresserDto(hairdresser));
               

                return new Result<List<HairDresserDto>>(true) { Model = list.ToList() };
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "GetAll");
                return new Result<List<HairDresserDto>>(false, "Error fetching from db");
            }
        }

        public async Task<Result<HairDresserDto>> GetById(Ulid id)
        {
            try
            {
                _logger.LogInformation("Get Hairdresser from db");
                var hairDresser = await _DbContext.Hairdressers.FindAsync(id);
                if (hairDresser == null)
                {
                    return new Result<HairDresserDto>(false, $"Haircut with Id {id} not found");

                }

                var response = new HairDresserDto(hairDresser);
               

                return new Result<HairDresserDto>(true) { Model = response };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "hairdresser error");
                return new Result<HairDresserDto>(false, "Error fecthing db");
            }
        }

        public async Task<Result<HairDresserDto>> Update(Ulid id, CreateHairDresserRequestDto request)
        {
            try
            {
                _logger.LogInformation("Updating HairDresser in Database");

                // Find the existing hairdresser
                var hairDresser = await _DbContext.Hairdressers.FindAsync(id);
                if (hairDresser == null)
                {
                    return new Result<HairDresserDto>(false, $"HairDresser with Id {id} not found");
                }

                // Update fields
                hairDresser.FirstName = request.FirstName;
                hairDresser.LastName = request.LastName;
                hairDresser.Email = request.Email;
                hairDresser.MiddleName = request.MiddleName;
                hairDresser.PhoneNumber = request.PhoneNumber;
                hairDresser.Region = request.Region;
                hairDresser.State = request.State;
                hairDresser.CountryCode = request.CountryCode;
                hairDresser.Dob = request.Dob;
                hairDresser.ProfileImage = request.ProfileImage;
                hairDresser.ProfileText = request.ProfileText;
                hairDresser.type = request.type;
                hairDresser.CreatedOn = request.ModifiedOn;
                hairDresser.CreatedBy = request.ModifiedBy;
                hairDresser.Latitude = request.Latitude;
                hairDresser.Longitude = request.Longitude;
                // Save changes
                await _DbContext.SaveChangesAsync();

                return new Result<HairDresserDto>(true)
                {
                    Model = new HairDresserDto(hairDresser)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating HairDresser");
                return new Result<HairDresserDto>(false, "Error while updating HairDresser");
            }
        }
    }
}
