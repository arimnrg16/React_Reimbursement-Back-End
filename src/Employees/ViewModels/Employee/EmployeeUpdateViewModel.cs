using System;
using Employees.Data.Entities;

namespace Employees.ViewModels.Employee
{
    public class EmployeeUpdateViewModel
    {
        public EmployeeUpdateViewModel() { }

        private readonly Data.Entities.Employee _entity;

        public string FirstName { get; set; }

        internal Data.Entities.Employee ToEntity(Data.Entities.Employee entity, string username)
        {
            entity.FirstName = this.FirstName;
            entity.Modified = DateTime.Now;
            entity.ModifiedBy = username;

            return entity;
        }
    }
}