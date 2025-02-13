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
    public class HairStylePriceService : IHairStylepPriceService
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly ILogger<HairStylePriceService> _Logger;

        public HairStylePriceService(ApplicationDbContext dbcontext, ILogger<HairStylePriceService> logger)
        {
            this._DbContext = dbcontext;
            this._Logger = logger;
        }

        //Create New Haircut

        public async Task<Result<HairStylePriceDto>> CreateHairStylePrice(CreatHairStylePriceRequestDto request)
        {
            try
            {
                _Logger.LogInformation("Create Hairstyle price");
                var hairStylePrice = new HairStylePrice()
                {
                    Id = Ulid.NewUlid(),
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    Price = request.Price,
                    HairStyleId = request.HairStyleId,
                    CreatedBy=request.CreatedBy,
                    CreatedOn=DateTime.Now,
                };

               _DbContext.HairStylePrices.Add(hairStylePrice);
               await _DbContext.SaveChangesAsync();

                var response = new HairStylePriceDto()
                {
                    Id = hairStylePrice.Id,
                    StartDate = hairStylePrice.StartDate,
                    EndDate = hairStylePrice.EndDate,
                    Price = hairStylePrice.Price,
                    HairStyleId = hairStylePrice.HairStyleId,
                };

                return new Result<HairStylePriceDto>(true) { Model = response };

            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "Create HairstylePrice");
                return new Result<HairStylePriceDto>(true, "Saving Error");
            }

        }
        //GetAll
        public async Task<Result<List<HairStylePriceDto>>> Getall()
        {
            try
            {
                _Logger.LogInformation("Get hairStylePrice from db");
                var hairStylePrice = await _DbContext.HairStylePrices.ToListAsync();

                var list = hairStylePrice.Select(hairStylePrice => new HairStylePriceDto()
                {
                    Id = hairStylePrice.Id,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Price = hairStylePrice.Price,
                });

                return new Result<List<HairStylePriceDto>>(true) { Model = list.ToList() };
            }
            catch(Exception ex)
            {
                _Logger.LogError(ex, "GetAll");
                return new Result<List<HairStylePriceDto>>(false, "Error fetching from db");
            }
        }

      
        //Delete HairStylePrice
        public async Task<Result> Delete(Ulid id)
        {
            try
            {
                _Logger.LogInformation("Delete HairSylePrice from db");
                var hairStylePrice = await _DbContext.HairStylePrices.FindAsync(id);
                if (hairStylePrice == null)
                {
                    return new Result<HairStylePriceDto>(false, $"HairStyle with Id {id} not found");

                }
                _DbContext.HairStylePrices.Remove(hairStylePrice);
                await _DbContext.SaveChangesAsync();

                return new Result<HairStylePriceDto>(true) { };
            }
            catch(Exception ex)
            {
                _Logger.LogError(ex, "Delete");
                return new Result<HairStylePriceDto>(false, "Error delete db");
            }
        }

        //Get by id
        public async Task<Result<HairStylePriceDto>> GetById(Ulid id)
        {
            try
            {
                _Logger.LogInformation("Get hairStylePrice from db");
                var hairStylePrice = await _DbContext.HairStylePrices.FindAsync(id);
                if (hairStylePrice == null)
                {
                    return new Result<HairStylePriceDto>(false, $"HairStylePrice with Id {id} not found");
                }

                var response = new HairStylePriceDto(hairStylePrice);

                return new Result<HairStylePriceDto>(true) { Model = response };
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "HairStylePrice");
                return new Result<HairStylePriceDto>(false, "Error fecthing db");
            }
        }
    }
}
 