using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Invent
{
    public class SalesOrderLine : INetcoreBasic
    {
        public SalesOrderLine()
        {
            this.createdAt = DateTime.UtcNow;
            this.discountAmount = 0m;
            this.totalAmount = 0m;
        }

        [StringLength(38)]
        [Display(Name = "Sales Order Line Id")]
        public string salesOrderLineId { get; set; }

        [StringLength(38)]
        [Display(Name = "Sales Order Id")]
        public string salesOrderId { get; set; }

        [Display(Name = "Sales Order")]
        public SalesOrder salesOrder { get; set; }

        [StringLength(38)]
        [Display(Name = "Product Id")]
        public string productId { get; set; }

        [Display(Name = "Product")]
        public Product product { get; set; }

        [Display(Name = "Qty")]
        public float qty { get; set; }

        [Display(Name = "Item Price")]
        public decimal price { get; set; }

        [Display(Name = "Discount Amount")]
        public decimal discountAmount { get; set; }

        [Display(Name = "Total Amount")]
        public decimal totalAmount { get; set; }
    }
}
