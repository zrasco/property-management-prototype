//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PropertyMgmt.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class LedgerRecord
    {
        public int id { get; set; }
        public decimal amount { get; set; }
        public Nullable<System.DateTime> due_date { get; set; }
        public Nullable<System.DateTime> transaction_date { get; set; }
        public string notes { get; set; }
    
        public virtual DepositType DepositType { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual Tenant Tenant { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual HOA HOA { get; set; }
        public virtual PropertyManager PropertyManager { get; set; }
        public virtual ChargeType ChargeType { get; set; }
    }
}
