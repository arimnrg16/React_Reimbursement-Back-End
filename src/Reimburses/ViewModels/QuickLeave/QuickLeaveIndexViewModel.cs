using System.Collections.Generic;
using Reimburses.Data.Entities;

namespace Reimburses.ViewModels.QuickLeave
{
    public class QuickLeaveIndexViewModel
    {
        public QuickLeaveIndexViewModel(IEnumerable<Data.Entities.QuickLeave> data)
        {
            QuickLeaves = data ?? new List<Data.Entities.QuickLeave>();
        }

        public IEnumerable<Data.Entities.QuickLeave> QuickLeaves { get; }
    }
}
