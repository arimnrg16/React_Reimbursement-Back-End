using System;
using System.Collections.Generic;
using System.Text;

namespace Reimburses.Data.Entities
{
    internal interface IApprovalQuickLeaveForm
    {
        bool ScrumMasterApproved(int scrumMasterEmployeeId);
        bool ScrumMasterRejected(int scrumMasterEmployeeId);

        bool HumanResourceDeptApproved(int hrStaffEmployeeId);
        bool HumanResourceDeptRejected(int hrStaffEmployeeId);
    }
}
