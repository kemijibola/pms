﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class pmsstoreEntities : DbContext
    {
        public pmsstoreEntities()
            : base("name=pmsstoreEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tbl_Allocation> tbl_Allocation { get; set; }
        public DbSet<tbl_ConfigLockUser> tbl_ConfigLockUser { get; set; }
        public DbSet<tbl_ConfigUsage> tbl_ConfigUsage { get; set; }
        public DbSet<tbl_ConfigUserTopic> tbl_ConfigUserTopic { get; set; }
        public DbSet<tbl_CSLecturer> tbl_CSLecturer { get; set; }
        public DbSet<tbl_CSTopic> tbl_CSTopic { get; set; }
        public DbSet<tbl_PmsUser> tbl_PmsUser { get; set; }
        public DbSet<tbl_ProjectChapter> tbl_ProjectChapter { get; set; }
        public DbSet<tbl_RegisteredTopic> tbl_RegisteredTopic { get; set; }
        public DbSet<tbl_Role> tbl_Role { get; set; }
        public DbSet<tbl_RoleType> tbl_RoleType { get; set; }
        public DbSet<tbl_Session> tbl_Session { get; set; }
        public DbSet<tbl_Student> tbl_Student { get; set; }
        public DbSet<tbl_StudentActivity> tbl_StudentActivity { get; set; }
    }
}
