using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("S_PreCalculation")]
public partial class S_PreCalculation
{
    [Key]
    public int PreCalculationSID { get; set; }

    public int ReplicatedSID { get; set; }

    public int TotalRowCount { get; set; }

    public DateTime TimeBeginPreCalculate { get; set; }

    public DateTime? TimeEndPreCalculate { get; set; }

    public Guid? ProductSelectedGID { get; set; }

    [StringLength(32)]
    public string UserAddNewID { get; set; } = null!;
}
