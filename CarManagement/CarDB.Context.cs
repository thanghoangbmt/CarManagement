﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarManagement
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarManagementEntities : DbContext
    {
        public CarManagementEntities()
            : base("name=CarManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account_Roles> Account_Roles { get; set; }
        public virtual DbSet<Account_Status> Account_Status { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Car_Categories> Car_Categories { get; set; }
        public virtual DbSet<Car_Fuels> Car_Fuels { get; set; }
        public virtual DbSet<Car_Manufacturers> Car_Manufacturers { get; set; }
        public virtual DbSet<Car_Status> Car_Status { get; set; }
        public virtual DbSet<Car_Tranmissions> Car_Tranmissions { get; set; }
        public virtual DbSet<Car_Types> Car_Types { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Invoice_Details> Invoice_Details { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
