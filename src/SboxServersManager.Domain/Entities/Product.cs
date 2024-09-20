using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; } // Стоимость товара
        public string ProductType { get; private set; } // Например, "VIP", "Item"
        public bool IsActive { get; private set; }  // Статус доступности товара

        public Product(string name, string description, decimal price, string productType)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            ProductType = productType;
            IsActive = true;
        }
        public void Deactivate() => IsActive = false;
        public void Activate() => IsActive = true;

    }
}
