//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI_LAb_task.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public int Stid { get; set; }
        public string St_name { get; set; }
        public Nullable<System.DateTime> Dob { get; set; }
        public Nullable<int> Deptid { get; set; }
    
        public virtual Department Department { get; set; }
    }
}