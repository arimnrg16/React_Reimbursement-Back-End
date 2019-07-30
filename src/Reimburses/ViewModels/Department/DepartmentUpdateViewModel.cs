using System;
using Reimburses.Data.Entities;

namespace Reimburses.ViewModels.Department
{
    public class DepartmentUpdateViewModel
    {
        public DepartmentUpdateViewModel() { }

        private readonly Data.Entities.Department _entity;


        public String departmentName { get; set; }


        internal Data.Entities.Department ToEntity(Data.Entities.Department entity, string username)
        {
            entity.departmentName = this.departmentName;


            entity.Modified = DateTime.Now;
            entity.ModifiedBy = username;

            return entity;
        }
    }
}
