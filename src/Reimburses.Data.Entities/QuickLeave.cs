using Data.Entities;
using Employees.Data.Entities;
using System;
using System.Collections.Generic;

namespace Reimburses.Data.Entities
{
    public class QuickLeave : Entity
    {
        public DateTimeOffset date { get; set; }
        public DateTime startTime { get; set; }
        public DateTime finishTime { get; set; }
        public int totalOvertime { get; set; }
        public string purpose { get; set; }
        public string projectName { get; set; }
        public string requestTo { get; set; }
        public int departmentId { get; set; }
        public int groupId { get; set; }
        public Department Department { get; set; }
        public Group Group { get; set; }
        public int EmployeId { get; set; }

        //public string Department { get; set; }        
        //public virtual Employee Employee { get; set; }


        //approval

        public virtual ICollection<QuickLeaveApprovalHistory> ApprovalHistory { get; set; }

        public bool HumanResourceDeptApproved(int hrStaffEmployeeId)
        {
            this.ApprovalHistory.Add(new QuickLeaveApprovalHistory
            {
                ApprovalDate = DateTime.Now,
                ApprovalStatusQuickLeave = ApprovalStatusQuickLeave.ApprovedByHR,
                QuickLeave = this,
                EmployeeId = hrStaffEmployeeId
            });

            return true;
        }

        public bool HumanResourceDeptRejected(int hrStaffEmployeeId)
        {
            this.ApprovalHistory.Add(new QuickLeaveApprovalHistory
            {
                ApprovalDate = DateTime.Now,
                ApprovalStatusQuickLeave = ApprovalStatusQuickLeave.RejectedbyHR,
                QuickLeave = this,
                EmployeeId = hrStaffEmployeeId
            });

            return true;
        }

        public bool ScrumMasterApproved(int scrumMasterEmployeeId)
        {
            this.ApprovalHistory.Add(new QuickLeaveApprovalHistory
            {
                ApprovalDate = DateTime.Now,
                ApprovalStatusQuickLeave = ApprovalStatusQuickLeave.ApprovedBySM,
                QuickLeave = this,
                EmployeeId = scrumMasterEmployeeId
            });

            return true;
        }

        public bool ScrumMasterRejected(int scrumMasterEmployeeId)
        {
            this.ApprovalHistory.Add(new QuickLeaveApprovalHistory
            {
                ApprovalDate = DateTime.Now,
                ApprovalStatusQuickLeave = ApprovalStatusQuickLeave.RejectedBySM,
                QuickLeave = this,
                EmployeeId = scrumMasterEmployeeId
            });

            return true;
        }
    }
    public enum ApprovalStatusQuickLeave
    {
        Draft = 10,

        ApprovedBySM = 20,
        ApprovedByHR,

        RejectedBySM = 30,
        RejectedbyHR
    }


}
   
      
