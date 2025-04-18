using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 其實拿到的SIGNo，最後是在Query DbContext才會用到，整體來看，過程都只是過路，讓前端HttpRequest pass SIGNo依序往後端傳遞
    /// </remarks>
    interface ISystemIsolationGroupInterface
    {
        void SetSIG(byte _sIGNo);
    }
}
