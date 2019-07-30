using Reimburses.Data.Abstractions;
using Reimburses.Data.Entities;
using Reimburses.ViewModels.RequestBusinesstrip;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Reimburses.Controllers
{
    //[Authorize]
    public class RequestBusinesstripController : Barebone.Controllers.ControllerBase
    {
        public RequestBusinesstripController(IStorage storage) : base(storage)
        {
        }

        public ActionResult Index(int page = 0, int size = 25)
        {
            return View(new RequestBusinesstripModelFactory().LoadAll(this.Storage, page, size));
        }

        public ActionResult Create()
        {
            var model = new RequestBusinesstripCreateViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(RequestBusinesstripCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                RequestBusinesstrip requestBusinesstrip = model.ToEntity();
                this.Storage.GetRepository<IRequestBusinesstripRepository>().Create(requestBusinesstrip, this.GetCurrentUserName());
                this.Storage.Save();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
