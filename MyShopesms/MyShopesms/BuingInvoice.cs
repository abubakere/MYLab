//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyShopesms
{
    using System;
    using System.Collections.Generic;
    
    public partial class BuingInvoice
    {
        public long ID { get; set; }
        public long InvoiceNo { get; set; }
        public long MatirialBarcode { get; set; }
        public string MatirialName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Pricein { get; set; }
        public decimal PriceOut { get; set; }
        public Nullable<decimal> Total { get; set; }
        public System.DateTime exDate { get; set; }
        public long User_Id { get; set; }
        public string UserName { get; set; }
        public int Shopid { get; set; }
        public System.DateTime Ddate { get; set; }
    }
}