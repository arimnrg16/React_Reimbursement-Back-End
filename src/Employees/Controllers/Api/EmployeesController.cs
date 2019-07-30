using Barebone.Controllers;
using Data.Entities;
using Employees.Data.Abstractions;
using Employees.Data.Entities;
using Employees.ViewModels.Employee;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Employees.Controllers.Api
{
    //[Authorize]
    [Route("api/employees")]
    public class EmployeesController : ControllerBaseApi
    {
        public EmployeesController(IStorage storage) : base(storage)
        {
        }

        [HttpGet]
        public IActionResult Get(int page = 0, int size = 25)
        {
            IEnumerable<Employee> data = new EmployeeModelFactory().LoadAll(this.Storage, page, size)?.Employees;
            int count = data.Count();

            return Ok(new
            {
                success = true,
                data,
                count,
                totalPage = ((int)count / size) + 1
            });
        }

        [HttpPost]
        public IActionResult Post(EmployeeCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                Employee employee = model.ToEntity();
                var repo = this.Storage.GetRepository<IEmployeeRepository>();

                repo.Create(employee, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var repo = this.Storage.GetRepository<IEmployeeRepository>();

            Employee employee = repo.WithKey(id);
            if (employee == null)
                return this.NotFound(new { success = false });

            return Ok(new { success = true, data = employee });
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, EmployeeUpdateViewModel model)
        {
            var repo = this.Storage.GetRepository<IEmployeeRepository>();

            Employee employee = repo.WithKey(id);
            if (employee == null)
                return this.NotFound(new { success = false });

            if (this.ModelState.IsValid)
            {
                model.ToEntity(employee, this.GetCurrentUserName());
                repo.Edit(employee, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var repo = this.Storage.GetRepository<IEmployeeRepository>();

            Employee employee = repo.WithKey(id);
            if (employee == null)
                return this.NotFound(new { success = false });

            repo.Delete(employee, GetCurrentUserName());
            this.Storage.Save();

            return Ok(new { success = true });
        }
    }
}
