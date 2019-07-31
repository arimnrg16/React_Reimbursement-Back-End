using System;
using Reimburses.Data.Abstractions;
using ExtCore.Data.Abstractions;

namespace Reimburses.ViewModels.Department
{
    internal class DepartmentModelFactory
    {
        public DepartmentModelFactory()
        {
        }

        internal DepartmentIndexViewModel LoadAll(IStorage storage, int page, int size)
        {
            var departmentRepo = storage.GetRepository<IDepartmentRepository>();

            return new DepartmentIndexViewModel(departmentRepo.All(departmentRepo.Query, page, size));


        }
    }
}
