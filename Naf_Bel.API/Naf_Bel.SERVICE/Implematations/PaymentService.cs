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
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly ILogger<PaymentService> _logger;


        public PaymentService(ApplicationDbContext dbContext, ILogger<PaymentService> logger)
        {
            this._DbContext = dbContext;
            this._logger = logger;
        }

        public async Task<Result<PaymentDto>> CreatePayment(CreatePaymentRequestDto request)
        {
            try
            {
                _logger.LogInformation("Processing CreatePayment request: {@Request}", request);

                // Validation manuelle des propriétés
                if (request.HaircutId == Ulid.Empty)
                {
                    _logger.LogWarning("HaircutId is missing or invalid.");
                    return new Result<PaymentDto>(false, "HaircutId is required.");
                }

                if (string.IsNullOrWhiteSpace(request.ClientName))
                {
                    _logger.LogWarning("ClientName is missing or empty.");
                    return new Result<PaymentDto>(false, "ClientName is required.");
                }

                if (request.Amount <= 0)
                {
                    _logger.LogWarning("Invalid payment amount: {Amount}", request.Amount);
                    return new Result<PaymentDto>(false, "Payment amount must be greater than 0.");
                }

                // Création de l'objet Payment
                var payment = new Payment
                {
                    Id = Ulid.NewUlid(),
                    HaircutId = request.HaircutId, // Assurez-vous de l'inclure
                    Amount = request.Amount,
                    ClientId = request.ClientId,
                    ClientName = request.ClientName,
                    CreatedBy = request.CreatedBy,
                    CreatedOn = request.CreatedOn,
                    ExternalId = request.ExternalId,
                    ExternalPayload = request.ExternalPayload,
                    PaymentType = request.PaymentType,
                };

                // Enregistrement dans la base de données
                _DbContext.Payments.Add(payment);
                await _DbContext.SaveChangesAsync();

                _logger.LogInformation("Payment successfully created with ID: {PaymentId}", payment.Id);

                // Retour de la réponse
                var response = new PaymentDto(payment);
                return new Result<PaymentDto>(true) { Model = response };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating payment");
                return new Result<PaymentDto>(false, "An error occurred while saving the payment.");
            }

        }
    }
}
