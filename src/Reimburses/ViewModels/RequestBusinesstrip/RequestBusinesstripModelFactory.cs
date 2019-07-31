using System;
using Reimburses.Data.Abstractions;
using ExtCore.Data.Abstractions;

namespace Reimburses.ViewModels. RequestBusinesstrip
{
    class  RequestBusinesstripModelFactory
    {
        public  RequestBusinesstripModelFactory()
        {
        }

        internal  RequestBusinesstripIndexViewModel LoadAll(IStorage storage, int page, int size)
        {
            var requestBusinesstripRepo = storage.GetRepository<IRequestBusinesstripRepository>();


            return new RequestBusinesstripIndexViewModel(requestBusinesstripRepo.All(requestBusinesstripRepo.Query, page, size));
             }
    }
}
