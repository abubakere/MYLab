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
    
    public partial class UserPayment
    {
        public long ID { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public System.DateTime Ddate { get; set; }
        public decimal Ammount { get; set; }
        public long ShopId { get; set; }
    }
}
