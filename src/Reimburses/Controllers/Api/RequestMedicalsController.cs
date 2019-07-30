using Barebone.Controllers;
using Data.Entities;
using Reimburses.Data.Abstractions;
using Reimburses.Data.Entities;
using Reimburses.ViewModels.RequestMedical;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barebone.Services;

namespace Reimburses.Controllers.Api
{
    //[Authorize]
    [Route("api/requestmedicals")]
    public class RequestMedicalsController : Barebone.Controllers.ControllerBase
    {
        private readonly IImageService _imageService;
        public RequestMedicalsController(IStorage storage, IImageService imageService) : base(storage)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public IActionResult Get(int page = 0, int size = 25)
        {
            IEnumerable<RequestMedical> data = new RequestMedicalModelFactory().LoadAll(this.Storage, page, size)?.RequestMedicals;
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
        public async Task<IActionResult> Post(RequestMedicalCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                RequestMedical requestMedical = model.ToEntity();
                var repo = this.Storage.GetRepository<IRequestMedicalRepository>();


                // var imageUrl = await _imageService.UploadImageAsync(model.Image);
                // requestMedical.ImageUrl = imageUrl.ToString();

                repo.Create(requestMedical, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var repo = this.Storage.GetRepository<IRequestMedicalRepository>();

            RequestMedical requestMedical = repo.WithKey(id);
            if (requestMedical == null)
                return this.NotFound(new { success = false });

            return Ok(new { success = true, data = requestMedical });
        }


        //approve

        [HttpPost("{id:int}/approveby-sm")]
        public IActionResult ApproveByScrumMaster(int id)
        {
            var username = this.GetCurrentUserName();

            var repo = this.Storage.GetRepository<IRequestMedicalRepository>();

            RequestMedical requestMedical = repo.WithKey(id);
            if (requestMedical == null)
                return this.NotFound(new { success = false });

            // TODO : find correct Employee ID from Username
            // quickLeave.ScrumMasterApproved(0);

            return Ok(new { success = true });
        }

        [HttpPost("{id:int}/approveby-hr")]
        public IActionResult ApproveByHumanResourceDept(int id)
        {
            var username = this.GetCurrentUserName();

            var repo = this.Storage.GetRepository<IRequestMedicalRepository>();

            RequestMedical requestMedical = repo.WithKey(id);

            if (requestMedical == null)
                return this.NotFound(new { success = false });

            return Ok(new { success = true });
        }

        //endof




        [HttpPut("{id:int}")]
        public IActionResult Put(int id, RequestMedicalUpdateViewModel model)
        {
            var repo = this.Storage.GetRepository<IRequestMedicalRepository>();

            RequestMedical requestMedical = repo.WithKey(id);
            if (requestMedical == null)
                return this.NotFound(new { success = false });

            if (this.ModelState.IsValid)
            {
                model.ToEntity(requestMedical, this.GetCurrentUserName());
                repo.Edit(requestMedical, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var repo = this.Storage.GetRepository<IRequestMedicalRepository>();

            RequestMedical requestMedical = repo.WithKey(id);
            if (requestMedical == null)
                return this.NotFound(new { success = false });

            repo.Delete(requestMedical, GetCurrentUserName());
            this.Storage.Save();

            return Ok(new { success = true });
        }
    }
}
