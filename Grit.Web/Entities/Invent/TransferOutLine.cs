using System;
using System.ComponentModel.DataAnnotations;

namespace Grit.Web.Entities.Invent
{
    public class TransferOutLine : INetcoreBasic
    {
        public TransferOutLine()
        {
            this.createdAt = DateTime.UtcNow;
        }

        [StringLength(38)]
        [Display(Name = "Transfer Out Line Id")]
        public string transferOutLineId { get; set; }

        [StringLength(38)]
        [Display(Name = "Goods Issue Id")]
        public string transferOutId { get; set; }

        [Display(Name = "Goods Issue")]
        public TransferOut transferOut { get; set; }

        [StringLength(38)]
        [Display(Name = "Product Id")]
        public string productId { get; set; }

        [Display(Name = "Product")]
        public Product product { get; set; }

        [Display(Name = "Qty")]
        public float qty { get; set; }

        [Display(Name = "Qty Inventory")]
        public float qtyInventory { get; set; }
    }
}
