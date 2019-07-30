using Data.Abstractions;
using Employees.Data.Entities;

namespace Employees.Data.Abstractions
{
    public interface IEmployeeRepository : IRepository<Employee>
    {

    }
}
