using System;
using Microsoft.AspNetCore.Http;
using Reimburses.Data.Entities;

namespace Reimburses.ViewModels.RequestBusinesstrip
{
    public class RequestBusinesstripUpdateViewModel
    {
        public RequestBusinesstripUpdateViewModel() { }

        private readonly Data.Entities.RequestBusinesstrip _entity;

        public DateTimeOffset dateBusinessTrip { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public int totalCostNominal { get; set; }
        public int totalCostReimburse { get; set; }
        public IFormFile Image { get; set; }

        internal Data.Entities.RequestBusinesstrip ToEntity(Data.Entities.RequestBusinesstrip entity, string username)
        {
            entity.dateBusinessTrip = this.dateBusinessTrip;
            entity.from = this.from;
            entity.to = this.to;
            entity.totalCostNominal = this.totalCostNominal;
            entity.totalCostReimburse = this.totalCostReimburse;
                     
            entity.Modified = DateTime.Now;
            entity.ModifiedBy = username;

            return entity;
        }
    }
}
