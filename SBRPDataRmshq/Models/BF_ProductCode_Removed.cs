using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
[Table("BF_ProductCode_Removed")]
public partial class BF_ProductCode_Removed
{
    public int SerialNo { get; set; }

    public int SectionNo { get; set; }

    public int SectionSerialNo { get; set; }

    [StringLength(50)]
    public string CustomCode { get; set; } = null!;
}
