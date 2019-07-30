using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reimburses.Data.Entities
{
    public class RequestBusinesstripApprovalHistory : Entity
    {

        public int EmployeeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset ApprovalDate { get; set; }
        public ApprovalStatusRequestBusinesstrip ApprovalStatusRequestBusinesstrip { get; set; }

        public virtual RequestBusinesstrip RequestBusinesstrip { get; set; }
    }
}
