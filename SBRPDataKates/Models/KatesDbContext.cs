using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

public partial class KatesDbContext : DbContext
{
    public KatesDbContext()
    {
    }

    public KatesDbContext(DbContextOptions<KatesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BC_AttendanceStatus> BC_AttendanceStatuses { get; set; }

    public virtual DbSet<BC_EmployeeType> BC_EmployeeTypes { get; set; }

    public virtual DbSet<BC_LeaveType> BC_LeaveTypes { get; set; }

    public virtual DbSet<BC_SlaveCategory> BC_SlaveCategories { get; set; }

    public virtual DbSet<BFX_UserSlaveAddSync> BFX_UserSlaveAddSyncs { get; set; }

    public virtual DbSet<BFX_UserSlaveAllowTime> BFX_UserSlaveAllowTimes { get; set; }

    public virtual DbSet<BF_BellSchedule> BF_BellSchedules { get; set; }

    public virtual DbSet<BF_Contact> BF_Contacts { get; set; }

    public virtual DbSet<BF_Department> BF_Departments { get; set; }

    public virtual DbSet<BF_Division> BF_Divisions { get; set; }

    public virtual DbSet<BF_FP> BF_FPs { get; set; }

    public virtual DbSet<BF_FP_Add> BF_FP_Adds { get; set; }

    public virtual DbSet<BF_FP_Del> BF_FP_Dels { get; set; }

    public virtual DbSet<BF_GlobalHolidaySetting_Detail> BF_GlobalHolidaySetting_Details { get; set; }

    public virtual DbSet<BF_GlobalHolidaySetting_Head> BF_GlobalHolidaySetting_Heads { get; set; }

    public virtual DbSet<BF_Holiday> BF_Holidays { get; set; }

    public virtual DbSet<BF_HourlyPay> BF_HourlyPays { get; set; }

    public virtual DbSet<BF_JobCode> BF_JobCodes { get; set; }

    public virtual DbSet<BF_Supervisor> BF_Supervisors { get; set; }

    public virtual DbSet<BF_TerminalSetting> BF_TerminalSettings { get; set; }

    public virtual DbSet<BF_TimeSet> BF_TimeSets { get; set; }

    public virtual DbSet<BF_TimeZone> BF_TimeZones { get; set; }

    public virtual DbSet<BF_User> BF_Users { get; set; }

    public virtual DbSet<BF_UserGroup> BF_UserGroups { get; set; }

    public virtual DbSet<BF_UserGroupSetting> BF_UserGroupSettings { get; set; }

    public virtual DbSet<BF_UserHourlyPay> BF_UserHourlyPays { get; set; }

    public virtual DbSet<BF_UserWeeklyShift> BF_UserWeeklyShifts { get; set; }

    public virtual DbSet<BF_User_Add> BF_User_Adds { get; set; }

    public virtual DbSet<BF_User_Del> BF_User_Dels { get; set; }

    public virtual DbSet<BF_WorkCalendar> BF_WorkCalendars { get; set; }

    public virtual DbSet<BF_WorkShift> BF_WorkShifts { get; set; }

    public virtual DbSet<CF_TransactionImportDetail> CF_TransactionImportDetails { get; set; }

    public virtual DbSet<CF_TransactionImportHead> CF_TransactionImportHeads { get; set; }

    public virtual DbSet<CF_UserImportDetail> CF_UserImportDetails { get; set; }

    public virtual DbSet<CF_UserImportHead> CF_UserImportHeads { get; set; }

    public virtual DbSet<DS_BF_FP_Add> DS_BF_FP_Adds { get; set; }

    public virtual DbSet<DS_BF_FP_Del> DS_BF_FP_Dels { get; set; }

    public virtual DbSet<DS_BF_Holiday> DS_BF_Holidays { get; set; }

    public virtual DbSet<DS_BF_Holiday_SlaveSID> DS_BF_Holiday_SlaveSIDs { get; set; }

    public virtual DbSet<DS_BF_TerminalSetting_Add> DS_BF_TerminalSetting_Adds { get; set; }

    public virtual DbSet<DS_BF_TimeSet> DS_BF_TimeSets { get; set; }

    public virtual DbSet<DS_BF_TimeSet_SlaveSID> DS_BF_TimeSet_SlaveSIDs { get; set; }

    public virtual DbSet<DS_BF_TimeZone> DS_BF_TimeZones { get; set; }

    public virtual DbSet<DS_BF_TimeZone_SlaveSID> DS_BF_TimeZone_SlaveSIDs { get; set; }

    public virtual DbSet<DS_BF_UserGroup> DS_BF_UserGroups { get; set; }

    public virtual DbSet<DS_BF_UserGroup_SlaveSID> DS_BF_UserGroup_SlaveSIDs { get; set; }

    public virtual DbSet<DS_BF_User_Add> DS_BF_User_Adds { get; set; }

    public virtual DbSet<DS_BF_User_Del> DS_BF_User_Dels { get; set; }

    public virtual DbSet<OR_ChangeCardID> OR_ChangeCardIDs { get; set; }

    public virtual DbSet<OR_GlobleAPB> OR_GlobleAPBs { get; set; }

    public virtual DbSet<OR_LeaveApplication_Detail> OR_LeaveApplication_Details { get; set; }

    public virtual DbSet<OR_LeaveApplication_Head> OR_LeaveApplication_Heads { get; set; }

    public virtual DbSet<OR_Transaction> OR_Transactions { get; set; }

    public virtual DbSet<OR_UserDataUploadedStack> OR_UserDataUploadedStacks { get; set; }

    public virtual DbSet<REL_LeaveApplication_Justification> REL_LeaveApplication_Justifications { get; set; }

    public virtual DbSet<SBC_UserPermissionType> SBC_UserPermissionTypes { get; set; }

    public virtual DbSet<S_Controller> S_Controllers { get; set; }

    public virtual DbSet<S_DateColmunWeekdayNo> S_DateColmunWeekdayNos { get; set; }

    public virtual DbSet<S_DayTimeTable> S_DayTimeTables { get; set; }

    public virtual DbSet<S_MonthlyCalendar> S_MonthlyCalendars { get; set; }

    public virtual DbSet<S_Notification> S_Notifications { get; set; }

    public virtual DbSet<S_Notification_Log> S_Notification_Logs { get; set; }

    public virtual DbSet<S_Notification_Log_Recipient> S_Notification_Log_Recipients { get; set; }

    public virtual DbSet<S_Notification_Receipient> S_Notification_Receipients { get; set; }

    public virtual DbSet<S_SlaveEventLog> S_SlaveEventLogs { get; set; }

    public virtual DbSet<S_SlaveIP> S_SlaveIPs { get; set; }

    public virtual DbSet<S_SlaveStatusDefinition> S_SlaveStatusDefinitions { get; set; }

    public virtual DbSet<S_SystemSetting> S_SystemSettings { get; set; }

    public virtual DbSet<S_SystemSetting_SMTP> S_SystemSetting_SMTPs { get; set; }

    public virtual DbSet<S_SystemUpdateLog> S_SystemUpdateLogs { get; set; }

    public virtual DbSet<S_TreeviewMenu> S_TreeviewMenus { get; set; }

    public virtual DbSet<S_TreeviewMenu_User> S_TreeviewMenu_Users { get; set; }

    public virtual DbSet<S_WiFi> S_WiFis { get; set; }

    public virtual DbSet<TMP_AttendanceReportMetaDatum> TMP_AttendanceReportMetaData { get; set; }

    public virtual DbSet<TMP_BF_Contact_1116> TMP_BF_Contact_1116s { get; set; }

    public virtual DbSet<TMP_BF_User_196> TMP_BF_User_196s { get; set; }

    public virtual DbSet<TMP_GlobalHolidaySetting_Head_1116> TMP_GlobalHolidaySetting_Head_1116s { get; set; }

    public virtual DbSet<TMP_Import_BFX_UserSlaveAllowTime> TMP_Import_BFX_UserSlaveAllowTimes { get; set; }

    public virtual DbSet<TMP_MonthlyColumnDataSheet> TMP_MonthlyColumnDataSheets { get; set; }

    public virtual DbSet<TMP_UserDailyAttendanceScale> TMP_UserDailyAttendanceScales { get; set; }

    public virtual DbSet<TMP_WorkCalendar_PIVOT> TMP_WorkCalendar_PIVOTs { get; set; }

    public virtual DbSet<TMP_WorkCalendar_UNPIVOT> TMP_WorkCalendar_UNPIVOTs { get; set; }

    public virtual DbSet<TMP_YearlyColumnDataSheet> TMP_YearlyColumnDataSheets { get; set; }

    public virtual DbSet<VBC_AttendanceStatus> VBC_AttendanceStatuses { get; set; }

    public virtual DbSet<VBC_EmployeeType> VBC_EmployeeTypes { get; set; }

    public virtual DbSet<VBC_LeaveType> VBC_LeaveTypes { get; set; }

    public virtual DbSet<VBC_SlaveCategory> VBC_SlaveCategories { get; set; }

    public virtual DbSet<VBFX_UserSlaveAllowTime> VBFX_UserSlaveAllowTimes { get; set; }

    public virtual DbSet<VBF_Contact> VBF_Contacts { get; set; }

    public virtual DbSet<VBF_Department> VBF_Departments { get; set; }

    public virtual DbSet<VBF_Division> VBF_Divisions { get; set; }

    public virtual DbSet<VBF_FP_Add_SynchronizedBySlaveID> VBF_FP_Add_SynchronizedBySlaveIDs { get; set; }

    public virtual DbSet<VBF_FP_Add_UnPivot> VBF_FP_Add_UnPivots { get; set; }

    public virtual DbSet<VBF_GlobalHolidaySetting_Detail> VBF_GlobalHolidaySetting_Details { get; set; }

    public virtual DbSet<VBF_GlobalHolidaySetting_Head> VBF_GlobalHolidaySetting_Heads { get; set; }

    public virtual DbSet<VBF_HourlyPay> VBF_HourlyPays { get; set; }

    public virtual DbSet<VBF_JobCode> VBF_JobCodes { get; set; }

    public virtual DbSet<VBF_Supervisor> VBF_Supervisors { get; set; }

    public virtual DbSet<VBF_TimeSet> VBF_TimeSets { get; set; }

    public virtual DbSet<VBF_User> VBF_Users { get; set; }

    public virtual DbSet<VBF_UserGroupSetting> VBF_UserGroupSettings { get; set; }

    public virtual DbSet<VBF_UserHourlyPay> VBF_UserHourlyPays { get; set; }

    public virtual DbSet<VBF_UserWeeklyShift> VBF_UserWeeklyShifts { get; set; }

    public virtual DbSet<VBF_UserWeeklyShift_2nd> VBF_UserWeeklyShift_2nds { get; set; }

    public virtual DbSet<VBF_User_Add_RejectSynchronized_BySlaveID> VBF_User_Add_RejectSynchronized_BySlaveIDs { get; set; }

    public virtual DbSet<VBF_User_Add_SynchronizedBySlaveID> VBF_User_Add_SynchronizedBySlaveIDs { get; set; }

    public virtual DbSet<VBF_User_Add_UnPivot> VBF_User_Add_UnPivots { get; set; }

    public virtual DbSet<VBF_WorkCalendar> VBF_WorkCalendars { get; set; }

    public virtual DbSet<VBF_WorkCalendar_Advance> VBF_WorkCalendar_Advances { get; set; }

    public virtual DbSet<VBF_WorkCalendar_BAK> VBF_WorkCalendar_BAKs { get; set; }

    public virtual DbSet<VBF_WorkCalendar_BR> VBF_WorkCalendar_BRs { get; set; }

    public virtual DbSet<VBF_WorkShift> VBF_WorkShifts { get; set; }

    public virtual DbSet<VBF_WorkShift_Advance> VBF_WorkShift_Advances { get; set; }

    public virtual DbSet<VCJ_BFX_UserSlaveAddSync_S_SlaveIP> VCJ_BFX_UserSlaveAddSync_S_SlaveIPs { get; set; }

    public virtual DbSet<VCJ_BF_User_S_SlaveIP> VCJ_BF_User_S_SlaveIPs { get; set; }

    public virtual DbSet<VDS_BF_FP_Add_Pivot> VDS_BF_FP_Add_Pivots { get; set; }

    public virtual DbSet<VDS_BF_Holiday_SlaveSID> VDS_BF_Holiday_SlaveSIDs { get; set; }

    public virtual DbSet<VDS_BF_TerminalSetting_Add> VDS_BF_TerminalSetting_Adds { get; set; }

    public virtual DbSet<VDS_BF_TimeSet_SlaveSID> VDS_BF_TimeSet_SlaveSIDs { get; set; }

    public virtual DbSet<VDS_BF_TimeZone_SlaveSID> VDS_BF_TimeZone_SlaveSIDs { get; set; }

    public virtual DbSet<VDS_BF_UserGroup_SlaveSID> VDS_BF_UserGroup_SlaveSIDs { get; set; }

    public virtual DbSet<VDS_BF_User_Add> VDS_BF_User_Adds { get; set; }

    public virtual DbSet<VDS_BF_User_Add_RejectSynchronized_BySlaveSID> VDS_BF_User_Add_RejectSynchronized_BySlaveSIDs { get; set; }

    public virtual DbSet<VDS_BF_User_Del> VDS_BF_User_Dels { get; set; }

    public virtual DbSet<VDS_SlaveIP_UserAndFPCount> VDS_SlaveIP_UserAndFPCounts { get; set; }

    public virtual DbSet<VGB_BFX_UserSlaveAddSync_SlaveID> VGB_BFX_UserSlaveAddSync_SlaveIDs { get; set; }

    public virtual DbSet<VGB_BF_FP_Add_UnPivot_ByCardID> VGB_BF_FP_Add_UnPivot_ByCardIDs { get; set; }

    public virtual DbSet<VGB_BF_FP_Add_UnPivot_BySlaveID> VGB_BF_FP_Add_UnPivot_BySlaveIDs { get; set; }

    public virtual DbSet<VGB_BF_FP_Add_UnPivot_SynchronizedCount> VGB_BF_FP_Add_UnPivot_SynchronizedCounts { get; set; }

    public virtual DbSet<VGB_BF_User_Add_UnPivot_ByCardID> VGB_BF_User_Add_UnPivot_ByCardIDs { get; set; }

    public virtual DbSet<VGB_BF_User_Add_UnPivot_BySlaveID> VGB_BF_User_Add_UnPivot_BySlaveIDs { get; set; }

    public virtual DbSet<VGB_DS_BF_FP_Add_BySlaveSID> VGB_DS_BF_FP_Add_BySlaveSIDs { get; set; }

    public virtual DbSet<VGB_DS_BF_User_Add_BySlaveSID> VGB_DS_BF_User_Add_BySlaveSIDs { get; set; }

    public virtual DbSet<VGB_DS_User_Add_DownloadSettingCount_BySlaveSID> VGB_DS_User_Add_DownloadSettingCount_BySlaveSIDs { get; set; }

    public virtual DbSet<VGB_FP_Add> VGB_FP_Adds { get; set; }

    public virtual DbSet<VGB_JobCode> VGB_JobCodes { get; set; }

    public virtual DbSet<VGB_LeaveApplication_Justification_SubPaidLeaveMinute> VGB_LeaveApplication_Justification_SubPaidLeaveMinutes { get; set; }

    public virtual DbSet<VGB_LeaveApplication_Justification_SubUnPaidLeaveMinute> VGB_LeaveApplication_Justification_SubUnPaidLeaveMinutes { get; set; }

    public virtual DbSet<VGB_Transaction> VGB_Transactions { get; set; }

    public virtual DbSet<VGB_Transactions_DailyMinMaxTranDateTime> VGB_Transactions_DailyMinMaxTranDateTimes { get; set; }

    public virtual DbSet<VGB_Transactions_UWS_2nd> VGB_Transactions_UWS_2nds { get; set; }

    public virtual DbSet<VGB_Transactions_WorkCalendar> VGB_Transactions_WorkCalendars { get; set; }

    public virtual DbSet<VGB_Transactions_WorkCalendar_StartDateTime_AllowWorkEarlyMinute> VGB_Transactions_WorkCalendar_StartDateTime_AllowWorkEarlyMinutes { get; set; }

    public virtual DbSet<VGB_Transactions_WorkCalendar_StartDateTime_TolerateLateMinute> VGB_Transactions_WorkCalendar_StartDateTime_TolerateLateMinutes { get; set; }

    public virtual DbSet<VGB_Transactions_WorkCalendar_WorkEndDateTime_ForceSignOutAfterWorkOffMinute> VGB_Transactions_WorkCalendar_WorkEndDateTime_ForceSignOutAfterWorkOffMinutes { get; set; }

    public virtual DbSet<VGB_Transactions_WorkCalendar_bak> VGB_Transactions_WorkCalendar_baks { get; set; }

    public virtual DbSet<VGB_Transactions_WorkShiftNo> VGB_Transactions_WorkShiftNos { get; set; }

    public virtual DbSet<VGB_UserSlaveAllowTime_AllowTime> VGB_UserSlaveAllowTime_AllowTimes { get; set; }

    public virtual DbSet<VGB_User_Add> VGB_User_Adds { get; set; }

    public virtual DbSet<VGB_User_Add_DownloadSettingCount_BySlaveID> VGB_User_Add_DownloadSettingCount_BySlaveIDs { get; set; }

    public virtual DbSet<VGB_User_AllowTime> VGB_User_AllowTimes { get; set; }

    public virtual DbSet<VJN_BFX_UserSlaveAddSync_BF_User> VJN_BFX_UserSlaveAddSync_BF_Users { get; set; }

    public virtual DbSet<VJN_BFX_UserSlaveAddSync_SlaveIP> VJN_BFX_UserSlaveAddSync_SlaveIPs { get; set; }

    public virtual DbSet<VJN_LeaveApplication_Justification> VJN_LeaveApplication_Justifications { get; set; }

    public virtual DbSet<VJN_Transaction_Depart_User_JobCode> VJN_Transaction_Depart_User_JobCodes { get; set; }

    public virtual DbSet<VJN_Transaction_UWS_2nd> VJN_Transaction_UWS_2nds { get; set; }

    public virtual DbSet<VJN_Transaction_UWS_2nd_GB_ByTranType_End1> VJN_Transaction_UWS_2nd_GB_ByTranType_End1s { get; set; }

    public virtual DbSet<VJN_Transaction_UWS_2nd_GB_ByTranType_End2> VJN_Transaction_UWS_2nd_GB_ByTranType_End2s { get; set; }

    public virtual DbSet<VJN_Transaction_UWS_2nd_GB_ByTranType_Start1> VJN_Transaction_UWS_2nd_GB_ByTranType_Start1s { get; set; }

    public virtual DbSet<VJN_Transaction_UWS_2nd_GB_ByTranType_Start2> VJN_Transaction_UWS_2nd_GB_ByTranType_Start2s { get; set; }

    public virtual DbSet<VJN_Transaction_UWS_2nd_GB_End1> VJN_Transaction_UWS_2nd_GB_End1s { get; set; }

    public virtual DbSet<VJN_Transaction_UWS_2nd_GB_End2> VJN_Transaction_UWS_2nd_GB_End2s { get; set; }

    public virtual DbSet<VJN_Transaction_UWS_2nd_GB_Start1> VJN_Transaction_UWS_2nd_GB_Start1s { get; set; }

    public virtual DbSet<VJN_Transaction_UWS_2nd_GB_Start2> VJN_Transaction_UWS_2nd_GB_Start2s { get; set; }

    public virtual DbSet<VJN_Transaction_User> VJN_Transaction_Users { get; set; }

    public virtual DbSet<VJN_Transaction_WorkCalendar> VJN_Transaction_WorkCalendars { get; set; }

    public virtual DbSet<VJN_Transactions_DailyMinMaxTranDateTime_WorkingStdTime> VJN_Transactions_DailyMinMaxTranDateTime_WorkingStdTimes { get; set; }

    public virtual DbSet<VJN_Transactions_UW> VJN_Transactions_UWs { get; set; }

    public virtual DbSet<VJN_Transactions_UWS_CrossNightLastDay> VJN_Transactions_UWS_CrossNightLastDays { get; set; }

    public virtual DbSet<VJN_Transactions_WorkCalendar_Advance> VJN_Transactions_WorkCalendar_Advances { get; set; }

    public virtual DbSet<VJN_Transactions_WorkShiftNo> VJN_Transactions_WorkShiftNos { get; set; }

    public virtual DbSet<VJN_User_UserWeeklyShift_WorkShift> VJN_User_UserWeeklyShift_WorkShifts { get; set; }

    public virtual DbSet<VJN_VGB_Transaction_WorkCalendar> VJN_VGB_Transaction_WorkCalendars { get; set; }

    public virtual DbSet<VJN_VGB_Transactions_UWS_2nd> VJN_VGB_Transactions_UWS_2nds { get; set; }

    public virtual DbSet<VJN_WorkCalendar_Advance_DateColumnWeekdayNo> VJN_WorkCalendar_Advance_DateColumnWeekdayNos { get; set; }

    public virtual DbSet<VMT_Attendance> VMT_Attendances { get; set; }

    public virtual DbSet<VMT_Attendance_GroupByTranTimeOffset> VMT_Attendance_GroupByTranTimeOffsets { get; set; }

    public virtual DbSet<VMT_Attendance_UWS_2nd> VMT_Attendance_UWS_2nds { get; set; }

    public virtual DbSet<VMT_Attendance_WorkShiftNo> VMT_Attendance_WorkShiftNos { get; set; }

    public virtual DbSet<VOR_LeaveApplication_Head> VOR_LeaveApplication_Heads { get; set; }

    public virtual DbSet<VOR_LeaveApplication_Justification> VOR_LeaveApplication_Justifications { get; set; }

    public virtual DbSet<VOR_Transaction> VOR_Transactions { get; set; }

    public virtual DbSet<VOR_Transactions_Bak> VOR_Transactions_Baks { get; set; }

    public virtual DbSet<VOR_Transactions_Public_Internal> VOR_Transactions_Public_Internals { get; set; }

    public virtual DbSet<VOR_Transactions_RowNumber_TranDateTime_DESC> VOR_Transactions_RowNumber_TranDateTime_DESCs { get; set; }

    public virtual DbSet<VOR_Transactions_RowNumber_TranDateTime_DESC_First> VOR_Transactions_RowNumber_TranDateTime_DESC_Firsts { get; set; }

    public virtual DbSet<VOR_Transactions_SlaveIP> VOR_Transactions_SlaveIPs { get; set; }

    public virtual DbSet<VOR_Transactions_SlaveIP_Internal> VOR_Transactions_SlaveIP_Internals { get; set; }

    public virtual DbSet<VOR_Transactions_SlaveIP_Public> VOR_Transactions_SlaveIP_Publics { get; set; }

    public virtual DbSet<VREL_LeaveApplication_Justification> VREL_LeaveApplication_Justifications { get; set; }

    public virtual DbSet<VRP_Attendance> VRP_Attendances { get; set; }

    public virtual DbSet<VRP_Attendance_UWS_2nd> VRP_Attendance_UWS_2nds { get; set; }

    public virtual DbSet<VRP_Attendance_WorkCalendar> VRP_Attendance_WorkCalendars { get; set; }

    public virtual DbSet<VRP_Attendance_WorkShiftNo> VRP_Attendance_WorkShiftNos { get; set; }

    public virtual DbSet<VRP_FP_Add> VRP_FP_Adds { get; set; }

    public virtual DbSet<VRP_MonthlyAttendanceAnalysisReport_UWM> VRP_MonthlyAttendanceAnalysisReport_UWMs { get; set; }

    public virtual DbSet<VRP_Template_AllowTime> VRP_Template_AllowTimes { get; set; }

    public virtual DbSet<VRP_Transactions_EmployeeInOutStatus> VRP_Transactions_EmployeeInOutStatuses { get; set; }

    public virtual DbSet<VRP_User_Add> VRP_User_Adds { get; set; }

    public virtual DbSet<VS_DateColumnWeekdayNo_User> VS_DateColumnWeekdayNo_Users { get; set; }

    public virtual DbSet<VS_DayTimeTable> VS_DayTimeTables { get; set; }

    public virtual DbSet<VS_MonthlyCalendar> VS_MonthlyCalendars { get; set; }

    public virtual DbSet<VS_Notification_Receipient> VS_Notification_Receipients { get; set; }

    public virtual DbSet<VS_SlaveEventLog> VS_SlaveEventLogs { get; set; }

    public virtual DbSet<VS_SlaveEventLog_Queue> VS_SlaveEventLog_Queues { get; set; }

    public virtual DbSet<VS_SlaveIP> VS_SlaveIPs { get; set; }

    public virtual DbSet<VS_SlaveIP_UserAndFPCount> VS_SlaveIP_UserAndFPCounts { get; set; }

    public virtual DbSet<VTMP_UserDailyAttendanceScale_GroupByDay> VTMP_UserDailyAttendanceScale_GroupByDays { get; set; }

    public virtual DbSet<VTMP_UserDailyAttendanceScale_GroupByMonth> VTMP_UserDailyAttendanceScale_GroupByMonths { get; set; }

    public virtual DbSet<VTMP_UserDailyAttendanceScale_GroupByYear> VTMP_UserDailyAttendanceScale_GroupByYears { get; set; }

    public virtual DbSet<VUN_SupervisorUser> VUN_SupervisorUsers { get; set; }

    public virtual DbSet<VUN_UserSlaveAllowTime_User_AllowTime> VUN_UserSlaveAllowTime_User_AllowTimes { get; set; }

    public virtual DbSet<VUP_FP_Add> VUP_FP_Adds { get; set; }

    public virtual DbSet<VUP_User_Add> VUP_User_Adds { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=LOCALHOST\\MSSQLSERVER2012;Initial Catalog=KATES;Persist Security Info=True;Integrated Security=True;TrustServerCertificate=true;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BC_AttendanceStatus>(entity =>
        {
            entity.Property(e => e.ColorHtml).IsFixedLength();
        });

        modelBuilder.Entity<BC_LeaveType>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BFX_UserSlaveAddSync>(entity =>
        {
            entity.HasKey(e => new { e.UserSID, e.SlaveSID }).HasName("PK_BFX_UserSlaveAddSync_1");

            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.UserS).WithMany(p => p.BFX_UserSlaveAddSyncs).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<BFX_UserSlaveAllowTime>(entity =>
        {
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserSATID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<BF_Contact>(entity =>
        {
            entity.Property(e => e.ContactName).HasDefaultValue("");
        });

        modelBuilder.Entity<BF_Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentID).HasName("BF_Department_PK");

            entity.Property(e => e.DepartmentSID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<BF_FP>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BF_FP_Add>(entity =>
        {
            entity.Property(e => e.FPAddID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<BF_FP_Del>(entity =>
        {
            entity.Property(e => e.FPDelID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<BF_GlobalHolidaySetting_Detail>(entity =>
        {
            entity.HasOne(d => d.GlobalHolidayS).WithMany(p => p.BF_GlobalHolidaySetting_Details)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BF_GlobalHolidaySetting_Detail_BF_GlobalHolidaySetting_Head");
        });

        modelBuilder.Entity<BF_GlobalHolidaySetting_Head>(entity =>
        {
            entity.Property(e => e.Description).HasDefaultValue("");
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BF_Holiday>(entity =>
        {
            entity.Property(e => e.DoorHoliID).ValueGeneratedNever();
            entity.Property(e => e.DoorID).HasDefaultValue((byte)1);
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TimeModifyLast).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BF_HourlyPay>(entity =>
        {
            entity.HasKey(e => e.HourlyPayID).HasName("PK_BF_Pay");

            entity.Property(e => e.Note).HasDefaultValue("");
        });

        modelBuilder.Entity<BF_JobCode>(entity =>
        {
            entity.Property(e => e.JobName).HasDefaultValue("");
        });

        modelBuilder.Entity<BF_Supervisor>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TimeModifyLast).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserPermissionTypeID).HasDefaultValue((byte)29);
        });

        modelBuilder.Entity<BF_TerminalSetting>(entity =>
        {
            entity.Property(e => e.SettingID).HasDefaultValue((byte)1);
            entity.Property(e => e.FPManagePWD).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserAddNewSID).HasDefaultValue(1);
        });

        modelBuilder.Entity<BF_TimeSet>(entity =>
        {
            entity.HasKey(e => new { e.DoorID, e.TimeSetID }).HasName("PK_BF_TimeSet_1");

            entity.Property(e => e.DoorID).HasDefaultValue((byte)1);
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserAddNewSID).HasDefaultValue(1);
        });

        modelBuilder.Entity<BF_TimeZone>(entity =>
        {
            entity.Property(e => e.DoorID).HasDefaultValue((byte)1);
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BF_User>(entity =>
        {
            entity.HasKey(e => e.UserSID).HasName("BF_User_PK");

            entity.Property(e => e.AllowTimeEndHour).HasDefaultValue((byte)23);
            entity.Property(e => e.AllowTimeEndMinute).HasDefaultValue((byte)59);
            entity.Property(e => e.FingerPrint1).HasDefaultValue(10000);
            entity.Property(e => e.FingerPrint2).HasDefaultValue(10000);
            entity.Property(e => e.GroupSID).HasDefaultValue((short)0);
            entity.Property(e => e.HeadShotFileName).HasDefaultValue("");
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserAddNewSID).HasDefaultValue(0);
            entity.Property(e => e.UserPWD).HasDefaultValue("888888");
            entity.Property(e => e.UserPermissionTypeID).HasDefaultValue((byte)10);
            entity.Property(e => e.UserPin)
                .HasDefaultValue("888888")
                .IsFixedLength();
            entity.Property(e => e.ValidDate)
                .HasDefaultValue("991212")
                .IsFixedLength();

            entity.HasOne(d => d.Department).WithMany(p => p.BF_Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BF_User_BF_Department");
        });

        modelBuilder.Entity<BF_UserGroup>(entity =>
        {
            entity.Property(e => e.DoorID).HasDefaultValue((byte)1);
            entity.Property(e => e.Description).HasDefaultValue("");
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BF_UserGroupSetting>(entity =>
        {
            entity.Property(e => e.UserSID).ValueGeneratedNever();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BF_UserHourlyPay>(entity =>
        {
            entity.Property(e => e.Note).HasDefaultValue("");
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TimeModifyLast).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.HourlyPay).WithMany(p => p.BF_UserHourlyPays).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.UserS).WithMany(p => p.BF_UserHourlyPays)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BF_UserHourlyPay_BF_HourlyPay_UserSID");
        });

        modelBuilder.Entity<BF_UserWeeklyShift>(entity =>
        {
            entity.HasKey(e => new { e.UserSID, e.WeekdayNo }).HasName("BF_UserWeeklyShift_PK");

            entity.HasOne(d => d.UserS).WithMany(p => p.BF_UserWeeklyShifts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BF_UserWeeklyShift_BF_User");
        });

        modelBuilder.Entity<BF_User_Add>(entity =>
        {
            entity.Property(e => e.UserAddID).ValueGeneratedOnAdd();
            entity.Property(e => e.AllowTimeEndHour).HasDefaultValue((byte)23);
            entity.Property(e => e.AllowTimeEndMinute).HasDefaultValue((byte)59);
            entity.Property(e => e.AllowTimeStartHour).HasDefaultValue((byte)0);
            entity.Property(e => e.AllowTimeStartMinute).HasDefaultValue((byte)0);
            entity.Property(e => e.FingerPrint1).HasDefaultValue(10000);
            entity.Property(e => e.FingerPrint2).HasDefaultValue(10000);
            entity.Property(e => e.UserPin).IsFixedLength();
            entity.Property(e => e.ValidDate).IsFixedLength();
        });

        modelBuilder.Entity<BF_User_Del>(entity =>
        {
            entity.Property(e => e.UserDelID).ValueGeneratedOnAdd();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BF_WorkCalendar>(entity =>
        {
            entity.Property(e => e.ComputedAttendanceScale).HasComment("經過查詢計算後所得之第一個吻合該時段（出）的刷卡紀錄");
            entity.Property(e => e.ComputedTranInSID).HasComment("經過查詢計算後所得之第一個吻合該時段（進）的刷卡紀錄");
            entity.Property(e => e.ComputedTranOutSID).HasComment("經過查詢計算後所得之第一個吻合該時段（出）的刷卡紀錄");
            entity.Property(e => e.IsComputed).HasComment("該筆資料列的相關計算欄位（Computed）是否已計算完成");
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.WeekdayName).HasDefaultValue("");
            entity.Property(e => e.WorkDate).HasDefaultValue(new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            entity.Property(e => e.WorkEndDateTime).HasDefaultValue(new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            entity.Property(e => e.WorkStartDateTime).HasDefaultValue(new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        });

        modelBuilder.Entity<BF_WorkShift>(entity =>
        {
            entity.Property(e => e.AllowWorkEarlyMinute).HasComment("允許早到時間，若早於此時間則不計入");
            entity.Property(e => e.BreakEndTimeHour).HasDefaultValue((byte)13);
            entity.Property(e => e.BreakEndTimeHour_System).HasDefaultValue((byte)13);
            entity.Property(e => e.BreakStartTimeHour).HasDefaultValue((byte)12);
            entity.Property(e => e.BreakStartTimeHour_System).HasDefaultValue((byte)12);
            entity.Property(e => e.ForceSignOutAfterWorkOffMinute).HasComment("要求在下班時間後的一定區間內要刷退，否則不計入合法刷卡");
            entity.Property(e => e.IsIgnoreSignOut).HasComment("此類班別是否不要求刷下班卡（該WorkShift僅要求一次刷卡）");
            entity.Property(e => e.WeightValue).HasComment("比重值／加權計量值（用於不同應用程式、不同規則計算中使用）");
        });

        modelBuilder.Entity<CF_TransactionImportDetail>(entity =>
        {
            entity.Property(e => e.CardID).IsFixedLength();
            entity.Property(e => e.DeviceID).IsFixedLength();
            entity.Property(e => e.TranDateTimeNo).IsFixedLength();

            entity.HasOne(d => d.ImportOperationNoNavigation).WithMany(p => p.CF_TransactionImportDetails).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CF_TransactionImportHead>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<CF_UserImportDetail>(entity =>
        {
            entity.HasOne(d => d.ImportOperationNoNavigation).WithMany(p => p.CF_UserImportDetails).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CF_UserImportHead>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DS_BF_FP_Add>(entity =>
        {
            entity.Property(e => e.FPAddSID).ValueGeneratedOnAdd();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DS_BF_FP_Del>(entity =>
        {
            entity.Property(e => e.FPDelSID).ValueGeneratedOnAdd();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserAddNewSID).HasDefaultValue(0);
        });

        modelBuilder.Entity<DS_BF_Holiday>(entity =>
        {
            entity.HasKey(e => new { e.DoorID, e.DoorHoliID }).HasName("PK_DS_BF_Holiday_1");

            entity.Property(e => e.DoorID).HasDefaultValue((byte)1);
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DS_BF_Holiday_SlaveSID>(entity =>
        {
            entity.HasKey(e => new { e.DoorID, e.DoorHoliID, e.SlaveSID }).HasName("PK_DS_BF_Holiday_SlaveSID_1");

            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DS_BF_TerminalSetting_Add>(entity =>
        {
            entity.Property(e => e.SlaveSID).ValueGeneratedNever();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DS_BF_TimeSet>(entity =>
        {
            entity.Property(e => e.DoorID).HasDefaultValue((byte)1);
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DS_BF_TimeSet_SlaveSID>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DS_BF_TimeZone>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DS_BF_TimeZone_SlaveSID>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DS_BF_UserGroup>(entity =>
        {
            entity.HasKey(e => new { e.DoorID, e.GroupID }).HasName("PK_DS_BF_UserGroup_1");

            entity.Property(e => e.DoorID).HasDefaultValue((byte)1);
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DS_BF_UserGroup_SlaveSID>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DS_BF_User_Add>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DS_BF_User_Del>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_ChangeCardID>(entity =>
        {
            entity.Property(e => e.ClientIP).HasDefaultValue("");
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_GlobleAPB>(entity =>
        {
            entity.HasKey(e => e.CardID).HasName("PK_OR_GlobleAPB_CardID");
        });

        modelBuilder.Entity<OR_LeaveApplication_Detail>(entity =>
        {
            entity.Property(e => e.IsJustificationLeave).HasComment("will above zero if it's enable");
            entity.Property(e => e.Reason).HasDefaultValue("");
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_LeaveApplication_Head>(entity =>
        {
            entity.Property(e => e.Reason).HasDefaultValue("");
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_Transaction>(entity =>
        {
            entity.HasKey(e => e.TranSID).HasName("PK_Transactions");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("TG_OR_Transactions_InsertOriginal");
                    tb.HasTrigger("TG_OR_Transactions_InsertWeekdayNo");
                });

            entity.Property(e => e.Note).HasDefaultValue("");
            entity.Property(e => e.Original_CardID).HasDefaultValue("");
            entity.Property(e => e.Original_TranDateTime).HasDefaultValueSql("('')");
            entity.Property(e => e.Original_TranType).HasDefaultValue((byte)0);
            entity.Property(e => e.SlaveIP).HasDefaultValue("");
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_UserDataUploadedStack>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<SBC_UserPermissionType>(entity =>
        {
            entity.Property(e => e.UserPermissionTypeID).ValueGeneratedNever();
        });

        modelBuilder.Entity<S_Controller>(entity =>
        {
            entity.HasKey(e => e.IP).HasName("S_Controller_PK");

            entity.Property(e => e.Version).HasDefaultValue("0");
        });

        modelBuilder.Entity<S_DayTimeTable>(entity =>
        {
            entity.HasKey(e => new { e.HourValue, e.MinuteValue }).HasName("PK_S_DayTime");
        });

        modelBuilder.Entity<S_Notification>(entity =>
        {
            entity.Property(e => e.Description).HasDefaultValue("");
            entity.Property(e => e.MailSubject).HasDefaultValue("");
        });

        modelBuilder.Entity<S_Notification_Log>(entity =>
        {
            entity.Property(e => e.IsHTML).HasDefaultValue(true);
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<S_Notification_Log_Recipient>(entity =>
        {
            entity.HasKey(e => new { e.LogSID, e.UserSID }).HasName("PK_S_Notification_Log_Receipient");
        });

        modelBuilder.Entity<S_SlaveEventLog>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<S_SlaveIP>(entity =>
        {
            entity.HasKey(e => e.SlaveSID).HasName("S_SlaveIP_PK");

            entity.Property(e => e.SlaveSID).ValueGeneratedNever();
            entity.Property(e => e.SlaveDescription).HasDefaultValue("");
            entity.Property(e => e.SlaveName).HasDefaultValue("");
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.SlaveCategory).WithMany(p => p.S_SlaveIPs).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<S_SlaveStatusDefinition>(entity =>
        {
            entity.Property(e => e.StatusCode).ValueGeneratedNever();
        });

        modelBuilder.Entity<S_SystemSetting>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK_S_SystemSetting_1");

            entity.Property(e => e.DateFormatArgument).HasDefaultValue("YYYY/MM/DD");
            entity.Property(e => e.DisableSyncExceptSlave).HasDefaultValue(0);
            entity.Property(e => e.EnableDataSync2).HasDefaultValue(true);
            entity.Property(e => e.EnableSelectOnlyOnPostBack).HasDefaultValue(true);
            entity.Property(e => e.FieldLengthsOfCardID).HasDefaultValue((byte)10);
            entity.Property(e => e.TimeFormatArgument).HasDefaultValue("HH:MM");
        });

        modelBuilder.Entity<S_SystemSetting_SMTP>(entity =>
        {
            entity.Property(e => e.CharacterSet).HasDefaultValue("UTF-8");
            entity.Property(e => e.IsDefault).HasDefaultValue(true);
            entity.Property(e => e.IsHTML).HasDefaultValue(true);
            entity.Property(e => e.MailServerPort).HasDefaultValue((short)25);
            entity.Property(e => e.MaxIdleTime).HasDefaultValue((short)60);
            entity.Property(e => e.NewLineCharacter).HasDefaultValue("\\r\\n");
        });

        modelBuilder.Entity<S_SystemUpdateLog>(entity =>
        {
            entity.Property(e => e.ReleaseDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<S_TreeviewMenu>(entity =>
        {
            entity.HasKey(e => e.NodeValue).HasName("PK_S_TreeviewMenu_1");

            entity.Property(e => e.NodeText_cn).HasDefaultValue("");
            entity.Property(e => e.NodeText_ko).HasDefaultValue("");
            entity.Property(e => e.NodeText_tw).HasDefaultValue("");
            entity.Property(e => e.ToolTip_cn).HasDefaultValue("");
            entity.Property(e => e.ToolTip_en).HasDefaultValue("");
            entity.Property(e => e.ToolTip_ko).HasDefaultValue("");
            entity.Property(e => e.ToolTip_tw).HasDefaultValue("");
        });

        modelBuilder.Entity<S_TreeviewMenu_User>(entity =>
        {
            entity.Property(e => e.NodeValue).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<S_WiFi>(entity =>
        {
            entity.HasKey(e => e.SSID).HasName("S_WiFi_PK");
        });

        modelBuilder.Entity<TMP_AttendanceReportMetaDatum>(entity =>
        {
            entity.Property(e => e.ShiftCode).HasDefaultValue("");
            entity.Property(e => e.DepartmentID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.WorkingTimeNormal).HasDefaultValue(0);
        });

        modelBuilder.Entity<TMP_BF_Contact_1116>(entity =>
        {
            entity.Property(e => e.ContactType).HasDefaultValue(0);
        });

        modelBuilder.Entity<TMP_BF_User_196>(entity =>
        {
            entity.Property(e => e.AllowTimeEndHour).HasDefaultValueSql("((23))");
            entity.Property(e => e.AllowTimeEndMinute).HasDefaultValueSql("((59))");
            entity.Property(e => e.AllowTimeStartHour).HasDefaultValueSql("((0))");
            entity.Property(e => e.AllowTimeStartMinute).HasDefaultValueSql("((0))");
            entity.Property(e => e.ValidDate).HasDefaultValue("991212");
        });

        modelBuilder.Entity<TMP_GlobalHolidaySetting_Head_1116>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TMP_MonthlyColumnDataSheet>(entity =>
        {
            entity.Property(e => e.ActualAttendencePercent).HasDefaultValue(0.0);
            entity.Property(e => e.Day01).HasDefaultValue(0);
            entity.Property(e => e.Day02).HasDefaultValue(0);
            entity.Property(e => e.Day03).HasDefaultValue(0);
            entity.Property(e => e.Day04).HasDefaultValue(0);
            entity.Property(e => e.Day05).HasDefaultValue(0);
            entity.Property(e => e.Day06).HasDefaultValue(0);
            entity.Property(e => e.Day07).HasDefaultValue(0);
            entity.Property(e => e.Day08).HasDefaultValue(0);
            entity.Property(e => e.Day09).HasDefaultValue(0);
            entity.Property(e => e.Day10).HasDefaultValue(0);
            entity.Property(e => e.Day11).HasDefaultValue(0);
            entity.Property(e => e.Day12).HasDefaultValue(0);
            entity.Property(e => e.Day13).HasDefaultValue(0);
            entity.Property(e => e.Day14).HasDefaultValue(0);
            entity.Property(e => e.Day15).HasDefaultValue(0);
            entity.Property(e => e.Day16).HasDefaultValue(0);
            entity.Property(e => e.Day17).HasDefaultValue(0);
            entity.Property(e => e.Day18).HasDefaultValue(0);
            entity.Property(e => e.Day19).HasDefaultValue(0);
            entity.Property(e => e.Day20).HasDefaultValue(0);
            entity.Property(e => e.Day21).HasDefaultValue(0);
            entity.Property(e => e.Day22).HasDefaultValue(0);
            entity.Property(e => e.Day23).HasDefaultValue(0);
            entity.Property(e => e.Day24).HasDefaultValue(0);
            entity.Property(e => e.Day25).HasDefaultValue(0);
            entity.Property(e => e.Day26).HasDefaultValue(0);
            entity.Property(e => e.DepartmentID).HasDefaultValue("");
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TMP_UserDailyAttendanceScale>(entity =>
        {
            entity.HasKey(e => new { e.AppSID, e.UserSID, e.YearValue, e.MonthValue, e.DayValue, e.ShiftCode, e.WorkShiftNo }).HasName("PK_TMP_UserDailyAttendanceScale_1");

            entity.Property(e => e.ShiftCode).HasDefaultValue("");
            entity.Property(e => e.DepartmentID).HasDefaultValue("");
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TMP_YearlyColumnDataSheet>(entity =>
        {
            entity.Property(e => e.ActualAttendencePercent).HasDefaultValue(0.0);
            entity.Property(e => e.DepartmentID).HasDefaultValue("");
            entity.Property(e => e.Month01).HasDefaultValue(0);
            entity.Property(e => e.Month02).HasDefaultValue(0);
            entity.Property(e => e.Month03).HasDefaultValue(0);
            entity.Property(e => e.Month04).HasDefaultValue(0);
            entity.Property(e => e.Month05).HasDefaultValue(0);
            entity.Property(e => e.Month06).HasDefaultValue(0);
            entity.Property(e => e.Month07).HasDefaultValue(0);
            entity.Property(e => e.Month08).HasDefaultValue(0);
            entity.Property(e => e.Month09).HasDefaultValue(0);
            entity.Property(e => e.Month10).HasDefaultValue(0);
            entity.Property(e => e.Month11).HasDefaultValue(0);
            entity.Property(e => e.Month12).HasDefaultValue(0);
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<VBC_AttendanceStatus>(entity =>
        {
            entity.ToView("VBC_AttendanceStatus");

            entity.Property(e => e.ColorHtml).IsFixedLength();
        });

        modelBuilder.Entity<VBC_EmployeeType>(entity =>
        {
            entity.ToView("VBC_EmployeeType");
        });

        modelBuilder.Entity<VBC_LeaveType>(entity =>
        {
            entity.ToView("VBC_LeaveType");
        });

        modelBuilder.Entity<VBC_SlaveCategory>(entity =>
        {
            entity.ToView("VBC_SlaveCategory");

            entity.Property(e => e.SlaveCategoryID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<VBFX_UserSlaveAllowTime>(entity =>
        {
            entity.ToView("VBFX_UserSlaveAllowTime");
        });

        modelBuilder.Entity<VBF_Contact>(entity =>
        {
            entity.ToView("VBF_Contact");
        });

        modelBuilder.Entity<VBF_Department>(entity =>
        {
            entity.ToView("VBF_Department");
        });

        modelBuilder.Entity<VBF_Division>(entity =>
        {
            entity.ToView("VBF_Division");
        });

        modelBuilder.Entity<VBF_FP_Add_SynchronizedBySlaveID>(entity =>
        {
            entity.ToView("VBF_FP_Add_SynchronizedBySlaveID");
        });

        modelBuilder.Entity<VBF_FP_Add_UnPivot>(entity =>
        {
            entity.ToView("VBF_FP_Add_UnPivot");
        });

        modelBuilder.Entity<VBF_GlobalHolidaySetting_Detail>(entity =>
        {
            entity.ToView("VBF_GlobalHolidaySetting_Detail");
        });

        modelBuilder.Entity<VBF_GlobalHolidaySetting_Head>(entity =>
        {
            entity.ToView("VBF_GlobalHolidaySetting_Head");

            entity.Property(e => e.GlobalHolidaySID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<VBF_HourlyPay>(entity =>
        {
            entity.ToView("VBF_HourlyPay");
        });

        modelBuilder.Entity<VBF_JobCode>(entity =>
        {
            entity.ToView("VBF_JobCode");
        });

        modelBuilder.Entity<VBF_Supervisor>(entity =>
        {
            entity.ToView("VBF_Supervisor");
        });

        modelBuilder.Entity<VBF_TimeSet>(entity =>
        {
            entity.ToView("VBF_TimeSet");
        });

        modelBuilder.Entity<VBF_User>(entity =>
        {
            entity.ToView("VBF_User");

            entity.Property(e => e.UserPin).IsFixedLength();
            entity.Property(e => e.ValidDate).IsFixedLength();
        });

        modelBuilder.Entity<VBF_UserGroupSetting>(entity =>
        {
            entity.ToView("VBF_UserGroupSetting");
        });

        modelBuilder.Entity<VBF_UserHourlyPay>(entity =>
        {
            entity.ToView("VBF_UserHourlyPay");

            entity.Property(e => e.EndDate_101).IsFixedLength();
            entity.Property(e => e.StartDate_101).IsFixedLength();
        });

        modelBuilder.Entity<VBF_UserWeeklyShift>(entity =>
        {
            entity.ToView("VBF_UserWeeklyShift");
        });

        modelBuilder.Entity<VBF_UserWeeklyShift_2nd>(entity =>
        {
            entity.ToView("VBF_UserWeeklyShift_2nd");
        });

        modelBuilder.Entity<VBF_User_Add_RejectSynchronized_BySlaveID>(entity =>
        {
            entity.ToView("VBF_User_Add_RejectSynchronized_BySlaveID");
        });

        modelBuilder.Entity<VBF_User_Add_SynchronizedBySlaveID>(entity =>
        {
            entity.ToView("VBF_User_Add_SynchronizedBySlaveID");
        });

        modelBuilder.Entity<VBF_User_Add_UnPivot>(entity =>
        {
            entity.ToView("VBF_User_Add_UnPivot");
        });

        modelBuilder.Entity<VBF_WorkCalendar>(entity =>
        {
            entity.ToView("VBF_WorkCalendar");
        });

        modelBuilder.Entity<VBF_WorkCalendar_Advance>(entity =>
        {
            entity.ToView("VBF_WorkCalendar_Advance");
        });

        modelBuilder.Entity<VBF_WorkCalendar_BAK>(entity =>
        {
            entity.ToView("VBF_WorkCalendar_BAK");

            entity.Property(e => e.CardID).IsFixedLength();
        });

        modelBuilder.Entity<VBF_WorkCalendar_BR>(entity =>
        {
            entity.ToView("VBF_WorkCalendar_BR");
        });

        modelBuilder.Entity<VBF_WorkShift>(entity =>
        {
            entity.ToView("VBF_WorkShift");
        });

        modelBuilder.Entity<VBF_WorkShift_Advance>(entity =>
        {
            entity.ToView("VBF_WorkShift_Advance");
        });

        modelBuilder.Entity<VCJ_BFX_UserSlaveAddSync_S_SlaveIP>(entity =>
        {
            entity.ToView("VCJ_BFX_UserSlaveAddSync_S_SlaveIP");
        });

        modelBuilder.Entity<VCJ_BF_User_S_SlaveIP>(entity =>
        {
            entity.ToView("VCJ_BF_User_S_SlaveIP");
        });

        modelBuilder.Entity<VDS_BF_FP_Add_Pivot>(entity =>
        {
            entity.ToView("VDS_BF_FP_Add_Pivot");
        });

        modelBuilder.Entity<VDS_BF_Holiday_SlaveSID>(entity =>
        {
            entity.ToView("VDS_BF_Holiday_SlaveSID");
        });

        modelBuilder.Entity<VDS_BF_TerminalSetting_Add>(entity =>
        {
            entity.ToView("VDS_BF_TerminalSetting_Add");

            entity.Property(e => e.FPManagePWD).IsFixedLength();
        });

        modelBuilder.Entity<VDS_BF_TimeSet_SlaveSID>(entity =>
        {
            entity.ToView("VDS_BF_TimeSet_SlaveSID");
        });

        modelBuilder.Entity<VDS_BF_TimeZone_SlaveSID>(entity =>
        {
            entity.ToView("VDS_BF_TimeZone_SlaveSID");
        });

        modelBuilder.Entity<VDS_BF_UserGroup_SlaveSID>(entity =>
        {
            entity.ToView("VDS_BF_UserGroup_SlaveSID");
        });

        modelBuilder.Entity<VDS_BF_User_Add>(entity =>
        {
            entity.ToView("VDS_BF_User_Add");

            entity.Property(e => e.UserPin).IsFixedLength();
            entity.Property(e => e.ValidDate).IsFixedLength();
        });

        modelBuilder.Entity<VDS_BF_User_Add_RejectSynchronized_BySlaveSID>(entity =>
        {
            entity.ToView("VDS_BF_User_Add_RejectSynchronized_BySlaveSID");
        });

        modelBuilder.Entity<VDS_BF_User_Del>(entity =>
        {
            entity.ToView("VDS_BF_User_Del");
        });

        modelBuilder.Entity<VDS_SlaveIP_UserAndFPCount>(entity =>
        {
            entity.ToView("VDS_SlaveIP_UserAndFPCounts");
        });

        modelBuilder.Entity<VGB_BFX_UserSlaveAddSync_SlaveID>(entity =>
        {
            entity.ToView("VGB_BFX_UserSlaveAddSync_SlaveID");
        });

        modelBuilder.Entity<VGB_BF_FP_Add_UnPivot_ByCardID>(entity =>
        {
            entity.ToView("VGB_BF_FP_Add_UnPivot_ByCardID");
        });

        modelBuilder.Entity<VGB_BF_FP_Add_UnPivot_BySlaveID>(entity =>
        {
            entity.ToView("VGB_BF_FP_Add_UnPivot_BySlaveID");
        });

        modelBuilder.Entity<VGB_BF_FP_Add_UnPivot_SynchronizedCount>(entity =>
        {
            entity.ToView("VGB_BF_FP_Add_UnPivot_SynchronizedCounts");
        });

        modelBuilder.Entity<VGB_BF_User_Add_UnPivot_ByCardID>(entity =>
        {
            entity.ToView("VGB_BF_User_Add_UnPivot_ByCardID");
        });

        modelBuilder.Entity<VGB_BF_User_Add_UnPivot_BySlaveID>(entity =>
        {
            entity.ToView("VGB_BF_User_Add_UnPivot_BySlaveID");
        });

        modelBuilder.Entity<VGB_DS_BF_FP_Add_BySlaveSID>(entity =>
        {
            entity.ToView("VGB_DS_BF_FP_Add_BySlaveSID");
        });

        modelBuilder.Entity<VGB_DS_BF_User_Add_BySlaveSID>(entity =>
        {
            entity.ToView("VGB_DS_BF_User_Add_BySlaveSID");
        });

        modelBuilder.Entity<VGB_DS_User_Add_DownloadSettingCount_BySlaveSID>(entity =>
        {
            entity.ToView("VGB_DS_User_Add_DownloadSettingCount_BySlaveSID");
        });

        modelBuilder.Entity<VGB_FP_Add>(entity =>
        {
            entity.ToView("VGB_FP_Add");
        });

        modelBuilder.Entity<VGB_JobCode>(entity =>
        {
            entity.ToView("VGB_JobCode");
        });

        modelBuilder.Entity<VGB_LeaveApplication_Justification_SubPaidLeaveMinute>(entity =>
        {
            entity.ToView("VGB_LeaveApplication_Justification_SubPaidLeaveMinute");
        });

        modelBuilder.Entity<VGB_LeaveApplication_Justification_SubUnPaidLeaveMinute>(entity =>
        {
            entity.ToView("VGB_LeaveApplication_Justification_SubUnPaidLeaveMinute");
        });

        modelBuilder.Entity<VGB_Transaction>(entity =>
        {
            entity.ToView("VGB_Transactions");
        });

        modelBuilder.Entity<VGB_Transactions_DailyMinMaxTranDateTime>(entity =>
        {
            entity.ToView("VGB_Transactions_DailyMinMaxTranDateTime");
        });

        modelBuilder.Entity<VGB_Transactions_UWS_2nd>(entity =>
        {
            entity.ToView("VGB_Transactions_UWS_2nd");

            entity.Property(e => e.CardID).IsFixedLength();
        });

        modelBuilder.Entity<VGB_Transactions_WorkCalendar>(entity =>
        {
            entity.ToView("VGB_Transactions_WorkCalendar");
        });

        modelBuilder.Entity<VGB_Transactions_WorkCalendar_StartDateTime_AllowWorkEarlyMinute>(entity =>
        {
            entity.ToView("VGB_Transactions_WorkCalendar_StartDateTime_AllowWorkEarlyMinute");
        });

        modelBuilder.Entity<VGB_Transactions_WorkCalendar_StartDateTime_TolerateLateMinute>(entity =>
        {
            entity.ToView("VGB_Transactions_WorkCalendar_StartDateTime_TolerateLateMinute");
        });

        modelBuilder.Entity<VGB_Transactions_WorkCalendar_WorkEndDateTime_ForceSignOutAfterWorkOffMinute>(entity =>
        {
            entity.ToView("VGB_Transactions_WorkCalendar_WorkEndDateTime_ForceSignOutAfterWorkOffMinute");
        });

        modelBuilder.Entity<VGB_Transactions_WorkCalendar_bak>(entity =>
        {
            entity.ToView("VGB_Transactions_WorkCalendar_bak");
        });

        modelBuilder.Entity<VGB_Transactions_WorkShiftNo>(entity =>
        {
            entity.ToView("VGB_Transactions_WorkShiftNo");
        });

        modelBuilder.Entity<VGB_UserSlaveAllowTime_AllowTime>(entity =>
        {
            entity.ToView("VGB_UserSlaveAllowTime_AllowTime");
        });

        modelBuilder.Entity<VGB_User_Add>(entity =>
        {
            entity.ToView("VGB_User_Add");
        });

        modelBuilder.Entity<VGB_User_Add_DownloadSettingCount_BySlaveID>(entity =>
        {
            entity.ToView("VGB_User_Add_DownloadSettingCount_BySlaveID");
        });

        modelBuilder.Entity<VGB_User_AllowTime>(entity =>
        {
            entity.ToView("VGB_User_AllowTime");
        });

        modelBuilder.Entity<VJN_BFX_UserSlaveAddSync_BF_User>(entity =>
        {
            entity.ToView("VJN_BFX_UserSlaveAddSync_BF_User");
        });

        modelBuilder.Entity<VJN_BFX_UserSlaveAddSync_SlaveIP>(entity =>
        {
            entity.ToView("VJN_BFX_UserSlaveAddSync_SlaveIP");
        });

        modelBuilder.Entity<VJN_LeaveApplication_Justification>(entity =>
        {
            entity.ToView("VJN_LeaveApplication_Justification");
        });

        modelBuilder.Entity<VJN_Transaction_Depart_User_JobCode>(entity =>
        {
            entity.ToView("VJN_Transaction_Depart_User_JobCode");
        });

        modelBuilder.Entity<VJN_Transaction_UWS_2nd>(entity =>
        {
            entity.ToView("VJN_Transaction_UWS_2nd");
        });

        modelBuilder.Entity<VJN_Transaction_UWS_2nd_GB_ByTranType_End1>(entity =>
        {
            entity.ToView("VJN_Transaction_UWS_2nd_GB_ByTranType_End1");
        });

        modelBuilder.Entity<VJN_Transaction_UWS_2nd_GB_ByTranType_End2>(entity =>
        {
            entity.ToView("VJN_Transaction_UWS_2nd_GB_ByTranType_End2");
        });

        modelBuilder.Entity<VJN_Transaction_UWS_2nd_GB_ByTranType_Start1>(entity =>
        {
            entity.ToView("VJN_Transaction_UWS_2nd_GB_ByTranType_Start1");
        });

        modelBuilder.Entity<VJN_Transaction_UWS_2nd_GB_ByTranType_Start2>(entity =>
        {
            entity.ToView("VJN_Transaction_UWS_2nd_GB_ByTranType_Start2");
        });

        modelBuilder.Entity<VJN_Transaction_UWS_2nd_GB_End1>(entity =>
        {
            entity.ToView("VJN_Transaction_UWS_2nd_GB_End1");
        });

        modelBuilder.Entity<VJN_Transaction_UWS_2nd_GB_End2>(entity =>
        {
            entity.ToView("VJN_Transaction_UWS_2nd_GB_End2");
        });

        modelBuilder.Entity<VJN_Transaction_UWS_2nd_GB_Start1>(entity =>
        {
            entity.ToView("VJN_Transaction_UWS_2nd_GB_Start1");
        });

        modelBuilder.Entity<VJN_Transaction_UWS_2nd_GB_Start2>(entity =>
        {
            entity.ToView("VJN_Transaction_UWS_2nd_GB_Start2");
        });

        modelBuilder.Entity<VJN_Transaction_User>(entity =>
        {
            entity.ToView("VJN_Transaction_User");
        });

        modelBuilder.Entity<VJN_Transaction_WorkCalendar>(entity =>
        {
            entity.ToView("VJN_Transaction_WorkCalendar");
        });

        modelBuilder.Entity<VJN_Transactions_DailyMinMaxTranDateTime_WorkingStdTime>(entity =>
        {
            entity.ToView("VJN_Transactions_DailyMinMaxTranDateTime_WorkingStdTime");
        });

        modelBuilder.Entity<VJN_Transactions_UW>(entity =>
        {
            entity.ToView("VJN_Transactions_UWS");
        });

        modelBuilder.Entity<VJN_Transactions_UWS_CrossNightLastDay>(entity =>
        {
            entity.ToView("VJN_Transactions_UWS_CrossNightLastDay");
        });

        modelBuilder.Entity<VJN_Transactions_WorkCalendar_Advance>(entity =>
        {
            entity.ToView("VJN_Transactions_WorkCalendar_Advance");
        });

        modelBuilder.Entity<VJN_Transactions_WorkShiftNo>(entity =>
        {
            entity.ToView("VJN_Transactions_WorkShiftNo");
        });

        modelBuilder.Entity<VJN_User_UserWeeklyShift_WorkShift>(entity =>
        {
            entity.ToView("VJN_User_UserWeeklyShift_WorkShift");
        });

        modelBuilder.Entity<VJN_VGB_Transaction_WorkCalendar>(entity =>
        {
            entity.ToView("VJN_VGB_Transaction_WorkCalendar");
        });

        modelBuilder.Entity<VJN_VGB_Transactions_UWS_2nd>(entity =>
        {
            entity.ToView("VJN_VGB_Transactions_UWS_2nd");

            entity.Property(e => e.CardID).IsFixedLength();
        });

        modelBuilder.Entity<VJN_WorkCalendar_Advance_DateColumnWeekdayNo>(entity =>
        {
            entity.ToView("VJN_WorkCalendar_Advance_DateColumnWeekdayNo");
        });

        modelBuilder.Entity<VMT_Attendance>(entity =>
        {
            entity.ToView("VMT_Attendance");
        });

        modelBuilder.Entity<VMT_Attendance_GroupByTranTimeOffset>(entity =>
        {
            entity.ToView("VMT_Attendance_GroupByTranTimeOffset");
        });

        modelBuilder.Entity<VMT_Attendance_UWS_2nd>(entity =>
        {
            entity.ToView("VMT_Attendance_UWS_2nd");

            entity.Property(e => e.CardID).IsFixedLength();
        });

        modelBuilder.Entity<VMT_Attendance_WorkShiftNo>(entity =>
        {
            entity.ToView("VMT_Attendance_WorkShiftNo");
        });

        modelBuilder.Entity<VOR_LeaveApplication_Head>(entity =>
        {
            entity.ToView("VOR_LeaveApplication_Head");
        });

        modelBuilder.Entity<VOR_LeaveApplication_Justification>(entity =>
        {
            entity.ToView("VOR_LeaveApplication_Justification");
        });

        modelBuilder.Entity<VOR_Transaction>(entity =>
        {
            entity.ToView("VOR_Transactions");
        });

        modelBuilder.Entity<VOR_Transactions_Bak>(entity =>
        {
            entity.ToView("VOR_Transactions_Bak");
        });

        modelBuilder.Entity<VOR_Transactions_Public_Internal>(entity =>
        {
            entity.ToView("VOR_Transactions_Public_Internal");
        });

        modelBuilder.Entity<VOR_Transactions_RowNumber_TranDateTime_DESC>(entity =>
        {
            entity.ToView("VOR_Transactions_RowNumber_TranDateTime_DESC");

            entity.Property(e => e.TranSID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<VOR_Transactions_RowNumber_TranDateTime_DESC_First>(entity =>
        {
            entity.ToView("VOR_Transactions_RowNumber_TranDateTime_DESC_First");

            entity.Property(e => e.TranSID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<VOR_Transactions_SlaveIP>(entity =>
        {
            entity.ToView("VOR_Transactions_SlaveIP");
        });

        modelBuilder.Entity<VOR_Transactions_SlaveIP_Internal>(entity =>
        {
            entity.ToView("VOR_Transactions_SlaveIP_Internal");
        });

        modelBuilder.Entity<VOR_Transactions_SlaveIP_Public>(entity =>
        {
            entity.ToView("VOR_Transactions_SlaveIP_Public");
        });

        modelBuilder.Entity<VREL_LeaveApplication_Justification>(entity =>
        {
            entity.ToView("VREL_LeaveApplication_Justification");
        });

        modelBuilder.Entity<VRP_Attendance>(entity =>
        {
            entity.ToView("VRP_Attendance");
        });

        modelBuilder.Entity<VRP_Attendance_UWS_2nd>(entity =>
        {
            entity.ToView("VRP_Attendance_UWS_2nd");
        });

        modelBuilder.Entity<VRP_Attendance_WorkCalendar>(entity =>
        {
            entity.ToView("VRP_Attendance_WorkCalendar");
        });

        modelBuilder.Entity<VRP_Attendance_WorkShiftNo>(entity =>
        {
            entity.ToView("VRP_Attendance_WorkShiftNo");
        });

        modelBuilder.Entity<VRP_FP_Add>(entity =>
        {
            entity.ToView("VRP_FP_Add");
        });

        modelBuilder.Entity<VRP_MonthlyAttendanceAnalysisReport_UWM>(entity =>
        {
            entity.ToView("VRP_MonthlyAttendanceAnalysisReport_UWM");

            entity.Property(e => e.DepartmentID).IsFixedLength();
        });

        modelBuilder.Entity<VRP_Template_AllowTime>(entity =>
        {
            entity.ToView("VRP_Template_AllowTime");
        });

        modelBuilder.Entity<VRP_Transactions_EmployeeInOutStatus>(entity =>
        {
            entity.ToView("VRP_Transactions_EmployeeInOutStatus");
        });

        modelBuilder.Entity<VRP_User_Add>(entity =>
        {
            entity.ToView("VRP_User_Add");
        });

        modelBuilder.Entity<VS_DateColumnWeekdayNo_User>(entity =>
        {
            entity.ToView("VS_DateColumnWeekdayNo_User");
        });

        modelBuilder.Entity<VS_DayTimeTable>(entity =>
        {
            entity.ToView("VS_DayTimeTable");
        });

        modelBuilder.Entity<VS_MonthlyCalendar>(entity =>
        {
            entity.ToView("VS_MonthlyCalendar");
        });

        modelBuilder.Entity<VS_Notification_Receipient>(entity =>
        {
            entity.ToView("VS_Notification_Receipient");
        });

        modelBuilder.Entity<VS_SlaveEventLog>(entity =>
        {
            entity.ToView("VS_SlaveEventLog");
        });

        modelBuilder.Entity<VS_SlaveEventLog_Queue>(entity =>
        {
            entity.ToView("VS_SlaveEventLog_Queue");
        });

        modelBuilder.Entity<VS_SlaveIP>(entity =>
        {
            entity.ToView("VS_SlaveIP");
        });

        modelBuilder.Entity<VS_SlaveIP_UserAndFPCount>(entity =>
        {
            entity.ToView("VS_SlaveIP_UserAndFPCounts");
        });

        modelBuilder.Entity<VTMP_UserDailyAttendanceScale_GroupByDay>(entity =>
        {
            entity.ToView("VTMP_UserDailyAttendanceScale_GroupByDay");
        });

        modelBuilder.Entity<VTMP_UserDailyAttendanceScale_GroupByMonth>(entity =>
        {
            entity.ToView("VTMP_UserDailyAttendanceScale_GroupByMonth");
        });

        modelBuilder.Entity<VTMP_UserDailyAttendanceScale_GroupByYear>(entity =>
        {
            entity.ToView("VTMP_UserDailyAttendanceScale_GroupByYear");
        });

        modelBuilder.Entity<VUN_SupervisorUser>(entity =>
        {
            entity.ToView("VUN_SupervisorUser");
        });

        modelBuilder.Entity<VUN_UserSlaveAllowTime_User_AllowTime>(entity =>
        {
            entity.ToView("VUN_UserSlaveAllowTime_User_AllowTime");
        });

        modelBuilder.Entity<VUP_FP_Add>(entity =>
        {
            entity.ToView("VUP_FP_Add");

            entity.Property(e => e.CardID).IsFixedLength();
        });

        modelBuilder.Entity<VUP_User_Add>(entity =>
        {
            entity.ToView("VUP_User_Add");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
