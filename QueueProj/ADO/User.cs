//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QueueProj.ADO
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int Id_user { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Nullable<int> Id_role { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }
    }
}
