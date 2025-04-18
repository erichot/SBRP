using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Interfaces
{
    public interface IEntityEditBriefHistory
    {
        short CreatedPerson { get; set; }

        short? UpdatedPerson { get; set; }

        short? DeletedPerson { get; set; }



        DateTime CreatedDate { get; set; }

        DateTime? UpdatedDate { get; set; }

        DateTime? DeletedDate { get; set; }

    }
}
