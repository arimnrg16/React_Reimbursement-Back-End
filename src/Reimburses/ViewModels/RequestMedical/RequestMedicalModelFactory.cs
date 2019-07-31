using System;
using Reimburses.Data.Abstractions;
using ExtCore.Data.Abstractions;

namespace Reimburses.ViewModels. RequestMedical
{
    class  RequestMedicalModelFactory
    {
        public  RequestMedicalModelFactory()
        {
        }

        internal  RequestMedicalIndexViewModel LoadAll(IStorage storage, int page, int size)
        {
            var  requestMedicalRepo = storage.GetRepository<IRequestMedicalRepository>();


            return new RequestMedicalIndexViewModel(requestMedicalRepo.All(requestMedicalRepo.Query, page, size));

        }
    }
}
