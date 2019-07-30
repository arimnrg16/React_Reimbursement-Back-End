using System.Collections.Generic;
using Reimburses.Data.Entities;

namespace Reimburses.ViewModels.RequestOvertime
{
    public class RequestOvertimeIndexViewModel
    {
        public RequestOvertimeIndexViewModel(IEnumerable<Data.Entities.RequestOvertime> data)
        {
            RequestOvertimes = data ?? new List<Data.Entities.RequestOvertime>();
        }

        public IEnumerable<Data.Entities.RequestOvertime> RequestOvertimes { get; }
    }
}
