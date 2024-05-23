using OmiApplication.Proto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmiApplication.Services.Contract
{
    interface IValueOmiService
    {
        IAsyncEnumerable<OmiValue> RetrieveAllValueOmi();

    }
}
