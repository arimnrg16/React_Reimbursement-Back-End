

using Data.Entities;
using Employees.Data.Entities;
using System;
using System.Collections.Generic;

namespace Reimburses.Data.Entities
{
    public class Group : Entity,ISoftDelete
    {

        public string groupName { get; set; }
        public bool IsDeleted { get ; set ; }
        public DateTimeOffset? Deleted { get; set; }
        public string DeleteBy { get; set; }
    }
}
