using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Reimburses.Data.Entities;

namespace Reimburses.ViewModels.RequestBusinesstrip
{
    public class RequestBusinesstripCreateViewModel
    {
        public DateTimeOffset dateBusinessTrip { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public int totalCostNominal { get; set; }
        public int totalCostReimburse { get; set; }
        public IFormFile Image { get; set; }

        internal Data.Entities.RequestBusinesstrip ToEntity()
        {
            return new Data.Entities.RequestBusinesstrip
            {
                dateBusinessTrip = this.dateBusinessTrip,
                from = this.from,
                to = this.to,
                totalCostNominal = this.totalCostNominal,
                totalCostReimburse = this.totalCostReimburse,
                //Image = this.Image,
            };
        }
    }
}
