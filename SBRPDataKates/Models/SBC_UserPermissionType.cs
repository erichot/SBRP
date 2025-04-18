using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("SBC_UserPermissionType")]
public partial class SBC_UserPermissionType
{
    [Key]
    public short UserPermissionTypeID { get; set; }

    [StringLength(16)]
    public string? UserPermissionTypeName { get; set; }

    [StringLength(16)]
    public string? UserPermissionTypeName_CN { get; set; }

    [StringLength(16)]
    public string? UserPermissionTypeName_TW { get; set; }
}
