using SboxServersManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public Guid OrderId { get; private set; }
        public decimal Amount { get; private set; }
        public string PaymentProvider { get; private set; } // Здесь, будет указываться тип сервиса для оплаты.
        public Status PaymentStatus { get; private set; }  
        public DateTime PaymentDate { get; private set; }

        public Payment(Guid orderId, decimal amount, string paymentProvider)
        {
            Id = Guid.NewGuid();
            OrderId = orderId;
            Amount = amount;
            PaymentProvider = paymentProvider;
            PaymentStatus = Status.InProgress;
            PaymentDate = DateTime.UtcNow;
        }
        public void MarkAsSuccess() => PaymentStatus = Status.Completed;
        public void MarkAsFailed() => PaymentStatus = Status.Failed;

    }
}
