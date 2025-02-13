using nafibel.SERVICE.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nafibel.Services.Interfaces
{
    public interface IHaircutService
    {
        Task<Result<HaircutDto>> CreateHaircut(CreateHaircutRequestDto request);
        Task<Result<List<HaircutDto>>> GetAll();
        Task<Result<HaircutDto>> GetById(Ulid id);
        Task<Result> DeleteById(Ulid id);
        
    }
}
