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
    
    public partial class tbl_CSTopic
    {
        public int GUID { get; set; }
        public int StudentID { get; set; }
        public int LecturerID { get; set; }
        public int SessionID { get; set; }
        public string Topic { get; set; }
        public System.DateTime UploadDate { get; set; }
        public bool Status { get; set; }
        public System.DateTime DateApproved { get; set; }
        public string Comment { get; set; }
    
        public virtual tbl_CSLecturer tbl_CSLecturer { get; set; }
        public virtual tbl_Session tbl_Session { get; set; }
        public virtual tbl_Student tbl_Student { get; set; }
    }
}
