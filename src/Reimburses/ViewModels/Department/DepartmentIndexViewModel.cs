using System.Collections.Generic;
using Reimburses.Data.Entities;

namespace Reimburses.ViewModels.Department
{
    class DepartmentIndexViewModel
    {
        public DepartmentIndexViewModel(IEnumerable<Data.Entities.Department> data)
        {
            Departments = data ?? new List<Data.Entities.Department>();
        }

        public IEnumerable<Data.Entities.Department> Departments { get; }
    }
}
