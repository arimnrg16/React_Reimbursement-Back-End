using System;
using Employees.Data.Abstractions;
using ExtCore.Data.Abstractions;

namespace Employees.ViewModels.Employee
{
    internal class EmployeeModelFactory
    {
        public EmployeeModelFactory()
        {
        }

        internal EmpIndexViewModel LoadAll(IStorage storage, int page, int size)
        {
            var employeeRepo = storage.GetRepository<IEmployeeRepository>();

            return new EmpIndexViewModel(employeeRepo.All(page, size));
        }
    }
}