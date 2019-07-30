using System;
using System.ComponentModel.DataAnnotations;
using Reimburses.Data.Entities;

namespace Reimburses.ViewModels.Department
{
    public class DepartmentCreateViewModel
    {

        public String departmentName { get; set; }


        internal Data.Entities.Department ToEntity()
        {
            return new Data.Entities.Department
            {
                departmentName = this.departmentName

            };
        }
    }
}
