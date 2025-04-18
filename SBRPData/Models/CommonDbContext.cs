using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.EntityFrameworkCore.SqlServer;


namespace SBRPData.Models
{
    public class CommonDbContext : DbContext
    {
        private readonly string m_ConnectionString = @"Data Source=LOCALHOST\MSSQLSERVER2019;Initial Catalog=SBRPDB;Persist Security Info=True;Integrated Security=True;TrustServerCertificate=true;MultipleActiveResultSets=true;";


        public CommonDbContext()
        {
        }
        public CommonDbContext(DbContextOptions<CommonDbContext> options) : base(options)
        {
        }






        #region "Table"
        


        public virtual DbSet<Company> Companys { get; set; }

        public virtual DbSet<CompanyContactPerson> CompanyContactPersons { get; set; }

        public virtual DbSet<CompanyJobTitle> CompanyJobTitles { get; set; }




        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<DepartmentEmployee> DepartmentEmployees { get; set; }

        public virtual DbSet<Division> Divisions { get; set; }





        public virtual DbSet<Employee> Employees { get; set; }




        public virtual DbSet<Person> Persons { get; set; }

        public virtual DbSet<PersonContactAddress> PersonContactAddresses { get; set; }

        public virtual DbSet<PersonContactEmail> PersonContactEmails { get; set; }

        public virtual DbSet<PersonContactPhone> PersonContactPhones { get; set; }


        public virtual DbSet<Position> Positions { get; set; }


        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserLoginHistory> UserLoginHistorys { get; set; }

        public virtual DbSet<UserLoginToken> UserLoginTokens { get; set; }
        #endregion




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(m_ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }










        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
            modelBuilder.HasDefaultSchema(DbSystemModel.DB_Schema_dbo);


            CommonContextConfiguration.ModelCreating(modelBuilder);


            CommonContextConfiguration.DataSeeding(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
