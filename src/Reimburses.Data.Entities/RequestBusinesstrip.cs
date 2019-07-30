using Data.Entities;
using Employees.Data.Entities;
using System;
using System.Collections.Generic;

namespace Reimburses.Data.Entities
{
    public class RequestBusinesstrip : Entity
    {
        public DateTimeOffset dateBusinessTrip { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public int totalCostNominal { get; set; }
        public int totalCostReimburse { get; set; }
        public string ImageUrl { get; set; }
        public int EmployeeId { get; set; }
        //public IFormFile Image { get; set; }

        //approval

        public virtual ICollection<RequestBusinesstripApprovalHistory> ApprovalHistory { get; set; }

        public bool HumanResourceDeptApproved(int hrStaffEmployeeId)
        {
            this.ApprovalHistory.Add(new RequestBusinesstripApprovalHistory
            {
                ApprovalDate = DateTime.Now,
                ApprovalStatusRequestBusinesstrip = ApprovalStatusRequestBusinesstrip.ApprovedByHR,
                RequestBusinesstrip = this,
                EmployeeId = hrStaffEmployeeId
            });

            return true;
        }

        public bool HumanResourceDeptRejected(int hrStaffEmployeeId)
        {
            this.ApprovalHistory.Add(new RequestBusinesstripApprovalHistory
            {
                ApprovalDate = DateTime.Now,
                ApprovalStatusRequestBusinesstrip = ApprovalStatusRequestBusinesstrip.RejectedbyHR,
                RequestBusinesstrip = this,
                EmployeeId = hrStaffEmployeeId
            });

            return true;
        }

        public bool ScrumMasterApproved(int scrumMasterEmployeeId)
        {
            this.ApprovalHistory.Add(new RequestBusinesstripApprovalHistory
            {
                ApprovalDate = DateTime.Now,
                ApprovalStatusRequestBusinesstrip = ApprovalStatusRequestBusinesstrip.ApprovedBySM,
                RequestBusinesstrip = this,
                EmployeeId = scrumMasterEmployeeId
            });

            return true;
        }

        public bool ScrumMasterRejected(int scrumMasterEmployeeId)
        {
            this.ApprovalHistory.Add(new RequestBusinesstripApprovalHistory
            {
                ApprovalDate = DateTime.Now,
                ApprovalStatusRequestBusinesstrip = ApprovalStatusRequestBusinesstrip.RejectedBySM,
                RequestBusinesstrip = this,
                EmployeeId = scrumMasterEmployeeId
            });

            return true;
        }
    }
    public enum ApprovalStatusRequestBusinesstrip
    {
        Draft = 10,

        ApprovedBySM = 20,
        ApprovedByHR,

        RejectedBySM = 30,
        RejectedbyHR
    }


}


