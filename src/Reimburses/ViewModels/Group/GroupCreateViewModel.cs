using System;
using System.ComponentModel.DataAnnotations;
using Reimburses.Data.Entities;

namespace Reimburses.ViewModels.Group
{
    public class GroupCreateViewModel
    {

        public String groupName { get; set; }
        

        internal Data.Entities.Group ToEntity()
        {
            return new Data.Entities.Group
            {
                groupName = this.groupName

            };
        }
    }
}
