using Naf_Bel.SERVICE.Dtos;
using nafibel.SERVICE.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nafibel.Services.Interfaces
{
    public interface IClientService
    {
        Task<Result<ClientDto>> CreateClient(CreateClientRequestDto request);
        Task<Result<List<ClientDto>>> GetAll();
        Task<Result<ClientDto>> GetById(Ulid id);
        Task<Result> DeleteById(Ulid id);
    }
}
