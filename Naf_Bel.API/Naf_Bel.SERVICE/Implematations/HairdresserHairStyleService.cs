using Microsoft.Extensions.Logging;
using Naf_Bel.DATA.Repositories;
using nafibel.SERVICE.Dtos;
using Nafibel.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nafibel.Services.Implematations
{
    public class HairdresserHairStyleService : IHairdresserHairStyleService
    {

        private readonly ApplicationDbContext _DbContext;

        private readonly ILogger<HairdresserHairStyleService> _logger;

        public Task<Result<HairDresserHairStyleDto>?> CreateHairStyle(CreateHairdresserHairStyleRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
