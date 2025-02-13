using nafibel.SERVICE.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nafibel.Services.Interfaces
{
    public interface IHairStyleNameLocaleService
    {
        Task<Result<HairStyleNameLocaleDto>> CreateHairStyleLocalName(CreateHairStyleNameLocaleRequestDto request);
        Task<Result<HairStyleNameLocaleDto>> GetById(Ulid id);
        Task<Result> DeleteById(Ulid id);
        Task<Result<List<HairStyleNameLocaleDto>>> GetAll();

    }
}
