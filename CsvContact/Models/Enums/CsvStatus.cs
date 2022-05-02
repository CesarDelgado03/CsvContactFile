using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsvContact.Models.Enums
{
    public enum CsvStatus
    {
        OnHold = 1,
        Processing = 2,
        Failed = 3,
        Finished = 4
    }
}
