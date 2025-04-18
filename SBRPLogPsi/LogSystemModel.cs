using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPLogPsi
{
    public class LogSystemModel
    {
    }





    public class LogOperationData
    {
        public LogOperationData() { }

        public LogOperationData(LogTypeEnum _logTypeNo, int _loginActionSN)
        {
            this.LogTypeNo = _logTypeNo;
            this.LoginActionSN = _loginActionSN;
        }
        public LogOperationData(int _operationNo, LogTypeEnum _logTypeNo, int _loginActionSN)
        {
            this.OperationNo = _operationNo;
            this.LogTypeNo = _logTypeNo;
            this.LoginActionSN = _loginActionSN;
        }
        public LogOperationData(OperationClassEnum _operationClassNo, int _operationNo, LogTypeEnum _logTypeNo, int _loginActionSN)
        {
            this.OperationNo = _operationNo;
            this.OperationClassNo = _operationClassNo;
            this.LogTypeNo = _logTypeNo;
            this.LoginActionSN = _loginActionSN;
        }



        public int LogSN { get; set; }
        public int OperationNo { get; set; }
        public LogTypeEnum LogTypeNo { get; set; }
        public int LoginActionSN { get; set; }

        public OperationClassEnum OperationClassNo { get; set; }
    }




    // correspond the byte value of BOPCMSData.Models.SubmitActionModeEnum
    // correspond the byte value of BOPCMSLogData.Models.LogTypeEnum
    // partial correspond the byte value of BOPCMSWeb.Models.Models.FormEditModeEnum (UserActionModel)
    public enum LogTypeEnum : byte
    {
        Original = 1,

        // 1 Adding (before inserting)
        Add = 10,

        // 2 Editing (before updating)
        Edit = 20,
        Edit_ForRollbackOld = 22,
        Edit_ForCommitNew = 24,


        // 3 Remove (Before deleting)
        Remove = 30,

        // 4 AfterUpdated
        Updated = 40,



    }



}
