﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class TropicTrailEntities : DbContext
    {
        public TropicTrailEntities()
            : base("name=TropicTrailEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Tour_Type> Tour_Type { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<vw_UserRole> vw_UserRole { get; set; }
    
        public virtual ObjectResult<sp_Services_Result> sp_Services(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Services_Result>("sp_Services", idParameter);
        }
    
        public virtual int sp_Reservation(Nullable<int> bookedBy, Nullable<System.DateTime> dateIn, Nullable<System.DateTime> dateOut, Nullable<int> sId, string lName, string fName, string pay, string status)
        {
            var bookedByParameter = bookedBy.HasValue ?
                new ObjectParameter("bookedBy", bookedBy) :
                new ObjectParameter("bookedBy", typeof(int));
    
            var dateInParameter = dateIn.HasValue ?
                new ObjectParameter("dateIn", dateIn) :
                new ObjectParameter("dateIn", typeof(System.DateTime));
    
            var dateOutParameter = dateOut.HasValue ?
                new ObjectParameter("dateOut", dateOut) :
                new ObjectParameter("dateOut", typeof(System.DateTime));
    
            var sIdParameter = sId.HasValue ?
                new ObjectParameter("sId", sId) :
                new ObjectParameter("sId", typeof(int));
    
            var lNameParameter = lName != null ?
                new ObjectParameter("lName", lName) :
                new ObjectParameter("lName", typeof(string));
    
            var fNameParameter = fName != null ?
                new ObjectParameter("fName", fName) :
                new ObjectParameter("fName", typeof(string));
    
            var payParameter = pay != null ?
                new ObjectParameter("pay", pay) :
                new ObjectParameter("pay", typeof(string));
    
            var statusParameter = status != null ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Reservation", bookedByParameter, dateInParameter, dateOutParameter, sIdParameter, lNameParameter, fNameParameter, payParameter, statusParameter);
        }
    }
}
