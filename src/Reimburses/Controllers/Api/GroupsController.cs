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
using Reimburses.ViewModels.Group;

namespace Reimburses.Controllers.Api
{
    //[Authorize]
    [Route("api/groups")]
    public class GroupsController : ControllerBaseApi
    {
        public GroupsController(IStorage storage) : base(storage)
        {
        }

        [HttpGet]
        public IActionResult Get(int page = 0, int size = 25)
        {
            IEnumerable<Group> data = new GroupModelFactory().LoadAll(this.Storage, page, size)?.Groups;
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
        public IActionResult Post(GroupCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                Group group = model.ToEntity();
                var repo = this.Storage.GetRepository<IGroupRepository>();

                repo.Create(group, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var repo = this.Storage.GetRepository<IGroupRepository>();

            Group group = repo.WithKey(id);

            //if (quickLeave == null)
            //{
            //    return NotFound("The Employee record couldn't be found.");
            //}

            if (group == null)
                return this.NotFound(new { success = false });

            return Ok(new { success = true, data = group });
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, GroupUpdateViewModel model)
        {
            var repo = this.Storage.GetRepository<IGroupRepository>();

            Group group = repo.WithKey(id);
            if (group == null)
                return this.NotFound(new { success = false });


            //if (quickLeave == null)
            //{
            //    return NotFound("The Employee record couldn't be found.");
            //}

            if (this.ModelState.IsValid)
            {
                model.ToEntity(group, this.GetCurrentUserName());
                repo.Edit(group, GetCurrentUserName());
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var repo = this.Storage.GetRepository<IGroupRepository>();

            Group group = repo.WithKey(id);
            if (group == null)
                return this.NotFound(new { success = false });

            repo.Delete(group, GetCurrentUserName());
            this.Storage.Save();

            return Ok(new { success = true });
        }
    }
}
