using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reimburses.Data.Entities
{
    public class RequestOvertimeApprovalHistory : Entity
    {

        public int EmployeeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset ApprovalDate { get; set; }
        public ApprovalStatusRequestOvertime ApprovalStatusRequestOvertime { get; set; }

        public virtual RequestOvertime RequestOvertime { get; set; }
    }
}
