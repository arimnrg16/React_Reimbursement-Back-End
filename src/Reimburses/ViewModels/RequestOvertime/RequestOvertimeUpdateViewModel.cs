using System;
using Microsoft.AspNetCore.Http;
using Reimburses.Data.Entities;

namespace Reimburses.ViewModels.RequestOvertime
{
    public class RequestOvertimeUpdateViewModel
    {
        public RequestOvertimeUpdateViewModel() { }

        private readonly Data.Entities.RequestOvertime _entity;

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

        internal Data.Entities.RequestOvertime ToEntity(Data.Entities.RequestOvertime entity, string username)
        {
        
            entity.overtimeType = this.overtimeType;
            entity.startTime = this.startTime;
            entity.finishTime = this.finishTime;
            entity.totalOvertime = this.totalOvertime;
            entity.departmentId = this.departmentId;
            entity.groupId = this.groupId;
            entity.projectName = this.projectName;
            entity.requestTo = this.requestTo;
            entity.transportReimbursement = this.transportReimbursement;
            entity.mealReimbursement = this.mealReimbursement;

            entity.Modified = DateTime.Now;
            entity.ModifiedBy = username;

            return entity;
        }
    }
}
