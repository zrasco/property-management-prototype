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
    
    public partial class Vendor
    {
        public Vendor()
        {
            this.Contacts = new HashSet<Contact>();
            this.LedgerRecords = new HashSet<LedgerRecord>();
            this.ServiceCalls = new HashSet<ServiceCall>();
            this.FileContainers = new HashSet<FileContainer>();
            this.AuditEntries = new HashSet<AuditEntry>();
        }
    
        public int id { get; set; }
        public string company_name { get; set; }
        public string address1 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string address2 { get; set; }
        public string fax { get; set; }
        public bool active { get; set; }
    
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual BusinessType BusinessType { get; set; }
        public virtual ICollection<LedgerRecord> LedgerRecords { get; set; }
        public virtual ICollection<ServiceCall> ServiceCalls { get; set; }
        public virtual ICollection<FileContainer> FileContainers { get; set; }
        public virtual ICollection<AuditEntry> AuditEntries { get; set; }
    }
}