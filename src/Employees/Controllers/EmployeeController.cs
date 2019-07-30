using Employees.Data.Abstractions;
using Employees.Data.Entities;
using Employees.ViewModels.Employee;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers
{
    //[Authorize]
    public class EmployeeController : Barebone.Controllers.ControllerBase
    {
        public EmployeeController(IStorage storage) : base(storage)
        {
        }

        public ActionResult Index(int page = 0, int size = 25)
        {
            return View(new EmployeeModelFactory().LoadAll(this.Storage, page, size));
        }

        public ActionResult Create()
        {
            var model = new EmployeeCreateViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(EmployeeCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                Employee employee = model.ToEntity();
                this.Storage.GetRepository<IEmployeeRepository>().Create(employee, this.GetCurrentUserName());
                this.Storage.Save();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}