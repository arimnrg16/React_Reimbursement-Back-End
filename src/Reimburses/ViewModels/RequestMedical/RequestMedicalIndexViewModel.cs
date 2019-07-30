using System.Collections.Generic;
using Reimburses.Data.Entities;

namespace Reimburses.ViewModels. RequestMedical
{
    public class  RequestMedicalIndexViewModel
    {
        public  RequestMedicalIndexViewModel(IEnumerable<Data.Entities. RequestMedical> data)
        {
             RequestMedicals = data ?? new List<Data.Entities. RequestMedical>();
        }

        public IEnumerable<Data.Entities. RequestMedical>  RequestMedicals { get; }
    }
}
