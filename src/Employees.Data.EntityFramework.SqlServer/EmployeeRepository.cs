using Data.EntityFramework.SqlServer;
using Employees.Data.Abstractions;
using Employees.Data.Entities;

namespace Employees.Data.EntityFramework.SqlServer
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
    }
}
