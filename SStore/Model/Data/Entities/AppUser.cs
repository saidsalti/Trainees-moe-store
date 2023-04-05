using Microsoft.EntityFrameworkCore;
using SStore.Model.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SStore.Model.Data.Entities
{
    public class BaseEntity
    {

        public DateTime? Created { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyBy { get; set; }
    }
    [Table(nameof(AppUser))]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(UserName), IsUnique = true)]
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string? UserName { get; set; }
        [StringLength(50)]
        public string? Password { get; set; }
        [StringLength(500)]
        [Required]
        public string? Email { get; set; }
        [StringLength(50)]
        [Required]
        public string? FirstName { get; set; }
        [StringLength(50)]
        [Required]
        public string? LastName { get; set; }
        [StringLength(15)]
        public string? PhoneNumber { get; set; }
        public bool? IsActive { get; set; }

    }

    [Table(nameof(Product))]
    public class Product : BaseEntity
    {
        public Product()
        {
            this.ProductCategories = new HashSet<ProductCategory>();
            this.OrderDetails = new HashSet<OrderDetail>();
            this.ProductImages = new HashSet<ProductImage>();
         

        }
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string? ProductName { get; set; }

        [Required]
        [Range(1, 99999)]
        public decimal? ProductPrice { get; set; }

        public bool? IsActive { get; set; }
        // from storge
        public int? ProductImageId { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
       
        public virtual ICollection<OrderStatus> OrderStatus { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<PaymentMathod> PaymentMathods { get; set; }
    }  

    [Table(nameof(ProductImage))]
    public class ProductImage : BaseEntity
    {
        [Key]
        public int? Id { get; set; }
        public int? ImageStorgeId { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }

        public virtual Product? Product { get; set; }
    }

    [Table(nameof(ProductCategory))]
    [Index(nameof(ProductId), nameof(CategoryId), IsUnique = true)]
    public class ProductCategory : BaseEntity
    {
        [Key]
        public int? Id { get; set; }
        [ForeignKey("Product")]
        [Required]
        public int? ProductId { get; set; }

        [Required]
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual Product? Product { get; set; }
    }


    [Table(nameof(Order))]
    public class Order : BaseEntity
    {
        public Order()
        {
            this.OrderDetals = new HashSet<OrderDetail>();
        }
        [Key]
        public int? Id { get; set; }
        [Required]
        public int? OrderId { get; set; }
        [Required]
        public DateTime? OrderCreated { get; set; }
        [Required]
        public int? OrderUserId { get; set; }
        [Required]
        public int? OrderStatusId { get; set; }
        [Required]
        public decimal? OrderTotalPrice { get; set; }
        [Required]
        public bool? IsActive { get; set; }
        public virtual ICollection<OrderDetail> OrderDetals { get; set; }

    }

    [Table(nameof(OrderDetail))]
    [Index(nameof(ProductId), nameof(OrderId), IsUnique = true)]
    public class OrderDetail : BaseEntity
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        [Required]
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        [Required]
        [Range(1, 99999)]
        [ForeignKey("product")]
        public decimal? ProductPrice { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public decimal? OrderTotalPrice { get; set; }
        public bool? IsActive { get; set; }
        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }


    }


    [Table(nameof(OrderStatus))]
    [Index(nameof(ProductId), nameof(OrderId), IsUnique = true)]
    public class OrderStatus : BaseEntity
    {
        [Key]
        public int? Id { get; set; }
        [StringLength(50)]
        [Required]
        public string? OrderStatusNo { get; set; }

        [Required]
        [ForeignKey("Order")]
        public int? OrderId { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int? ProductId { get; set; }

        [Required]
        public int? location { get; set; }

        public bool? IsActive { get; set; }
        public virtual Order? Order { get; set; }
        public virtual OrderStatus? Status { get; set; }
        public virtual Product? Product { get; set; }
    }

    [Table(nameof(Payment))]
    [Index(nameof(ProductPrice), nameof(OrderTotalPrice), IsUnique = true)]
    public class Payment : BaseEntity
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        [Range(1, 99999)]
        [ForeignKey("product")]
        public decimal? ProductPrice { get; set; }
        [Required]
        [ForeignKey("OrderDetail")] 
        public decimal? OrderTotalPrice { get; set; }
        

    }
    [Table(nameof(PaymentMathod))]
  
    public class PaymentMathod : BaseEntity
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        [Range(1, 99999)]
        [ForeignKey("product")]
        public decimal? productPrice { get; set; }
        [Required]
        public decimal? TypesofPayment { get; set;}
    }
    [Table(nameof(AppStorge))]
    public class AppStorge : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public long? FileSize { get; set; }

    }
}



