using nafibel.SERVICE.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nafibel.Services.Interfaces
{
    public interface IHairdresserHairStyleService
    {
        Task<Result<HairDresserHairStyleDto>?> CreateHairStyle(CreateHairdresserHairStyleRequestDto request);

    }
}
