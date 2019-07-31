using System;
using Reimburses.Data.Abstractions;
using ExtCore.Data.Abstractions;

namespace Reimburses.ViewModels.Group
{
    internal class GroupModelFactory
    {
        public GroupModelFactory()
        {
        }

        internal GroupIndexViewModel LoadAll(IStorage storage, int page, int size)
        {
            var groupRepo = storage.GetRepository<IGroupRepository>();


            return new GroupIndexViewModel(groupRepo.All(groupRepo.Query, page, size));

        }
    }
}
