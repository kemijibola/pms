//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PMSRedefined.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Role
    {
        public tbl_Role()
        {
            this.tbl_ConfigLockUser = new HashSet<tbl_ConfigLockUser>();
            this.tbl_ConfigUsage = new HashSet<tbl_ConfigUsage>();
            this.tbl_ConfigUserTopic = new HashSet<tbl_ConfigUserTopic>();
            this.tbl_RoleType = new HashSet<tbl_RoleType>();
        }
    
        public int GUID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<tbl_ConfigLockUser> tbl_ConfigLockUser { get; set; }
        public virtual ICollection<tbl_ConfigUsage> tbl_ConfigUsage { get; set; }
        public virtual ICollection<tbl_ConfigUserTopic> tbl_ConfigUserTopic { get; set; }
        public virtual ICollection<tbl_RoleType> tbl_RoleType { get; set; }
    }
}
