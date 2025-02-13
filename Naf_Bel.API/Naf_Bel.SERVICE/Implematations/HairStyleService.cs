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
    public class HairStyleService : IHairStyleService
    {
        private readonly ApplicationDbContext _DbContext;

        private readonly ILogger<HairStyleService> _logger;

        public HairStyleService(ApplicationDbContext dbContext, ILogger<HairStyleService> logger)
        {
            this._DbContext = dbContext;
            this._logger = logger;
        }

        //Create HairStyle
        public async Task<Result<HairStyleDto>?> CreateHairStyle(CreateHairStyleRequestDto request)
        {
            try
            {
                _logger.LogInformation("Creating HairStyle to Database");
                var hairStyle = new HairStyle()
                {
                    Id = Ulid.NewUlid(),
                    Name = request.Name,
                    Sex = request.Sex,
                    AverageTime = request.AverageTime,
                    CreatedBy = request.CreatedBy,
                    CreatedOn = request.CreatedOn,
                    Description = request.Description,
                    IsActive = true,
                    Length = request.Length,
                    HairType = request.HairType,
                    MaintenanceLevel = request.MaintenanceLevel,
                    ModifiedOn = request.CreatedOn,
                    ModifiedBy = request.CreatedBy,

                };

                _DbContext.HairStyles.Add(hairStyle);
                await _DbContext.SaveChangesAsync();


                var response = new HairStyleDto(hairStyle);

                return new Result<HairStyleDto>(true) { Model = response };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateHairStyle");
                return new Result<HairStyleDto>(false, "Saving Error");
            }
        }

        // Get all of HairStyle
        public async Task<Result<List<HairStyleDto>>> GetAll()
        {

            try
            {
                _logger.LogInformation("Get HairStyles from db");
                var hairStyles = await _DbContext.HairStyles.ToListAsync();


                var list= hairStyles.Select(hairStyle => new HairStyleDto(hairStyle));

                return new Result< List<HairStyleDto>>(true) { Model = list.ToList() };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAll");
                return new Result<List<HairStyleDto>>(false, "Error fetching from db");
            }
        }
        //GetById of HairStyle
        public async Task<Result<HairStyleDtoWithPrices>> GetById(Ulid id)
        {
            try
            {
                _logger.LogInformation("Get HairStyle from db");
                var hairStyle = await _DbContext.HairStyles.Include(h=>h.HairStylePrices).FirstOrDefaultAsync(h=>h.Id==id);
                if (hairStyle == null)
                {
                    return new Result<HairStyleDtoWithPrices>(false, $"HairStyle with Id {id} not found");

                }

                var response = new HairStyleDtoWithPrices(hairStyle);


                return new Result<HairStyleDtoWithPrices>(true) { Model = response };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateHiarStyle");
                return new Result<HairStyleDtoWithPrices>(false, "Error fecthing db");
            }
        }
        //Delete HairStyles
        public async Task<Result> DeleteById(Ulid id)
        {
            try
            {
                _logger.LogInformation("Delete HairStyle from db");
                var hairStyle = await _DbContext.HairStyles.FindAsync(id);
                if (hairStyle == null)
                {
                    return new Result<HairStyleDto>(false, $"HairStyle with Id {id} not found");

                }

               _DbContext.HairStyles.Remove(hairStyle);
               await _DbContext.SaveChangesAsync();
               


                return new Result<HairStyleDto>(true) {};

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Delete");
                return new Result<HairStyleDto>(false, "Error delete db");
            }
        }

        public async Task<Result<HairStyleDto>> Update(Ulid id, CreateHairStyleRequestDto request)
        {
          
                try
                {
                    _logger.LogInformation("Updating HairStyle in Database");

                    var hairstyle = await _DbContext.HairStyles.FindAsync(id);
                    if (hairstyle == null)
                    {
                        return new Result<HairStyleDto>(false, $"HairStyle with Id {id} not found");
                    }

                    //Update fields
                    hairstyle.Name = request.Name;
                    hairstyle.Sex = request.Sex;
                    hairstyle.AverageTime = request.AverageTime;
                    hairstyle.Description = request.Description;
                    hairstyle.IsActive = true;
                    hairstyle.Length = request.Length;
                    hairstyle.HairType = request.HairType;
                    hairstyle.MaintenanceLevel = request.MaintenanceLevel;
                    hairstyle.ModifiedOn = request.ModifiedOn;
                    hairstyle.ModifiedBy = request.ModifiedBy;

                    await _DbContext.SaveChangesAsync();

                    return new Result<HairStyleDto>(true)
                    {
                        Model = new HairStyleDto(hairstyle)
                    };
                } catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while updating hairStyle");
                    return new Result<HairStyleDto>(false, "Error while updating HairStyle ");
                }
            
           
        }
    }
}
