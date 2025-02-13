using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Naf_Bel.DATA.Repositories;
using nafibel.DATA.Models.Entities;
using nafibel.SERVICE.Dtos;
using Nafibel.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nafibel.Services.Implematations
{
    public class HaircutService : IHaircutService
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly ILogger<HaircutService> _logger;

        public HaircutService(ApplicationDbContext dbContext, ILogger<HaircutService> logger)
        {
            _DbContext = dbContext;
            _logger = logger;
        }
        
        public async Task<Result<HaircutDto>> CreateHaircut(CreateHaircutRequestDto request)
        {
            try
            {
                
                _logger.LogInformation("Creating Haircut in database ...");
                var haircut = new Haircut
                {
                    Id = Ulid.NewUlid(),
                    AppointmentId = request.AppointmentId,
                    EndHaircutDatetime = request.EndHaircutDatetime,
                    StartHaircutDatetime = request.StartHaircutDatetime,
                    HairStyleId = request.HairStyleId,
                };


                _DbContext.Haircuts.Add(haircut);
                await _DbContext.SaveChangesAsync();

                var response = new HaircutDto(haircut);

                return new Result<HaircutDto>(true) { Model = response };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating Haircut");
                return new Result<HaircutDto>(false, "Saving error");
            }
        }

        public async Task<Result> DeleteById(Ulid id)
        {
            try
            {
                _logger.LogInformation("Delete HairDresser from db");
                var haircut = await _DbContext.Haircuts.FindAsync(id);

                if (haircut == null)
                {
                    return new Result<HaircutDto>(false, $"HairDresser with Id {id} not found");
                }


                _DbContext.Haircuts.Remove(haircut);
                await _DbContext.SaveChangesAsync();



                return new Result<HaircutDto>(true) { };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Delete");
                return new Result<HaircutDto>(false, "Error delete db");
            }
        }

        public async Task<Result<List<HaircutDto>>> GetAll()
        {
            try
            {
                _logger.LogInformation("Get Haircut from db");
                var haircuts = await _DbContext.Haircuts.ToListAsync();

                var list = haircuts.Select(haircut => new HaircutDto(haircut));

                return new Result<List<HaircutDto>>(true) { Model = list.ToList() };
            }catch(Exception ex)
            {
                _logger.LogError(ex, "GetAll");
                return new Result<List<HaircutDto>>(false, "Error fetching from db");

            }
        }

        public async Task<Result<HaircutDto>> GetById(Ulid id)
        {
           try
            {
                _logger.LogInformation("Get haircut from db");
                var haircut = await _DbContext.Haircuts.FindAsync(id);
                if (haircut == null)
                {
                    return new Result<HaircutDto>(false, $"Haircut with Id {id} not found");
                }

                var response = new HaircutDto(haircut);

                return new Result<HaircutDto>(true) { Model = response };
            }catch(Exception ex)
            {
                _logger.LogError(ex, "Haircut error");
                return new Result<HaircutDto>(false, "Error fetching db ");
            }
        }
    }
}
