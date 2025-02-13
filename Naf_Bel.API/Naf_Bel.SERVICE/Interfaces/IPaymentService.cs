using nafibel.SERVICE.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nafibel.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<Result<PaymentDto>?> CreatePayment(CreatePaymentRequestDto request);
    }
}
