using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Employees.Data.Entities
{
    public class Employee : Entity, ISoftDelete
    {
        public string FirstName { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public DateTimeOffset? Deleted { get; set; }

        public string DeleteBy { get; set; }




   

     
    }

  
}
