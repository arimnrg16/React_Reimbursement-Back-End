using Data.Entities;
using Employees.Data.Entities;
using System;
using System.Collections.Generic;

namespace Reimburses.Data.Entities
{
    public class RequestOvertime : Entity
    {
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
        public string ImageUrl { get; set; }
        public Department Department { get; set; }
        public Group Group { get; set; }
        public int EmployeeId { get; set; }
        //public IFormFile Image { get; set; }


        //approval

        public virtual ICollection<RequestOvertimeApprovalHistory> ApprovalHistory { get; set; }

        public bool HumanResourceDeptApproved(int hrStaffEmployeeId)
        {
            this.ApprovalHistory.Add(new RequestOvertimeApprovalHistory
            {
                ApprovalDate = DateTime.Now,
                ApprovalStatusRequestOvertime = ApprovalStatusRequestOvertime.ApprovedByHR,
                RequestOvertime = this,
                EmployeeId = hrStaffEmployeeId
            });

            return true;
        }

        public bool HumanResourceDeptRejected(int hrStaffEmployeeId)
        {
            this.ApprovalHistory.Add(new RequestOvertimeApprovalHistory
            {
                ApprovalDate = DateTime.Now,
                ApprovalStatusRequestOvertime = ApprovalStatusRequestOvertime.RejectedbyHR,
                RequestOvertime = this,
                EmployeeId = hrStaffEmployeeId
            });

            return true;
        }

        public bool ScrumMasterApproved(int scrumMasterEmployeeId)
        {
            this.ApprovalHistory.Add(new RequestOvertimeApprovalHistory
            {
                ApprovalDate = DateTime.Now,
                ApprovalStatusRequestOvertime = ApprovalStatusRequestOvertime.ApprovedBySM,
                RequestOvertime = this,
                EmployeeId = scrumMasterEmployeeId
            });

            return true;
        }

        public bool ScrumMasterRejected(int scrumMasterEmployeeId)
        {
            this.ApprovalHistory.Add(new RequestOvertimeApprovalHistory
            {
                ApprovalDate = DateTime.Now,
                ApprovalStatusRequestOvertime = ApprovalStatusRequestOvertime.RejectedBySM,
                RequestOvertime = this,
                EmployeeId = scrumMasterEmployeeId
            });

            return true;
        }
    }
    public enum ApprovalStatusRequestOvertime
    {
        Draft = 10,

        ApprovedBySM = 20,
        ApprovedByHR,

        RejectedBySM = 30,
        RejectedbyHR
    }

    public enum OvertimeType
    {
        Reimburse =1,
        Paid_Quickleave
    }

}