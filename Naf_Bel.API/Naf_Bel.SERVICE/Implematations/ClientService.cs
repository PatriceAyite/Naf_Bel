using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Naf_Bel.DATA.Repositories;
using Naf_Bel.SERVICE.Dtos;
using nafibel.DATA.Models.Entities;
using nafibel.SERVICE.Dtos;
using Nafibel.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nafibel.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ClientService> _logger;

        public ClientService(ApplicationDbContext dbContext, ILogger<ClientService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Result<ClientDto>> CreateClient(CreateClientRequestDto request)
        {
            try
            {
                _logger.LogInformation("Creating client in database...");

                if (request.Latitude == null || request.Longitude == null)
                {
                    throw new ArgumentException("Invalid latitude or longitude values.");
                }

                var client = new Client
                {
                    Id = Ulid.NewUlid(),
                    AgeRange = request.AgeRange,
                    CountryCode = request.CountryCode,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    MiddleName = request.MiddleName,
                    PhoneNumber = request.PhoneNumber,
                    State = request.State,
                    Region = request.Region,
                    Email = request.Email,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    IsActive = true,
                    CreatedBy = request.CreatedBy,
                    CreatedOn = request.CreatedOn,
                    ModifiedOn = request.CreatedOn,
                    ModifiedBy = request.CreatedBy
                };

                _dbContext.Clients.Add(client);
                await _dbContext.SaveChangesAsync();

                var response = new ClientDto(client);
                return new Result<ClientDto>(true) { Model = response };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating client");
                return new Result<ClientDto>(false, "Error saving client to database.");
            }
        }

        public async Task<Result> DeleteById(Ulid id)
        {
            try
            {
                _logger.LogInformation("Deleting client from database...");
                var client = await _dbContext.Clients.FindAsync(id);

                if (client == null)
                {
                    return new Result(false, $"Client with ID {id} not found.");
                }

                _dbContext.Clients.Remove(client);
                await _dbContext.SaveChangesAsync();

                return new Result(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting client");
                return new Result(false, "Error deleting client from database.");
            }
        }

        public async Task<Result<List<ClientDto>>> GetAll()
        {
            try
            {
                _logger.LogInformation("Fetching all clients from database...");
                var clients = await _dbContext.Clients.ToListAsync();

                var clientDtos = clients.Select(client => new ClientDto(client)).ToList();
                return new Result<List<ClientDto>>(true) { Model = clientDtos };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching clients");
                return new Result<List<ClientDto>>(false, "Error fetching clients from database.");
            }
        }

        public async Task<Result<ClientDto>> GetById(Ulid id)
        {
            try
            {
                _logger.LogInformation("Fetching client from database by ID...");
                var client = await _dbContext.Clients.FindAsync(id);

                if (client == null)
                {
                    return new Result<ClientDto>(false, $"Client with ID {id} not found.");
                }

                var clientDto = new ClientDto(client);
                return new Result<ClientDto>(true) { Model = clientDto };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching client by ID");
                return new Result<ClientDto>(false, "Error fetching client from database.");
            }
        }
    }
}
