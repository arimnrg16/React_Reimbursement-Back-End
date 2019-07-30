using System.Collections.Generic;
using Reimburses.Data.Entities;

namespace Reimburses.ViewModels.Group
{
    class GroupIndexViewModel
    {
        public GroupIndexViewModel(IEnumerable<Data.Entities.Group> data)
        {
            Groups = data ?? new List<Data.Entities.Group>();
        }

        public IEnumerable<Data.Entities.Group> Groups { get; }
    }
}
