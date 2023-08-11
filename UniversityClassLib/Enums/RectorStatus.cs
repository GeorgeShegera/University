using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public enum RectorStatus
    {
        Active = 1,
        OnLeave,
        ActingRector,
        Retired,
        Resigned,
        ContractExpired,
        Suspended
    }
}
