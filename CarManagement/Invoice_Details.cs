//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoice_Details
    {
        public int ID { get; set; }
        public int Car_ID { get; set; }
        public int Invoice_ID { get; set; }
        public double Unit_Price { get; set; }
        public int Quantity { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
