using System;
using Microsoft.AspNetCore.Http;
using Reimburses.Data.Entities;

namespace Reimburses.ViewModels.RequestMedical
{
    public class RequestMedicalUpdateViewModel
    {
        public RequestMedicalUpdateViewModel() { }

        private readonly Data.Entities.RequestMedical _entity;

        public DateTimeOffset dateRequestMedical { get; set; }
        public string medicationType { get; set; }
        public int totalCostNominal { get; set; }
        public int totalCostReimburse { get; set; }
        public IFormFile Image { get; set; }
        internal Data.Entities.RequestMedical ToEntity(Data.Entities.RequestMedical entity, string username)
        {
            entity.dateRequestMedical = this.dateRequestMedical;
            entity.medicationType = this.medicationType;
            entity.totalCostNominal = this.totalCostNominal;
            entity.totalCostReimburse = this.totalCostReimburse;
            entity.Modified = DateTime.Now;
            entity.ModifiedBy = username;

            return entity;
        }
    }
}
