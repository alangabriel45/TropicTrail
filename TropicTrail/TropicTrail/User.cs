//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TropicTrail
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Reservation = new HashSet<Reservation>();
            this.UserRole1 = new HashSet<UserRole>();
        }
    
        public int userId { get; set; }
        public string userFName { get; set; }
        public string userLName { get; set; }
        public string userAddress { get; set; }
        public string userEmail { get; set; }
        public string userPhone { get; set; }
        public string userName { get; set; }
        public string userPass { get; set; }
        public Nullable<int> userRole { get; set; }
    
        public virtual ICollection<Reservation> Reservation { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<UserRole> UserRole1 { get; set; }
    }
}
