using Microsoft.EntityFrameworkCore;
using nafibel.DATA.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nafibel.SERVICE.Dtos
{
    public class PaymentDto
    {
        public Ulid Id { get; set; }
        public Ulid HaircutId { get; set; }
        public double Amount { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public Ulid ClientId { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public string? ExternalId { get; set; }
        public string? ExternalPayload { get; set; }

        public PaymentDto(Payment payment)
        {
            Id = payment.Id;
            HaircutId = (Ulid)payment.HaircutId;
            Amount = payment.Amount;
            ClientName = payment.ClientName;
            PaymentType = payment.PaymentType;
            ClientId = (Ulid)payment.ClientId;
            ExternalId = payment.ExternalId;
            ExternalPayload = payment.ExternalPayload;
        }

        public PaymentDto()
        {

        }
    }
}
