using Barebone.Controllers;
using Data.Entities;
using Reimburses.Data.Abstractions;
using Reimburses.Data.Entities;
using Reimburses.ViewModels.QuickLeave;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Reimburses.ViewModels.Department;

namespace Reimburses.Controllers.Api
{
    //[Authorize]
    [Route("api/departments")]
    public class DepartmentsController : ControllerBaseApi
    {
        public DepartmentsController(IStorage storage) : base(storage)
        {
        }

        [HttpGet]
        public IActionResult Get(int page = 0, int size = 25)
        {
            IEnumerable<Department> data = new DepartmentModelFactory().LoadAll(this.Storage, page, size)?.Departments;
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
        public IActionResult Post(DepartmentCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                Department department = model.ToEntity();
                var repo = this.Storage.GetRepository<IDepartmentRepository>();

                repo.Create(department, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var repo = this.Storage.GetRepository<IDepartmentRepository>();

            Department department = repo.WithKey(id);

            //if (quickLeave == null)
            //{
            //    return NotFound("The Employee record couldn't be found.");
            //}

            if (department == null)
                return this.NotFound(new { success = false });

            return Ok(new { success = true, data = department });
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, DepartmentUpdateViewModel model)
        {
            var repo = this.Storage.GetRepository<IDepartmentRepository>();

            Department department = repo.WithKey(id);
            if (department == null)
                return this.NotFound(new { success = false });


            //if (quickLeave == null)
            //{
            //    return NotFound("The Employee record couldn't be found.");
            //}

            if (this.ModelState.IsValid)
            {
                model.ToEntity(department, this.GetCurrentUserName());
                repo.Edit(department, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var repo = this.Storage.GetRepository<IDepartmentRepository>();

            Department department = repo.WithKey(id);
            if (department == null)
                return this.NotFound(new { success = false });

            repo.Delete(department, GetCurrentUserName());
            this.Storage.Save();

            return Ok(new { success = true });
        }
    }
}
