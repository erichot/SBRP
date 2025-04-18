using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData
{
    // Relate to ColumnEnumModel.SBRP_AppIdEnum
    public class DbSystemModel
    {
        public const bool DB_IsUsed_SigIdn = true;

        public const string DB_Schema_dbo = "dbo";

        // 1
        public const string DB_Schema_common = "common";

        // 23
        public const string DB_Schema_psi = "psi";
    }




    public class DbSystemData
    {
        public const short DEF_PREDEF_GeneralNo = -1;
        public const string DEF_PREDEF_GeneralId = "_PREDEF_";
        public const string DEF_PREDEF_GeneralName = "(PreDefine)";
        public const string DEF_PREDEF_GeneralAbbrName = "PreDef";

        public const string DEF_ALL_Id_Everyone = "_ALL_";

        public const short DEF_User_UserNo_DBCreator = 90;
        public const short DEF_Person_PersonNo_DBCreator = 90;
        
        public const byte DEF_SystemIsolationGroup_SIGNo_GeneralDefault = 0;

        
        public const short DEF_User_UserNo_Admin_GeneralDefault = 1;
        public const string DEF_User_UserId_Admin_GeneralDefault = "ADMIN";
        public const string DEF_User_LoginId_Admin_GeneralDefault = DEF_User_UserId_Admin_GeneralDefault;
        public const string DEF_User_UserName_Admin_GeneralDefault = "ADMINISTRATOR";
        public const string DEF_User_PasswordHash_Admin_GeneralDefault = "MjZALnvidPPUogKCJ8w9wg==";       // 1234

        public const short DEF_Person_PersonNo_Admin_GeneralDefault = DEF_User_UserNo_Admin_GeneralDefault;
        public const string DEF_Person_PersonId_Admin_GeneralDefault = DEF_User_UserId_Admin_GeneralDefault;
        public const string DEF_Person_PersonName_Admin_GeneralDefault = DEF_User_UserName_Admin_GeneralDefault;





        

    }





    public enum TableColumnSeed : int
    {
        // byte
        [Display(Name = "seqSystemIsolationGroup")]
        SystemIsolationGroup = 11,

        // short
        [Display(Name = "seqPosition")]
        Position = 1_001,

        [Display(Name = "seqDivisionNo")]
        Divisioin = 1_601,

        [Display(Name = "seqDepartment")]
        Department = 2_001,

        [Display(Name = "seqUser")]
        User = 3_001,

        [Display(Name = "seqCompany")]
        Company = 5_001,

        [Display(Name = "seqEmployee")]
        Employee = 10_001,




        // int
        [Display(Name = "seqPerson")]
        Person = 10_001

        
    }















}
