using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SBRPDataPsi.Models
{
    public class PsiDbContext : DbContext
    {
        private readonly string m_ConnectionString = @"Data Source=LOCALHOST\MSSQLSERVER2019;Initial Catalog=SBRPDB;Persist Security Info=True;Integrated Security=True;TrustServerCertificate=true;MultipleActiveResultSets=true;";

        //private byte m_SIGNo;
        //public byte GetSIG() => m_SIGNo;
        //public void SetSIG(byte _sIGNo)
        //{
        //    if (_sIGNo.IsNullOrDefault()) return;
        //    m_SIGNo = _sIGNo;
        //}




        #region "Table"
        public virtual DbSet<AppUser> AppUsers { get; set; }

        public virtual DbSet<AppUser> Menuitems { get; set; }

        public virtual DbSet<BaseWebPageSIG> BaseWebPageSIGs { get; set; }






        public virtual DbSet<InboundStockOrder> InboundStockOrders { get; set; }

        public virtual DbSet<InboundStockOrderDetail> InboundStockOrderDetails { get; set; }






        public virtual DbSet<Member> Members { get; set; }







        public virtual DbSet<MenuitemAppUser> MenuitemAppUsers { get; set; }

        public virtual DbSet<MenuitemPermissionGroup> MenuitemPermissionGroups { get; set; }

        public virtual DbSet<MenuitemSIG> MenuitemSIGs { get; set; }








        public virtual DbSet<OperationClassStock> OperationClassStocks { get; set; }




        public virtual DbSet<PermissionGroup> PermissionGroups { get; set; }

        public virtual DbSet<PermissionGroupAppUser> PermissionGroupAppUsers { get; set; }



        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductCost> ProductCosts { get; set; }

        public virtual DbSet<ProductCostDefinition> ProductCostDefinitions { get; set; }

        public virtual DbSet<ProductGeneralCategory> ProductGeneralCategories { get; set; }

        public virtual DbSet<ProductGeneralCategoryDefinition> ProductGeneralCategoryDefinitions { get; set; }

        public virtual DbSet<ProductGeneralCategoryItem> ProductGeneralCategoryItems { get; set; }

        public virtual DbSet<ProductIdStructureDefinition> ProductIdStructureDefinitions { get; set; }


        public virtual DbSet<ProductPrice> ProductPrices { get; set; }

        public virtual DbSet<ProductPriceDefinition> ProductPriceDefinitions { get; set; }

        public virtual DbSet<ProductStock> ProductStocks { get; set; }

        public virtual DbSet<ProductSupplier> ProductSuppliers { get; set; }



        public virtual DbSet<SaleOrder> SaleOrders { get; set; }

        public virtual DbSet<SaleOrderDetail> SaleOrderDetails { get; set; }


        public virtual DbSet<Stock> Stocks { get; set; }

        public virtual DbSet<Store> Stores { get; set; }

        public virtual DbSet<StoreRegion> StoreRegions { get; set; }


        public virtual DbSet<StockTransferOrder> StockTransferOrders { get; set; }
        public virtual DbSet<StockTransferOrderDetail> StockTransferOrderDetails { get; set; }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        public virtual DbSet<SupplierGroup> SupplierGroups { get; set; }
        #endregion




        public PsiDbContext(DbContextOptions<PsiDbContext> options) : base(options)
        {
        }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(m_ConnectionString);
            }

            // 為了解決：An error was generated for warning 'Microsoft.EntityFrameworkCore.Migrations.PendingModelChangesWarning': The model for context 'PsiDbContext' has pending changes. Add a new migration before updating the database. This exception can be suppressed or logged by passing event ID 'RelationalEventId.PendingModelChangesWarning' to the 'ConfigureWarnings' method in 'DbContext.OnConfiguring' or 'AddDbContext'.
            optionsBuilder
                .ConfigureWarnings(warnings => warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));

            base.OnConfiguring(optionsBuilder);
        }







        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            SBRPData.CommonContextConfiguration.ModelCreating(modelBuilder);

            SBRPData.CommonContextConfiguration.DataSeeding(modelBuilder);

            modelBuilder.HasDefaultSchema(SBRPData.DbSystemModel.DB_Schema_psi);





            #region "Sequence"
            modelBuilder.HasSequence<byte>(TableColumnSeed.ProductGeneralCategoryDefinition.GetDisplayName(), SBRPData.DbSystemModel.DB_Schema_psi)
                .StartsAt((long)TableColumnSeed.ProductGeneralCategoryDefinition).IncrementsBy(1);

            // Remark: 2024/12/29 都在DB層級INSERT資料，不會透過AP INSERT，所以不需要Next Value
            //modelBuilder.HasSequence<short>(TableColumnSeed.Menuitem.GetDisplayName(), SBRPData.DbSystemModel.DB_Schema_psi)
            //    .StartsAt((long)TableColumnSeed.Menuitem).IncrementsBy(1);
            modelBuilder.HasSequence<short>(TableColumnSeed.StoreRegion.GetDisplayName(), SBRPData.DbSystemModel.DB_Schema_psi)
              .StartsAt((long)TableColumnSeed.StoreRegion).IncrementsBy(1);

            modelBuilder.HasSequence<short>(TableColumnSeed.SupplierGroup.GetDisplayName(), SBRPData.DbSystemModel.DB_Schema_psi)
               .StartsAt((long)TableColumnSeed.SupplierGroup).IncrementsBy(1);


            modelBuilder.HasSequence<short>(TableColumnSeed.BaseWebPageSIG.GetDisplayName(), SBRPData.DbSystemModel.DB_Schema_psi)
                .StartsAt((long)TableColumnSeed.BaseWebPageSIG).IncrementsBy(1);

            modelBuilder.HasSequence<short>(TableColumnSeed.Stock.GetDisplayName(), SBRPData.DbSystemModel.DB_Schema_psi)
                .StartsAt((long)TableColumnSeed.Stock).IncrementsBy(1);

            modelBuilder.HasSequence<short>(TableColumnSeed.Store.GetDisplayName(), SBRPData.DbSystemModel.DB_Schema_psi)
                .StartsAt((long)TableColumnSeed.Store).IncrementsBy(1);


            modelBuilder.HasSequence<short>(TableColumnSeed.PermissionGroup.GetDisplayName(), SBRPData.DbSystemModel.DB_Schema_psi)
                .StartsAt((long)TableColumnSeed.PermissionGroup).IncrementsBy(1);

            modelBuilder.HasSequence<short>(TableColumnSeed.Supplier.GetDisplayName(), SBRPData.DbSystemModel.DB_Schema_psi)
              .StartsAt((long)TableColumnSeed.Supplier).IncrementsBy(1);

            modelBuilder.HasSequence<short>(TableColumnSeed.ProductGeneralCategoryItem.GetDisplayName(), SBRPData.DbSystemModel.DB_Schema_psi)
                .StartsAt((long)TableColumnSeed.ProductGeneralCategoryItem).IncrementsBy(1);








            modelBuilder.HasSequence<int>(TableColumnSeed.Product.GetDisplayName(), SBRPData.DbSystemModel.DB_Schema_psi)
                .StartsAt((long)TableColumnSeed.Product).IncrementsBy(1);


            modelBuilder.HasSequence<int>(TableColumnSeed.Member.GetDisplayName(), SBRPData.DbSystemModel.DB_Schema_psi)
                .StartsAt((long)TableColumnSeed.Member).IncrementsBy(1);


            //modelBuilder.HasSequence<int>(TableColumnSeed.InboundStockOrder.GetDisplayName(), SBRPData.DbSystemModel.DB_Schema_psi)
            //    .StartsAt((long)TableColumnSeed.InboundStockOrder).IncrementsBy(1);
            #endregion








            #region "modelBuilder.Entity"
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.Property(p => p.IsAppReadonly).HasDefaultValueSql("0");
                entity.Property(p => p.IsAppDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");


            });





            modelBuilder.Entity<BaseWebPageSIG>(entity =>
            {
                entity.Property(p => p.SIGPageNo)
                    .HasDefaultValueSql($"NEXT VALUE FOR {SBRPData.DbSystemModel.DB_Schema_psi}.{TableColumnSeed.BaseWebPageSIG.GetDisplayName()}");

                entity.HasIndex(entity => new { entity.PageId, entity.SIGNo }).IsUnique();

                // 可能有多個頁面關聯同一個功能表項目
                entity
                    .HasOne(p => p.MenuitemSIG)
                    .WithMany()
                    .HasForeignKey(f => new { f.NodeNo, f.SIGNo});                    

                //// 上層的頁面
                //entity
                //    .HasOne(p => p.ParentBaseWebPageSIG)
                //    .WithMany()
                //    .HasForeignKey(f => new {f.PageId, f.SIGNo});
            });














            modelBuilder.Entity<InboundStockOrder>(entity =>
            {
                entity.HasKey(p => new {p.OrderDateNo, p.DaySerialNo});

                entity.HasIndex(p => p.OrderNo).IsUnique();
                entity.HasIndex(p => new { p.OrderId, p.SIGNo }).IsUnique();
                entity.HasIndex(p => p.SupplierNo);
                entity.HasIndex(p => p.StockNo);

                entity.Property(p => p.TotalAmount).HasDefaultValueSql("0");
                entity.Property(p => p.TotalQuantity).HasDefaultValueSql("0");
                entity.Property(p => p.OrderDate).HasComputedColumnSql(DbSystemData.SQL_Table_Orders_OrderDate_Computed);
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(p => p.LogNo).HasDefaultValueSql("0");


                entity.HasMany(f => f.InboundStockOrderDetails)
                    .WithOne()
                    .HasForeignKey(f => f.OrderNo)
                    .HasPrincipalKey(p => p.OrderNo)
                    .OnDelete(DeleteBehavior.Cascade);


                entity.HasQueryFilter(c => c.IsDeleted == false);
            });

            modelBuilder.Entity<InboundStockOrderDetail>(entity =>
            {
                entity.HasKey(p => new { p.OrderNo, p.ItemNo });

                entity.Property(p => p.SubAmount).HasComputedColumnSql("[Quantity] * [UnitCost]");
            });









            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(p => p.MemberNo);
                entity.Property(p => p.MemberNo)
                   .HasDefaultValueSql($"NEXT VALUE FOR {SBRPData.DbSystemModel.DB_Schema_psi}.{TableColumnSeed.Member.GetDisplayName()}");

                entity.HasIndex(p => new { p.MemberId, p.SIGNo }).IsUnique();
                
                entity.Property(p => p.Birthday_MonthDay).HasComputedColumnSql("(RIGHT('0' +  CAST([Birthday_Month] AS VARCHAR(5)), 1) + '/'  +  RIGHT('0' + CAST([Birthday_Day] AS VARCHAR(5)), 1))");

                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");
            });





            modelBuilder.Entity<Menuitem>(entity =>
            {
                // 都在DB層級INSERT資料，不會透過AP INSERT，所以不需要Next Value
                //entity.Property(p => p.NodeNo)
                //  .HasDefaultValueSql($"NEXT VALUE FOR {SBRPData.DbSystemModel.DB_Schema_psi}.{TableColumnSeed.Menuitem.GetDisplayName()}");

                entity.Property(p => p.IsIsolated).HasDefaultValueSql("0");
                entity.Property(p => p.IsInvisible).HasDefaultValueSql("0");
                entity.Property(p => p.IsDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<MenuitemAppUser>(entity =>
            {
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<MenuitemPermissionGroup>(entity =>
            {
                entity.Property(p => p.IsReadonly).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<MenuitemSIG>(entity =>
            {
                //entity.HasMany<MenuitemSIG>()
                //    .WithOne()
                //    .HasForeignKey(f => f.NodeNo)
                //    .HasPrincipalKey(p => p.NodeNo)
                //    .OnDelete(DeleteBehavior.Cascade);
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");
            });






            modelBuilder.Entity<OperationClassStock>(entity =>
            {
                entity.HasKey(p => new { p.OperationClassNo, p.StockNo });

                entity.Property(p => p.IsDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");
            });







            modelBuilder.Entity<PermissionGroup>(entity =>
            {
                entity.Property(p => p.PermissionGroupNo)
                     .HasDefaultValueSql($"NEXT VALUE FOR {SBRPData.DbSystemModel.DB_Schema_psi}.{TableColumnSeed.PermissionGroup.GetDisplayName()}");

                entity.HasIndex(p => new { p.PermissionGroupId, p.SIGNo }).IsUnique();

                entity.Property(p => p.IsSystemPredefined).HasDefaultValueSql("0");
                entity.Property(p => p.IsInvisible).HasDefaultValueSql("0");
                entity.Property(p => p.IsDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<PermissionGroupAppUser>(entity =>
            {
                
            });




            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.ProductNo)
                    .HasDefaultValueSql($"NEXT VALUE FOR {SBRPData.DbSystemModel.DB_Schema_psi}.{TableColumnSeed.Product.GetDisplayName()}");

                entity.HasIndex(p => new { p.ProductId, p.SIGNo }).IsUnique();
                entity.HasIndex(p => p.Barcode);

                entity.Property(p => p.IsParentalProduct).HasDefaultValueSql("0");
                entity.Property(p => p.IsSystemPredefined).HasDefaultValueSql("0");
                entity.Property(p => p.IsNotForOrderProcessing).HasDefaultValueSql("0");
                entity.Property(p => p.IsInvisible).HasDefaultValueSql("0");
                entity.Property(p => p.IsDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");

                // Note: 2025/01/10 改由DbContext指定relationship，從單一個Entity宣告Relationship並指定雙向/父子關聯
                //entity.HasMany(f => f.ProductGeneralCategories)
                //    .WithOne(p => p.Product)
                //    .HasForeignKey(f => f.ProductNo)
                //    .HasPrincipalKey(p => p.ProductNo)
                //    .OnDelete(DeleteBehavior.Cascade);
                
                entity.HasMany(f => f.ProductCosts)
                   .WithOne(p => p.Product)
                   .HasForeignKey(f => f.ProductNo)
                   .HasPrincipalKey(p => p.ProductNo)
                   .OnDelete(DeleteBehavior.Cascade);

                
                entity.HasMany(f => f.ProductPrices)
                    .WithOne(p => p.Product)
                    .HasForeignKey(f => f.ProductNo)
                    .HasPrincipalKey(p => p.ProductNo)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(f => f.ProductSuppliers)
                    .WithOne(p => p.Product)
                    .HasForeignKey(f => f.ProductNo)
                    .HasPrincipalKey(p => p.ProductNo)
                    .OnDelete(DeleteBehavior.Cascade);


                entity.HasQueryFilter(c => c.IsDisabled == false);
                entity.HasQueryFilter(c => c.IsDeleted == false);
            });


            modelBuilder.Entity<ProductCost>(entity =>
            {
                entity.HasKey(p => new { p.ProductNo, p.CostNo });
            });

            modelBuilder.Entity<ProductCostDefinition>(entity =>
            {
                entity.HasKey(p => new {p.SIGNo, p.CostNo });
            });

            modelBuilder.Entity<ProductGeneralCategory>(entity =>
            {
                // Note: 2025/01/10 不知何故，似乎都正常了，不需從DbContext指定relationship
                //entity.HasOne(p => p.ProductGeneralCategoryItem)
                //    .WithMany()
                //    .HasForeignKey(f => f.PGCItemNo)
                //    .HasPrincipalKey(p => p.PGCItemNo)
                //     Note: 2024/12/28 若未指定NoAction => This may cause a cycle or multiple cascade paths. Please specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints. Unable to create constraint or index
                //    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(p => p.Product)
                    .WithMany(f => f.ProductGeneralCategories)
                    .HasForeignKey(f => f.ProductNo)
                    .HasPrincipalKey(p => p.ProductNo)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");
            });


            modelBuilder.Entity<ProductGeneralCategoryDefinition>(entity =>
            {
                entity.Property(p => p.PGCategoryNo)
                    .HasDefaultValueSql($"NEXT VALUE FOR {SBRPData.DbSystemModel.DB_Schema_psi}.{TableColumnSeed.ProductGeneralCategoryDefinition.GetDisplayName()}");

                entity.HasIndex(p => new {p.PGCategoryId, p.SIGNo }).IsUnique();

                entity.Property(p => p.PGCOrderNo).HasDefaultValueSql("0");
                entity.Property(p => p.ItemIdMinLength).HasDefaultValueSql("0");
                entity.Property(p => p.ItemIdMaxLength).HasDefaultValueSql("0");

                entity.Property(p => p.IsSystemPredefined).HasDefaultValueSql("0");
                entity.Property(p => p.IsInvisible).HasDefaultValueSql("0");
                entity.Property(p => p.IsDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");




                entity.HasQueryFilter(c => c.IsDeleted == false);
            });

            modelBuilder.Entity<ProductGeneralCategoryItem>(entity =>
            {
                entity.Property(p => p.PGCItemNo)
                    .HasDefaultValueSql($"NEXT VALUE FOR {SBRPData.DbSystemModel.DB_Schema_psi}.{TableColumnSeed.ProductGeneralCategoryItem.GetDisplayName()}");

                // 每個類別下的項目Id不可重複
                entity.HasIndex(p => new { p.PGCategoryNo, p.PGCItemId }).IsUnique();

                
                entity.Property(p => p.IsSystemPredefined).HasDefaultValueSql("0");
                entity.Property(p => p.IsDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");

                entity.HasQueryFilter(c => c.IsDisabled == false);
            });

            modelBuilder.Entity<ProductIdStructureDefinition>(entity =>
            {

            });

            modelBuilder.Entity<ProductPrice>(entity =>
            {
                entity.HasKey(p => new { p.ProductNo, p.PriceNo });               
            });

            modelBuilder.Entity<ProductPriceDefinition>(entity =>
            {
                entity.HasKey(p => new {p.SIGNo, p.PriceNo});
            });


            modelBuilder.Entity<ProductStock>(entity =>
            {
                entity.HasKey(p => new {p.StockNo, p.ProductNo });

                entity.Property(p => p.SellableQty).HasComputedColumnSql("[StockQty] - [InTransitQty] - [PreOrderQty]");

                entity.Property(p => p.PreOrderQty).HasDefaultValueSql("0");
                entity.Property(p => p.InTransitQty).HasDefaultValueSql("0");
                entity.Property(p => p.StockQty).HasDefaultValueSql("0");
                entity.Property(p => p.LogNo).HasDefaultValueSql("0");

                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");
            });


            modelBuilder.Entity<ProductSupplier>(entity =>
            {
                entity.Property(p => p.IsDefault).HasDefaultValueSql("0");
                entity.Property(p => p.IsDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");
            });











            modelBuilder.Entity<SaleOrder>(entity =>
            {
                entity.HasKey(p => new { p.OrderDateNo, p.DaySerialNo });

                entity.HasIndex(p => new { p.OrderId, p.SIGNo }).IsUnique();
                entity.HasIndex(p => p.OrderNo).IsUnique();

                entity.HasIndex(p => p.StockNo);
                entity.HasIndex(p => p.MemberNo);

                entity.Property(p => p.OrderDate).HasComputedColumnSql(DbSystemData.SQL_Table_Orders_OrderDate_Computed);
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(p => p.LogNo).HasDefaultValueSql("0");


                entity.HasMany(f => f.SaleOrderDetails)
                    .WithOne()
                    .HasForeignKey(f => f.OrderNo)
                    .HasPrincipalKey(p => p.OrderNo)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasQueryFilter(c => c.IsDeleted == false);
            });

            modelBuilder.Entity<SaleOrderDetail>(entity =>
            {
                entity.HasKey(p => new { p.OrderNo, p.ItemNo });
                entity.HasIndex(p => p.ProductNo);
                entity.Property(p => p.SubAmount).HasComputedColumnSql("([ActualSellingPrice] * [Quantity])");
            });





            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(p => p.StockNo);

                entity.Property(p => p.StockNo)
                    .HasDefaultValueSql($"NEXT VALUE FOR {SBRPData.DbSystemModel.DB_Schema_psi}.{TableColumnSeed.Stock.GetDisplayName()}");


                entity.HasIndex(entity => new { entity.StockId, entity.SIGNo }).IsUnique();

                entity.Property(p => p.SIGNo).HasDefaultValueSql("0");
                entity.Property(p => p.IsSystemPredefined).HasDefaultValueSql("0");
                entity.Property(p => p.IsDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");

                entity.HasQueryFilter(c => c.IsDisabled == false);
            });


            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(p => p.StoreNo)
                    .HasDefaultValueSql($"NEXT VALUE FOR {SBRPData.DbSystemModel.DB_Schema_psi}.{TableColumnSeed.Store.GetDisplayName()}");


                entity.HasIndex(entity => new { entity.StoreId, entity.SIGNo }).IsUnique();

                entity.Property(p => p.SIGNo).HasDefaultValueSql("0");
                entity.Property(p => p.IsSystemPredefined).HasDefaultValueSql("0");
                entity.Property(p => p.IsDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");

                entity.HasQueryFilter(c => c.IsDisabled == false);
            });


            modelBuilder.Entity<StoreRegion>(entity =>
            {
                entity.HasKey(p => p.StoreRegionNo);
                entity.Property(p => p.StoreRegionNo)
                    .HasDefaultValueSql($"NEXT VALUE FOR {SBRPData.DbSystemModel.DB_Schema_psi}.{TableColumnSeed.StoreRegion.GetDisplayName()}");

                entity.HasIndex(entity => new { entity.StoreRegionId, entity.SIGNo }).IsUnique();

                entity.Property(p => p.SIGNo).HasDefaultValueSql("0");
                entity.Property(p => p.IsSystemPredefined).HasDefaultValueSql("0");
                entity.Property(p => p.IsDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");


                entity.HasQueryFilter(c => c.IsDisabled == false);
            });



            modelBuilder.Entity<StockTransferOrder>(entity =>
            {
                entity.HasKey(p => new { p.OrderDateNo, p.DaySerialNo });

                entity.HasIndex(p => new { p.OrderId, p.SIGNo }).IsUnique();
                entity.HasIndex(p => p.OrderNo).IsUnique();

                entity.HasIndex(p => p.FromStockNo);
                entity.HasIndex(p => p.ToStockNo);

                entity.Property(p => p.OrderDate).HasComputedColumnSql(DbSystemData.SQL_Table_Orders_OrderDate_Computed);
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(p => p.LogNo).HasDefaultValueSql("0");

                entity.HasOne(p => p.FromStock)
                    .WithMany()
                    .HasForeignKey(f => f.FromStockNo)
                    .HasPrincipalKey(p => p.StockNo)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(p => p.ToStock)
                    .WithMany()
                    .HasForeignKey(f => f.ToStockNo)
                    .HasPrincipalKey(p => p.StockNo)
                    .OnDelete(DeleteBehavior.NoAction);


                entity.HasMany(f => f.StockTransferOrderDetails)
                    .WithOne()
                    .HasForeignKey(f => f.OrderNo)
                    .HasPrincipalKey(p => p.OrderNo)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasQueryFilter(c => c.IsDeleted == false);
            });

            modelBuilder.Entity<StockTransferOrderDetail>(entity =>
            {
                entity.HasKey(p => new { p.OrderNo, p.ItemNo });
                entity.HasIndex(p => p.ProductNo);
            });





            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(p => p.SupplierNo)
                    .HasDefaultValueSql($"NEXT VALUE FOR {SBRPData.DbSystemModel.DB_Schema_psi}.{TableColumnSeed.Supplier.GetDisplayName()}");

                entity.HasIndex(p => new {p.SupplierId, p.SIGNo}).IsUnique();


                entity.Property(p => p.SIGNo).HasDefaultValueSql("0");
                entity.Property(p => p.IsSystemPredefined).HasDefaultValueSql("0");
                entity.Property(p => p.IsDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");
                         
                entity.HasQueryFilter(c => c.IsDisabled == false);
            });


            modelBuilder.Entity<SupplierGroup>(entity =>
            {
                entity.Property(p => p.SupplierGroupNo)
                    .HasDefaultValueSql($"NEXT VALUE FOR {SBRPData.DbSystemModel.DB_Schema_psi}.{TableColumnSeed.SupplierGroup.GetDisplayName()}");

                entity.HasIndex(p => new { p.SupplierGroupId, p.SIGNo }).IsUnique();


                entity.Property(p => p.SIGNo).HasDefaultValueSql("0");
                entity.Property(p => p.IsSystemPredefined).HasDefaultValueSql("0");
                entity.Property(p => p.IsDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");

                entity.HasQueryFilter(c => c.IsDisabled == false);
            });

            // tell add-migration to ignore this property
            //modelBuilder.Ignore<SBRPData.Models.Company>();
            //modelBuilder.Ignore<SBRPData.Models.Person>();
            //modelBuilder.Ignore<SBRPData.Models.CompanyPerson>();
            #endregion










            #region "User Defined Function"

            #endregion







            #region "UDTF TVF HasDbFunction"
            //OnModelCreating_UDTF(modelBuilder);
            modelBuilder.HasDbFunction(typeof(PsiDbContext).GetMethod(
                nameof(udtfGET_Menuitem_ByUserWithPermission)
              , new[] { typeof(byte), typeof(short) }));

            modelBuilder.HasDbFunction(typeof(PsiDbContext).GetMethod(
                nameof(udtfGET_Menuitem_FromProductGeneralCategoryDefinition)
                , new[] { typeof(byte), typeof(short) }));


            modelBuilder.HasDbFunction(typeof(PsiDbContext).GetMethod(
                nameof(udtfGET_OperationClassStock_Stock)
                , new[] { typeof(OperationClassEnum), typeof(byte), typeof(short) }));
            #endregion







            #region "Seeding Data"
            OnModelCreating_DataSeeding(modelBuilder);           
            #endregion




            base.OnModelCreating(modelBuilder);
            
        }










        public  void OnModelCreating_UDTF(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDbFunction(typeof(PsiDbContext).GetMethod(
            //    nameof(udtfGET_Menuitem_ByUserWithPermission)
            //  , new[] { typeof(byte), typeof(short) }));

            //modelBuilder.HasDbFunction(typeof(PsiDbContext).GetMethod(
            //    nameof(udtfGET_Menuitem_FromProductGeneralCategoryDefinition)
            //    , new[] { typeof(byte), typeof(short) }));


            //modelBuilder.HasDbFunction(typeof(PsiDbContext).GetMethod(
            //    nameof(udtfGET_OperationClassStock_Stock)
            //    , new[] { typeof(byte), typeof(byte), typeof(short) }));
        }







        #region "UDF"
        
        #endregion





        #region "UTDF TVF"
        public IQueryable<Menuitem> udtfGET_Menuitem_ByUserWithPermission(byte _sIGNo, short _userNo)
            => FromExpression(() => udtfGET_Menuitem_ByUserWithPermission(_sIGNo, _userNo));

        public IQueryable<Menuitem> udtfGET_Menuitem_FromProductGeneralCategoryDefinition(byte _sIGNo, short _userNo)
            => FromExpression(() => udtfGET_Menuitem_FromProductGeneralCategoryDefinition(_sIGNo, _userNo));

        public IQueryable<Stock> udtfGET_OperationClassStock_Stock(OperationClassEnum _operationClassNo, byte _sIGNo, short _userNo)
          => FromExpression(() => udtfGET_OperationClassStock_Stock(_operationClassNo, _sIGNo, _userNo));


        #endregion








        public void OnModelCreating_DataSeeding(ModelBuilder modelBuilder)
        {
            // issue:每個SIGNo自己admin ?
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    UserNo = SBRPData.DbSystemData.DEF_User_UserNo_Admin_GeneralDefault
                });





            // System開設之初，就應決定此DB是單一客戶使用or多公司使用（透過SP執行建立初始資料）
            //modelBuilder.Entity<SystemIsolationGroup>().HasData(
            //        new SystemIsolationGroup 
            //        { SIGNo = 0, SIGId = "DEFAULT", SIGName = "Default", IsSystemPredefined = true, IsDisabled = false, IsDeleted = false, CreatedPerson = createdPersonNo_preDef, CreatedDate = DateTime.Now }
            //    );

        }








    }
}
