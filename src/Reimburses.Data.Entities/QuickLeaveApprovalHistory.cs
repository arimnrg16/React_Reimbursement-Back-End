using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reimburses.Data.Entities
{
    public class QuickLeaveApprovalHistory : Entity
    {

        public int EmployeeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset ApprovalDate { get; set; }
        public ApprovalStatusQuickLeave ApprovalStatusQuickLeave { get; set; }

        public virtual QuickLeave QuickLeave { get; set; }
    }
}
