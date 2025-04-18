using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SBRPLogPsi.Interfaces
{
    internal interface IBasedArchiveModelInterface
    {
        int LogNo { get; set; }
        SBRPLogPsi.LogTypeEnum LogTypeNo { get; set; } 
        int LoginActionNo { get; set; }    
    }
}
