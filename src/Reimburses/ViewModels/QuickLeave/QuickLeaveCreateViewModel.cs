using System;
using System.ComponentModel.DataAnnotations;
using Reimburses.Data.Entities;

namespace Reimburses.ViewModels.QuickLeave
{
    public class QuickLeaveCreateViewModel
    {

        public DateTimeOffset date { get; set; }
        public DateTime startTime { get; set; }
        public DateTime finishTime { get; set; }
        public int totalOvertime { get; set; }
        public string purpose { get; set; }
        //public string Department { get; set; }
        public string projectName { get; set; }
        public string requestTo { get; set; }
        public int departmentId { get; set; }
        public int groupId { get; set; }

        internal Data.Entities.QuickLeave ToEntity()
        {
            return new Data.Entities.QuickLeave
            {
                date = this.date,
                startTime = this.startTime,
                finishTime = this.finishTime,
                totalOvertime = this.totalOvertime,
                purpose = this.purpose,               
                projectName = this.projectName,
                requestTo = this.requestTo,
                departmentId = this.departmentId,
                groupId = this.groupId

            };
        }
    }
}
