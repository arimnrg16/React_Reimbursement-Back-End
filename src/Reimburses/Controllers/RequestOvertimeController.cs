using Reimburses.Data.Abstractions;
using Reimburses.Data.Entities;
using Reimburses.ViewModels.RequestOvertime;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Reimburses.Controllers
{
    //[Authorize]
    public class RequestOvertimeController : Barebone.Controllers.ControllerBase
    {
        public RequestOvertimeController(IStorage storage) : base(storage)
        {
        }

        public ActionResult Index(int page = 0, int size = 25)
        {
            return View(new RequestOvertimeModelFactory().LoadAll(this.Storage, page, size));
        }

        public ActionResult Create()
        {
            var model = new RequestOvertimeCreateViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(RequestOvertimeCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                RequestOvertime requestOvertime = model.ToEntity();
                this.Storage.GetRepository<IRequestOvertimeRepository>().Create(requestOvertime, this.GetCurrentUserName());
                this.Storage.Save();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
