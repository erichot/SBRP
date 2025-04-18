
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SBRPData;
using SBRPData.Models;

namespace SBRPData
{
    public static class CommonContextConfiguration
    {
        public static void ModelCreating(ModelBuilder modelBuilder)
        {

            #region "Sequence"
            // byte
            modelBuilder.HasSequence<byte>(SBRPData.TableColumnSeed.SystemIsolationGroup.GetDisplayName(), DbSystemModel.DB_Schema_common)
                .StartsAt((long)SBRPData.TableColumnSeed.SystemIsolationGroup).IncrementsBy(1);

            // short
            modelBuilder.HasSequence<short>(SBRPData.TableColumnSeed.Position.GetDisplayName(), DbSystemModel.DB_Schema_common)
                .StartsAt((long)SBRPData.TableColumnSeed.Position).IncrementsBy(1);

            modelBuilder.HasSequence<short>(SBRPData.TableColumnSeed.Divisioin.GetDisplayName(), DbSystemModel.DB_Schema_common)
                .StartsAt((long)SBRPData.TableColumnSeed.Divisioin).IncrementsBy(1);

            modelBuilder.HasSequence<short>(SBRPData.TableColumnSeed.Department.GetDisplayName(), DbSystemModel.DB_Schema_common)
                .StartsAt((long)SBRPData.TableColumnSeed.Department).IncrementsBy(1);

            modelBuilder.HasSequence<short>(SBRPData.TableColumnSeed.User.GetDisplayName(), DbSystemModel.DB_Schema_common)
                .StartsAt((long)SBRPData.TableColumnSeed.User).IncrementsBy(1);

            modelBuilder.HasSequence<short>(SBRPData.TableColumnSeed.Company.GetDisplayName(), DbSystemModel.DB_Schema_common)
                .StartsAt((long)SBRPData.TableColumnSeed.Company).IncrementsBy(1);

            modelBuilder.HasSequence<short>(SBRPData.TableColumnSeed.Employee.GetDisplayName(), DbSystemModel.DB_Schema_common)
                .StartsAt((long)SBRPData.TableColumnSeed.Employee).IncrementsBy(1);

            // int
            modelBuilder.HasSequence<int>(SBRPData.TableColumnSeed.Person.GetDisplayName() , DbSystemModel.DB_Schema_common)
                .StartsAt((long)SBRPData.TableColumnSeed.Person).IncrementsBy(1);
            #endregion




            #region "modelBuilder.Entity"
            modelBuilder.Entity<Company>(entity =>
            {                
                entity.Property(p => p.CompanyNo)
                    .HasDefaultValueSql($"NEXT VALUE FOR {DbSystemModel.DB_Schema_common}.{SBRPData.TableColumnSeed.Company.GetDisplayName()}");

                entity.HasIndex(p => new {p.CompanyId, p.SIGNo }).IsUnique();

                entity.Property(p => p.SIGNo).HasDefaultValueSql("0");
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.IsSystemPredefined).HasDefaultValueSql("0");
                entity.Property(p => p.IsDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");

                entity.HasQueryFilter(p => p.IsDeleted == false);
            });


            

            modelBuilder.Entity<CompanyContactPerson>(entity =>
            {

                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");

                entity.HasQueryFilter(p => p.IsDeleted == false);
            });







            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(p => p.DepartmentNo)
                    .HasDefaultValueSql($"NEXT VALUE FOR {DbSystemModel.DB_Schema_common}.{SBRPData.TableColumnSeed.Department.GetDisplayName()}");

                entity.HasIndex(p => new { p.DepartmentId, p.SIGNo }).IsUnique();

                entity.Property(p => p.SIGNo).HasDefaultValueSql("0");
                entity.Property(p => p.IsSystemPredefined).HasDefaultValueSql("0");
                entity.Property(p => p.IsDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");

                entity.HasQueryFilter(p => p.IsDeleted == false);
            });


