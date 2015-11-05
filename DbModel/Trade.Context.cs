﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class tradeEntities : DbContext
    {
        public tradeEntities()
            : base("name=tradeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Certifications> Certifications { get; set; }
        public virtual DbSet<Dealers> Dealers { get; set; }
        public virtual DbSet<Pos> Pos { get; set; }
        public virtual DbSet<PosImages> PosImages { get; set; }
        public virtual DbSet<PosTypes> PosTypes { get; set; }
        public virtual DbSet<SampleDetails> SampleDetails { get; set; }
        public virtual DbSet<SampleDetailStatus> SampleDetailStatus { get; set; }
        public virtual DbSet<Samples> Samples { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<DealerLegalNames> DealerLegalNames { get; set; }
        public virtual DbSet<PosPhones> PosPhones { get; set; }
        public virtual DbSet<PosEmails> PosEmails { get; set; }
        public virtual DbSet<Sites> Sites { get; set; }
        public virtual DbSet<PosBrand> PosBrand { get; set; }
        public virtual DbSet<PosRanks> PosRanks { get; set; }
        public virtual DbSet<AppReports> AppReports { get; set; }
    
        public virtual ObjectResult<sp_getDealersTree_Result> sp_getDealersTree()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getDealersTree_Result>("sp_getDealersTree");
        }
    
        public virtual ObjectResult<sp_getPOSs_Result> sp_getPOSs(Nullable<int> dealerId)
        {
            var dealerIdParameter = dealerId.HasValue ?
                new ObjectParameter("dealerId", dealerId) :
                new ObjectParameter("dealerId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getPOSs_Result>("sp_getPOSs", dealerIdParameter);
        }
    
        public virtual ObjectResult<sp_getSubDealers_Result> sp_getSubDealers(Nullable<int> dealerId)
        {
            var dealerIdParameter = dealerId.HasValue ?
                new ObjectParameter("dealerId", dealerId) :
                new ObjectParameter("dealerId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getSubDealers_Result>("sp_getSubDealers", dealerIdParameter);
        }
    }
}
