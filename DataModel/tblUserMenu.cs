//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class tblUserMenu
    {
        [Key]
        public long ID { get; set; }
        public Nullable<long> MenuItemID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<byte> Rating { get; set; }
        public string Remark { get; set; }
        public Nullable<bool> Published { get; set; }
        public Nullable<System.DateTime> Timestamp { get; set; }
    
        public virtual tblMenuItem tblMenuItem { get; set; }
        public virtual tblUser tblUser { get; set; }
    }
}
