using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Invent
{
    public class VMStock
    {
        [Display(Name = "Product")]
        public string Product { get; set; }
        [Display(Name = "Warehouse")]
        public string Warehouse { get; set; }
        [Display(Name = "Qty PO")]
        public float QtyPO { get; set; }
        [Display(Name = "Qty Receiving")]
        public float QtyReceiving { get; set; }
        [Display(Name = "Qty SO")]
        public float QtySO { get; set; }
        [Display(Name = "Qty Shipment")]
        public float QtyShipment { get; set; }
        [Display(Name = "Qty Transfer In")]
        public float QtyTransferIn { get; set; }
        [Display(Name = "Qty Transfer Out")]
        public float QtyTransferOut { get; set; }
        [Display(Name = "Qty On Hand")]
        public float QtyOnhand { get; set; }
    }
}
