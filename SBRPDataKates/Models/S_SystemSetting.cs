using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("S_SystemSetting")]
public partial class S_SystemSetting
{
    [Key]
    public byte ID { get; set; }

    public bool EnableSelectOnlyOnPostBack { get; set; }

    public byte FieldLengthsOfCardID { get; set; }

    public bool UserWeeklyShift_Enable2ndWorkShift { get; set; }

    public bool EnableIsTaOrNot { get; set; }

    public bool DisableSyncWhenCreatingUser { get; set; }

    public int? DisableSyncExceptSlave { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string DateFormatArgument { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string TimeFormatArgument { get; set; } = null!;

    public bool DisableCardIdValidationLessThanEqual { get; set; }

    public bool EnableDataSync2 { get; set; }

    public bool EnableWorkShiftDeductBreakByDualTimeRange { get; set; }

    public bool IsForChowFace { get; set; }
}
