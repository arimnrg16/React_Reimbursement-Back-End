using System.Collections.Generic;
using Reimburses.Data.Entities;

namespace Reimburses.ViewModels. RequestBusinesstrip
{
    public class  RequestBusinesstripIndexViewModel
    {
        public  RequestBusinesstripIndexViewModel(IEnumerable<Data.Entities. RequestBusinesstrip> data)
        {
             RequestBusinesstrips = data ?? new List<Data.Entities. RequestBusinesstrip>();
        }

        public IEnumerable<Data.Entities. RequestBusinesstrip>  RequestBusinesstrips { get; }
    }
}
