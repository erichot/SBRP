using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SBRPLogPsi.Models
{
    public class LogDbContext: DbContext
    {
        private readonly string m_ConnectionString = @"Data Source=LOCALHOST\MSSQLSERVER2019;Initial Catalog=SBRPDBLOG;Persist Security Info=True;Integrated Security=True;TrustServerCertificate=true;MultipleActiveResultSets=true;";




        public virtual DbSet<InboundStockOrderLog> InboundStockOrderLogs { get; set; }

        public virtual DbSet<InboundStockOrderDetailLog> InboundStockOrderDetailLogs { get; set; }





        public virtual DbSet<SaleOrderLog> SaleOrderLogs { get; set; }

        public virtual DbSet<SaleOrderDetailLog> SaleOrderDetailLogs { get; set; }





        public virtual DbSet<StockTransferOrderLog> StockTransferOrderLogs { get; set; }

        public virtual DbSet<StockTransferOrderDetailLog> StockTransferOrderDetailLogs { get; set; }



        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options)
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

            modelBuilder.HasDefaultSchema(SBRPData.DbSystemModel.DB_Schema_psi);







            modelBuilder.Entity<InboundStockOrderLog>(entity =>
            {
                entity.Property(c => c.ArchivedDate).HasDefaultValueSql("GETDATE()");
            });
            modelBuilder.Entity<InboundStockOrderDetailLog>(entity =>
            {
                entity.HasKey(p => new {p.LogNo, p.ItemNo });
                entity.Property(c => c.ArchivedDate).HasDefaultValueSql("GETDATE()");

                entity.Property(p => p.SubAmount).HasComputedColumnSql("[Quantity] * [UnitCost]");
            });






            modelBuilder.Entity<SaleOrderLog>(entity =>
            {
                entity.Property(c => c.ArchivedDate).HasDefaultValueSql("GETDATE()");
            });
            modelBuilder.Entity<SaleOrderDetailLog>(entity =>
            {
                entity.HasKey(p => new { p.LogNo, p.ItemNo });
                entity.Property(c => c.ArchivedDate).HasDefaultValueSql("GETDATE()");

                entity.Property(p => p.SubAmount).HasComputedColumnSql("[Quantity] * [ActualSellingPrice]");
            });




            modelBuilder.Entity<StockTransferOrderLog>(entity =>
            {
                entity.Property(c => c.ArchivedDate).HasDefaultValueSql("GETDATE()");
            });
            modelBuilder.Entity<StockTransferOrderDetailLog>(entity =>
            {
                entity.HasKey(p => new { p.LogNo,  p.ItemNo });
                entity.Property(c => c.ArchivedDate).HasDefaultValueSql("GETDATE()");
            });





            base.OnModelCreating(modelBuilder);
        }







    }
}
