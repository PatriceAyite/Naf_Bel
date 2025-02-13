using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Naf_Bel.DATA.Repositories;
using Naf_Bel.SERVICE.Dtos;
using nafibel.SERVICE.Dtos;
using Nafibel.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nafibel.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<AppointmentService> _logger;

        public AppointmentService(ApplicationDbContext dbContext, ILogger<AppointmentService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Result<AppointmentDto>> CreateAppointment(CreateAppointmentRequestDto request)
        {
            try
            {
                _logger.LogInformation("Starting appointment creation process");

                if (request.Latitude.HasValue && request.Longitude.HasValue &&
                    (request.Latitude.Value < -90 || request.Latitude.Value > 90 ||
                     request.Longitude.Value < -180 || request.Longitude.Value > 180))
                {
                    return new Result<AppointmentDto>(false, "Invalid latitude or longitude values.");
                }

                var existingClient = request.ClientId.HasValue ?
                    await _dbContext.Clients.FindAsync(request.ClientId.Value) : null;

                if (request.ClientId.HasValue && existingClient == null)
                {
                    return new Result<AppointmentDto>(false, $"Client with ID {request.ClientId} not found.");
                }

                var appointment = new Appointment
                {
                    Id = Ulid.NewUlid(),
                    AppointmentDate = request.AppointmentDate,
                    From = request.From,
                    To = request.To,
                    HairdresserId = request.HairdresserId,
                    HairStyleId = request.HairStyleId,
                    ClientId = request.ClientId,
                    ClientName = request.ClientName,
                    CountryCode = request.CountryCode,
                    State = request.State,
                    Region = request.Region,
                    LocationType = request.LocationType,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    CreatedBy = request.CreatedBy,
                    CreatedOn = request.CreatedOn,
                    ModifiedBy = request.CreatedBy,
                    ModifiedOn = request.CreatedOn,
                    IsActive = true
                };

                _dbContext.Appointments.Add(appointment);
                await _dbContext.SaveChangesAsync();

                var response = new AppointmentDto(appointment);

                return new Result<AppointmentDto>(true) { Model = response };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating appointment");
                return new Result<AppointmentDto>(false, "An error occurred while saving the appointment.");
            }
        }

        public async Task<Result> DeleteById(Ulid id)
        {
            try
            {
                _logger.LogInformation($"Deleting appointment with ID {id}");
                var appointment = await _dbContext.Appointments.FindAsync(id);
                if (appointment == null)
                {
                    return new Result(false, $"Appointment with ID {id} not found.");
                }

                _dbContext.Appointments.Remove(appointment);
                await _dbContext.SaveChangesAsync();

                return new Result(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting appointment");
                return new Result(false, "An error occurred while deleting the appointment.");
            }
        }

        public async Task<Result<List<AppointmentDto>>> GetAll()
        {
            try
            {
                _logger.LogInformation("Fetching all appointments");
                var appointments = await _dbContext.Appointments.ToListAsync();

                var response = appointments.Select(appt => new AppointmentDto(appt)).ToList();
                return new Result<List<AppointmentDto>>(true) { Model = response };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching appointments");
                return new Result<List<AppointmentDto>>(false, "An error occurred while fetching appointments.");
            }
        }

        public async Task<Result<AppointmentDto>> GetById(Ulid id)
        {
            try
            {
                _logger.LogInformation($"Fetching appointment with ID {id}");
                var appointment = await _dbContext.Appointments.FindAsync(id);
                if (appointment == null)
                {
                    return new Result<AppointmentDto>(false, $"Appointment with ID {id} not found.");
                }

                var response = new AppointmentDto(appointment);
                return new Result<AppointmentDto>(true) { Model = response };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching appointment");
                return new Result<AppointmentDto>(false, "An error occurred while fetching the appointment.");
            }
        }
    }
}
