﻿using SStore.Model.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SStore.Model.Data.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; } 
        public string? ProductName { get; set; }       
        public decimal? ProductPrice { get; set; }
        // نشر أم لا
        public bool? IsActive { get; set; }       
        public int? ProductImageId { get; set; }
        // الكمية
        public int? Quantity { get; set; }

        // مسار الصورة الخاصة بالمنتج
        public string? ProductImagePath { get; set; }

        // تجاهل عند التحويل الى json
        [JsonIgnore]
        public Product ToProduct =>
            new Product
            {
                IsActive = IsActive,
                ProductName = ProductName,
                Quantity = Quantity,
                ProductPrice = ProductPrice,

            };
    }
}
