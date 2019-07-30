using System;
using Reimburses.Data.Entities;

namespace Reimburses.ViewModels.Group
{
    public class GroupUpdateViewModel
    {
        public GroupUpdateViewModel() { }

        private readonly Data.Entities.Group _entity;


        public String groupName { get; set; }
   

        internal Data.Entities.Group ToEntity(Data.Entities.Group entity, string username)
        {
            entity.groupName = this.groupName;
          
            
            entity.Modified = DateTime.Now;
            entity.ModifiedBy = username;

            return entity;
        }
    }
}
