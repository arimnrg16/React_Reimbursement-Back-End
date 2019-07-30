using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Reimburses.Data.Entities;

namespace Reimburses.ViewModels.RequestOvertime
{
    public class RequestOvertimeCreateViewModel
    {

        [Required()]
        public OvertimeType overtimeType { get; set; }
        public DateTimeOffset dateOvertime { get; set; }
        public DateTime startTime { get; set; }
        public DateTime finishTime { get; set; }
        public int totalOvertime { get; set; }
        public int departmentId { get; set; }
        public int groupId { get; set; }
        public string projectName { get; set; }
        public string requestTo { get; set; }
        public int transportReimbursement { get; set; }
        public int mealReimbursement { get; set; }
        public IFormFile Image { get; set; }



        internal Data.Entities.RequestOvertime ToEntity()
        {
            return new Data.Entities.RequestOvertime
            {
                overtimeType = this.overtimeType,
                dateOvertime = this.dateOvertime,
                startTime = this.startTime,
                finishTime = this.finishTime,
                totalOvertime = this.totalOvertime,
                departmentId = this.departmentId,
                groupId = this.groupId,
                projectName = this.projectName,
                requestTo = this.requestTo,
                transportReimbursement = this.transportReimbursement,
                mealReimbursement = this.mealReimbursement
            };
        }
    }
}
