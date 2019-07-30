using Reimburses.Data.Abstractions;
using Reimburses.Data.Entities;
using Reimburses.ViewModels.QuickLeave;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Reimburses.Controllers
{
    //[Authorize]
    public class QuickLeaveController : Barebone.Controllers.ControllerBase
    {
        public QuickLeaveController(IStorage storage) : base(storage)
        {
        }

        public ActionResult Index(int page = 0, int size = 25)
        {
            return View(new QuickLeaveModelFactory().LoadAll(this.Storage, page, size));
        }

        public ActionResult Create()
        {
            var model = new QuickLeaveCreateViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(QuickLeaveCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                QuickLeave quickLeave = model.ToEntity();
                this.Storage.GetRepository<IQuickLeaveRepository>().Create(quickLeave, this.GetCurrentUserName());
                this.Storage.Save();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
