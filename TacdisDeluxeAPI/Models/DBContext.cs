﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacdisDeluxeAPI.Models.Maps;

namespace TacdisDeluxeAPI.Models
{
    public class DBContext : DbContext
    {

        public DBContext()
            : base("DBContext")
        {
        }

        public DbSet<IdAndAmountEntity> IdAmounts { get; set; }
        public DbSet<PartEntity> Parts { get; set; }
        public DbSet<PayerEntity> Payers { get; set; }
        public DbSet<SaleEntity> Sales { get; set; }
        public DbSet<AddonEntity> Addons { get; set; }
        public DbSet<SalesmanEntity> Salesmen { get; set; }
        public DbSet<VehicleEntity> Vehicles { get; set; }
        public DbSet<VehicleBrandEntity> VehicleBrands { get; set; }
        public DbSet<VehicleModelEntity> VehicleModels { get; set; }
        public DbSet<VehiclePropertyEntity> VehicleProperties { get; set; }
        public DbSet<InvoiceEntity> Invoices { get; set; }
        public DbSet<InvoiceRowEntity> InvoiceRows { get; set; }
        public DbSet<WorkOrderEntity> WorkOrder { get; set; }
        public DbSet<WoJobEntity> WorkOrderJobs { get; set; }
        public DbSet<WoKitsEntity> WorkOrderKits { get; set; }
        public DbSet<WoOpEntitys> WorkOrderOperations { get; set; }
        public DbSet<WorkshopInventoryItem> WorkshopInventoryItems { get; set; }
        public DbSet<MainInventoryItem> MainInventoryItems { get; set; }


        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");

            builder.Entity<PartEntity>().ToTable("Part");
            builder.Entity<SaleEntity>().ToTable("Sale");
            builder.Entity<VehicleModelEntity>().ToTable("VehicleModel");
            builder.Entity<PayerEntity>().ToTable("Payer");
            builder.Entity<AddonEntity>().ToTable("Addon");
            builder.Entity<SalesmanEntity>().ToTable("Salesman");
            builder.Entity<VehicleEntity>().ToTable("Vehicle");
            builder.Entity<VehicleBrandEntity>().ToTable("VehicleBrand");
            builder.Entity<VehiclePropertyEntity>().ToTable("VehicleProperty");
            builder.Entity<WorkOrderEntity>().ToTable("WorkOrder");
            builder.Entity<WoJobEntity>().ToTable("WorkOrderJobs");
            builder.Entity<WoKitsEntity>().ToTable("WorkOrderKits");
            builder.Entity<WoOpEntitys>().ToTable("WorkOrderOperations");

            builder.Entity<IdAndAmountEntity>().ToTable("IdAndAmount");
            builder.Entity<WorkshopInventoryItem>().ToTable("WorkshopInventoryItem");
            builder.Entity<MainInventoryItem>().ToTable("MainInventoryItem");

            builder.Configurations.Add(new SalesmanMap());
            builder.Configurations.Add(new PartMap());
            builder.Configurations.Add(new SaleMap());
            builder.Configurations.Add(new VehicleModelMap());
            builder.Configurations.Add(new InvoiceMap());
            builder.Configurations.Add(new WorkOrderKitMap());
            builder.Configurations.Add(new WorkOrderJobMap());
            builder.Configurations.Add(new WorkOrderMap());


            base.OnModelCreating(builder);
        }
    }


}

