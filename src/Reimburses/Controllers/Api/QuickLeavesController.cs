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

namespace Reimburses.Controllers.Api
{
    //[Authorize]
    [Route("api/quickleaves")]
    public class QuickLeavesController : ControllerBaseApi
    {
        public QuickLeavesController(IStorage storage) : base(storage)
        {
        }

        [HttpGet]
        public IActionResult Get(int page = 0, int size = 25)
        {
            IEnumerable<QuickLeave> data = new QuickLeaveModelFactory().LoadAll(this.Storage, page, size)?.QuickLeaves;
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
        public IActionResult Post(QuickLeaveCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                QuickLeave quickLeave = model.ToEntity();
                var repo = this.Storage.GetRepository<IQuickLeaveRepository>();

                repo.Create(quickLeave, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var repo = this.Storage.GetRepository<IQuickLeaveRepository>();

            QuickLeave quickLeave = repo.WithKey(id);

            //if (quickLeave == null)
            //{
            //    return NotFound("The Employee record couldn't be found.");
            //}

            if (quickLeave == null)
                return this.NotFound(new { success = false });

            return Ok(new { success = true, data = quickLeave });
        }

        //approve

        [HttpPost("{id:int}/approveby-sm")]
        public IActionResult ApproveByScrumMaster(int id)
        {
            var username = this.GetCurrentUserName();

            var repo = this.Storage.GetRepository<IQuickLeaveRepository>();

            QuickLeave quickLeave = repo.WithKey(id);
            if (quickLeave == null)
                return this.NotFound(new { success = false });

            // TODO : find correct Employee ID from Username
            // quickLeave.ScrumMasterApproved(0);

            return Ok(new { success = true });
        }

        [HttpPost("{id:int}/approveby-hr")]
        public IActionResult ApproveByHumanResourceDept(int id)
        {
            var username = this.GetCurrentUserName();

            var repo = this.Storage.GetRepository<IQuickLeaveRepository>();

            QuickLeave quickLeave = repo.WithKey(id);

            if (quickLeave == null)
                return this.NotFound(new { success = false });

            return Ok(new { success = true });
        }

        //endof



        [HttpPut("{id:int}")]
        public IActionResult Put(int id, QuickLeaveUpdateViewModel model)
        {
            var repo = this.Storage.GetRepository<IQuickLeaveRepository>();

            QuickLeave quickLeave = repo.WithKey(id);
            if (quickLeave == null)
                return this.NotFound(new { success = false });


            //if (quickLeave == null)
            //{
            //    return NotFound("The Employee record couldn't be found.");
            //}

            if (this.ModelState.IsValid)
            {
                model.ToEntity(quickLeave, this.GetCurrentUserName());
                repo.Edit(quickLeave, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var repo = this.Storage.GetRepository<IQuickLeaveRepository>();

            QuickLeave quickLeave = repo.WithKey(id);
            if (quickLeave == null)
                return this.NotFound(new { success = false });

            repo.Delete(quickLeave, GetCurrentUserName());
            this.Storage.Save();

            return Ok(new { success = true });
        }
    }
}