            modelBuilder.Entity<Division>(entity =>
            {
                entity.Property(p => p.DivisionNo)
                    .HasDefaultValueSql($"NEXT VALUE FOR {DbSystemModel.DB_Schema_common}.{SBRPData.TableColumnSeed.Divisioin.GetDisplayName()}");

                entity.HasIndex(p => new { p.DivisionId, p.SIGNo }).IsUnique();

                entity.Property(p => p.SIGNo).HasDefaultValueSql("0");
                entity.Property(p => p.IsSystemPredefined).HasDefaultValueSql("0");
                entity.Property(p => p.IsDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.IsInvisible).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");

                entity.HasQueryFilter(p => p.IsDeleted == false);
            });








            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(p => p.PersonNo)
                    .HasDefaultValueSql($"NEXT VALUE FOR {DbSystemModel.DB_Schema_common}.{SBRPData.TableColumnSeed.Employee.GetDisplayName()}");

                entity.HasIndex(entity => new { entity.EmployeeId, entity.SIGNo }).IsUnique();

                entity.Property(p => p.SIGNo).HasDefaultValueSql("0");
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.IsSystemPredefined).HasDefaultValueSql("0");
                entity.Property(p => p.IsDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.IsInvisible).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");

                entity.HasQueryFilter(p => p.IsDeleted == false);
            });






            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasIndex(entity => new { entity.PersonId, entity.SIGNo }).IsUnique();

                entity.Property(p => p.PersonNo)
                    .HasDefaultValueSql($"NEXT VALUE FOR {DbSystemModel.DB_Schema_common}.{SBRPData.TableColumnSeed.Person.GetDisplayName()}");


                entity.Property(p => p.SIGNo).HasDefaultValueSql("0");
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.IsSystemPredefined).HasDefaultValueSql("0");
                entity.Property(p => p.IsDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");

                entity.HasMany(f => f.PersonContactAddresses)
                  .WithOne(p => p.Person)
                  .HasForeignKey(f => f.PersonNo)
                  .HasPrincipalKey(p => p.PersonNo)
                  .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(f => f.PersonContactEmails)
                 .WithOne(p => p.Person)
                 .HasForeignKey(f => f.PersonNo)
                 .HasPrincipalKey(p => p.PersonNo)
                 .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(f => f.PersonContactPhones)
                  .WithOne(p => p.Person)
                  .HasForeignKey(f => f.PersonNo)
                  .HasPrincipalKey(p => p.PersonNo)
                  .OnDelete(DeleteBehavior.Cascade);

                entity.HasQueryFilter(p => p.IsDeleted == false);
            });


            modelBuilder.Entity<PersonContactAddress>(entity =>
            {
                entity.HasKey(p => new { p.PersonNo, p.ItemNo });
            });

            modelBuilder.Entity<PersonContactEmail>(entity =>
            {
                entity.HasKey(p => new { p.PersonNo, p.ItemNo });
            });


            modelBuilder.Entity<PersonContactPhone>(entity =>
            {
                entity.HasKey(p => new { p.PersonNo, p.ItemNo });
            });





            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(p => p.PositionNo)
                    .HasDefaultValueSql($"NEXT VALUE FOR {DbSystemModel.DB_Schema_common}.{SBRPData.TableColumnSeed.Position.GetDisplayName()}");


                entity.Property(p => p.SIGNo).HasDefaultValueSql("0");
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.IsSystemPredefined).HasDefaultValueSql("0");
                entity.Property(p => p.IsDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");

                entity.HasQueryFilter(p => p.IsDeleted == false);
            });



            modelBuilder.Entity<SystemIsolationGroup>(entity =>
            {

                // Note: 不會常常在Insert, 故打算取消DefaultValue
                // Remark: Unable to create a 'DbContext' of type 'PsiDbContext'. The exception 'The seed entity for entity type 'SystemIsolationGroup' cannot be added because a default value was provided for the required property 'SIGNo'. Please provide a value different from '0'.' was thrown while attempting to create an instance. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
                entity.Property(p => p.SIGNo)
                    .HasDefaultValueSql($"NEXT VALUE FOR {DbSystemModel.DB_Schema_common}.{SBRPData.TableColumnSeed.SystemIsolationGroup.GetDisplayName()}");


                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");
                entity.Property(p => p.IsSystemPredefined).HasDefaultValueSql("0");
                entity.Property(p => p.IsDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");

                // Remark: Error: The seed entity for entity type 'SystemIsolationGroup' cannot be added because a default value was provided for the required property 'SIGNo'. Please provide a value different from '0'.
                // 整個Table中的第一筆資料
                // Unable to create a 'DbContext' of type 'PsiDbContext'. The exception 'The seed entity for entity type 'SystemIsolationGroup' cannot be added because a default value was provided for the required property 'SIGNo'. Please provide a value different from '0'.' was thrown while attempting to create an instance. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
                //entity.HasData(
                //    new SystemIsolationGroup { SIGNo = 0, SIGId = "DEFAULT", SIGName = "Default", IsSystemPredefined = true, IsDisabled = false, IsDeleted = false, CreatedDate = DateTime.Now }
                //);

                
                entity.HasQueryFilter(p => p.IsDeleted == false);
            });



            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(p => p.UserNo)
                    .HasDefaultValueSql($"NEXT VALUE FOR {DbSystemModel.DB_Schema_common}.{SBRPData.TableColumnSeed.User.GetDisplayName()}");

                entity.HasIndex(entity => new { entity.UserId, entity.SIGNo }).IsUnique();

                entity.Property(p => p.SIGNo).HasDefaultValueSql("0");
                entity.Property(p => p.IsSystemPredefined).HasDefaultValueSql("0");
                entity.Property(p => p.IsReadonly).HasDefaultValueSql("0");
                entity.Property(p => p.HasBeenLocked).HasDefaultValueSql("0");
                entity.Property(p => p.IsDisabled).HasDefaultValueSql("0");
                entity.Property(p => p.IsDeleted).HasDefaultValueSql("0");                
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");


                entity.HasQueryFilter(p => p.IsDeleted == false);
            });


            modelBuilder.Entity<UserLoginHistory>(entity =>
            {
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");
            });
            modelBuilder.Entity<UserLoginToken>(entity =>
            {
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");
                entity.Property(p => p.InValid).HasDefaultValueSql("0");
            });
            modelBuilder.Entity<UserPasswordHistory>(entity =>
            {
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");
            });
            #endregion






        }















        public static void DataSeeding(ModelBuilder modelBuilder)
        {
            //const string preDefId = "_PREDEF_";
            //const string preDefName = "(PreDefine)";
            //const short createdPersonNo_preDef = 90;
            //const short preDefNo_NegValue = -1;
            //const byte SIGNo_Default = 0;

            //const short personNo_Admin = 1;
            //const short userNo_Admin = 1;
            //const string userId_Admin = "ADMIN";
            //const string passwordHash_Admin = "MjZALnvidPPUogKCJ8w9wg==";       // 1234
            //const string personId_Admin = "ADMIN";
            //const string userName_Admin = "ADMINISTRATOR";





            #region "PreDefine Disabled data for ForeignKey data"
            modelBuilder.Entity<Person>().HasData(
                new Person()
                {
                    PersonNo = DbSystemData.DEF_PREDEF_GeneralNo,
                    SIGNo = DbSystemData.DEF_SystemIsolationGroup_SIGNo_GeneralDefault,
                    PersonId = DbSystemData.DEF_PREDEF_GeneralId,
                    PersonName = DbSystemData.DEF_PREDEF_GeneralName,
                    IsSystemPredefined = true,
                    IsDisabled = true,
                    IsDeleted = false,
                    CreatedPerson = DbSystemData.DEF_User_UserNo_DBCreator,
                    CreatedDate = DateTime.Now                    
                });

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    UserNo = DbSystemData.DEF_PREDEF_GeneralNo,
                    SIGNo = DbSystemData.DEF_SystemIsolationGroup_SIGNo_GeneralDefault,
                    UserId = DbSystemData.DEF_PREDEF_GeneralId,
                    LoginId = DbSystemData.DEF_PREDEF_GeneralId,
                    PersonNo = DbSystemData.DEF_PREDEF_GeneralNo,
                    PasswordHash = DbSystemData.DEF_PREDEF_GeneralId,
                    IsSystemPredefined = true,
                    IsDisabled = true,
                    IsDeleted = false,   
                    CreatedPerson = DbSystemData.DEF_User_UserNo_DBCreator,
                    CreatedDate = DateTime.Now,
                });
             
            modelBuilder.Entity<Company>().HasData(
               new Company()
               {
                   CompanyNo = DbSystemData.DEF_PREDEF_GeneralNo,
                   SIGNo = DbSystemData.DEF_SystemIsolationGroup_SIGNo_GeneralDefault,
                   CompanyId = DbSystemData.DEF_PREDEF_GeneralId,
                   TaxId = DbSystemData.DEF_PREDEF_GeneralId,
                   CompanyName = DbSystemData.DEF_PREDEF_GeneralName,
                   CompanyNameAbbr = DbSystemData.DEF_PREDEF_GeneralAbbrName,
                   IsSystemPredefined = true,
                   IsDisabled = true,
                   IsDeleted = false,
                   CreatedDate = DateTime.Now,
                   CreatedPerson = DbSystemData.DEF_User_UserNo_DBCreator
               });



            modelBuilder.Entity<Department>().HasData(
                new Department()
                {
                    DepartmentNo = DbSystemData.DEF_PREDEF_GeneralNo,
                    SIGNo = DbSystemData.DEF_SystemIsolationGroup_SIGNo_GeneralDefault,
                    DepartmentId = DbSystemData.DEF_PREDEF_GeneralId,
                    DepartmentName = DbSystemData.DEF_PREDEF_GeneralName,
                    DepartmentNameAbbr = DbSystemData.DEF_PREDEF_GeneralAbbrName,
                    IsSystemPredefined = true,
                    IsDisabled = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                    CreatedPerson = DbSystemData.DEF_User_UserNo_DBCreator
                });
            #endregion








            #region "Default User Admin"
            modelBuilder.Entity<Person>().HasData(
               new Person()
               {
                   PersonNo = DbSystemData.DEF_Person_PersonNo_Admin_GeneralDefault,
                   SIGNo = DbSystemData.DEF_SystemIsolationGroup_SIGNo_GeneralDefault,
                   PersonId = DbSystemData.DEF_Person_PersonId_Admin_GeneralDefault,
                   PersonName = DbSystemData.DEF_Person_PersonName_Admin_GeneralDefault,
                   IsSystemPredefined = true,
                   IsDisabled = false,
                   IsDeleted = false,
                   CreatedPerson = DbSystemData.DEF_User_UserNo_DBCreator,
                   CreatedDate = DateTime.Now                   
               });


            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    UserNo = DbSystemData.DEF_User_UserNo_Admin_GeneralDefault,
                    UserId = DbSystemData.DEF_User_UserId_Admin_GeneralDefault,
                    LoginId = DbSystemData.DEF_User_LoginId_Admin_GeneralDefault,
                    PersonNo = DbSystemData.DEF_Person_PersonNo_Admin_GeneralDefault,
                    PasswordHash = DbSystemData.DEF_User_PasswordHash_Admin_GeneralDefault,
                    IsSystemPredefined = true,
                    IsDisabled = false,
                    IsDeleted = false,
                    CreatedPerson = DbSystemData.DEF_User_UserNo_DBCreator,
                    CreatedDate = DateTime.Now
                });
            #endregion




            // System開設之初，就應決定此DB是單一客戶使用or多公司使用（透過SP執行建立初始資料）
            //modelBuilder.Entity<SystemIsolationGroup>().HasData(
            //        new SystemIsolationGroup 
            //        { SIGNo = 0, SIGId = "DEFAULT", SIGName = "Default", IsSystemPredefined = true, IsDisabled = false, IsDeleted = false, CreatedPerson = createdPersonNo_preDef, CreatedDate = DateTime.Now }
            //    );

        }



    }
}
