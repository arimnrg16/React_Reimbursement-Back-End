using Reimburses.Data.Abstractions;
using Reimburses.Data.Entities;
using Reimburses.ViewModels.RequestMedical;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Reimburses.Controllers
{
    //[Authorize]
    public class RequestMedicalController : Barebone.Controllers.ControllerBase
    {
        public RequestMedicalController(IStorage storage) : base(storage)
        {
        }

        public ActionResult Index(int page = 0, int size = 25)
        {
            return View(new RequestMedicalModelFactory().LoadAll(this.Storage, page, size));
        }

        public ActionResult Create()
        {
            var model = new RequestMedicalCreateViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(RequestMedicalCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                RequestMedical requestMedical = model.ToEntity();
                this.Storage.GetRepository<IRequestMedicalRepository>().Create(requestMedical, this.GetCurrentUserName());
                this.Storage.Save();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
