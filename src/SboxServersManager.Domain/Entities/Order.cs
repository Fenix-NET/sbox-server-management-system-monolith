using SboxServersManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; } // Id покупателя
        public Guid ProductId { get; private set; } // Id донатного продукта.
        public DateTime PurchaseDate { get; private set; } // Дата оформления заказа.
        public Status Status { get; private set; }  // Статус заказа: "Pending", "Completed", "Failed"

        public Order(Guid userId, Guid productId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            ProductId = productId;
            PurchaseDate = DateTime.UtcNow;
            Status = Status.InProgress;
        }
        public void Complete() => Status = Status.Completed;
        public void Fail() => Status = Status.Failed;

    }
}
