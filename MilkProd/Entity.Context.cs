﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MilkProd
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bdmilkprodEntities : DbContext
    {
        public bdmilkprodEntities()
            : base("name=bdmilkprodEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Farm> Farm { get; set; }
        public virtual DbSet<FarmProd> FarmProd { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductTrade> ProductTrade { get; set; }
        public virtual DbSet<Trade> Trade { get; set; }
        public virtual DbSet<TypeProduct> TypeProduct { get; set; }
        public virtual DbSet<TypeWorker> TypeWorker { get; set; }
        public virtual DbSet<Worker> Worker { get; set; }
    }
}