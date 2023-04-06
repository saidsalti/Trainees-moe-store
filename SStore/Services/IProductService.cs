using SStore.Model.Data;
using SStore.Model.Data.Dtos;
using SStore.Model.Data.Entities;

namespace SStore.Services
{
    public interface IProductService {
        List<ProductDto?> ReadAll();
        Product? FindOne(int? Id);

        bool CreateProduct(Product product);
         bool UpdateProduct(Product product);
        bool DeleteOne(int? Id);
    }
    public class ProductService : IProductService
    {
        private readonly StoreDbContext _db;

        public ProductService(StoreDbContext db)
        {
            this._db = db;
        }
        public List<ProductDto?> ReadAll()
        {
            return _db.Products.Select(s => new ProductDto
            {
                Id = s.Id,
                IsActive = s.IsActive,
                ProductImagePath = _db.AppStorges.Where(m => m.Id == s.ProductImageId)!.FirstOrDefault()!.FileName,
                ProductName = s.ProductName,
                ProductPrice = s.ProductPrice,
                Quantity = s.Quantity
            }).ToList()!;
        }
        public Product? FindOne(int? Id)
        {
            return _db.Products.FirstOrDefault(m => m.Id == Id)!;
        }
        public bool CreateProduct(Product product)
        {
            _db.Products.Add(product);
            return _db.SaveChanges() > 0;

        }
        public bool UpdateProduct(Product product)
        {
            _db.Products.Update(product);
            return _db.SaveChanges() > 0;
        } 
        public bool DeleteOne(int? Id)
        {
            var product = FindOne(Id);
            _db.Products.Remove(product!);
            return _db.SaveChanges() > 0;
        }
    }
}

