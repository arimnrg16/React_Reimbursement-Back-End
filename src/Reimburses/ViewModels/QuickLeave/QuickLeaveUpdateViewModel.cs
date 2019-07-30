using System;
using Reimburses.Data.Entities;

namespace Reimburses.ViewModels.QuickLeave
{
    public class QuickLeaveUpdateViewModel
    {
        public QuickLeaveUpdateViewModel() { }

        private readonly Data.Entities.QuickLeave _entity;


        public DateTimeOffset date { get; set; }
        public DateTime startTime { get; set; }
        public DateTime finishTime { get; set; }
        public int totalOvertime { get; set; }
        public string purpose { get; set; }
        public int departmentId { get; set; }
        public int groupId { get; set; }
        public string projectName { get; set; }
        public string requestTo { get; set; }

        internal Data.Entities.QuickLeave ToEntity(Data.Entities.QuickLeave entity, string username)
        {
            entity.date = this.date;
            entity.startTime = this.startTime;
            entity.finishTime = this.finishTime;
            entity.totalOvertime = this.totalOvertime;
            entity.purpose = this.purpose;
            entity.departmentId = this.departmentId;
            entity.groupId = this.groupId;
            entity.projectName = this.projectName;
            entity.requestTo = this.requestTo;
            entity.Modified = DateTime.Now;
            entity.ModifiedBy = username;

            return entity;
        }
    }
}
