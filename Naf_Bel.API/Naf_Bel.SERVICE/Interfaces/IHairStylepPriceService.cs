using nafibel.SERVICE.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nafibel.Services.Interfaces
{
    public interface IHairStylepPriceService
    {
        Task<Result<HairStylePriceDto>> CreateHairStylePrice(CreatHairStylePriceRequestDto request);
        Task<Result<List<HairStylePriceDto>>> Getall();
        Task<Result<HairStylePriceDto>> GetById(Ulid id);
        Task<Result> Delete(Ulid id);
    }
}
