using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using Reimburses.Data.Entities;

namespace Reimburses.ViewModels.RequestMedical
{
    public class RequestMedicalCreateViewModel
    {
        public DateTimeOffset dateRequestMedical { get; set; }
        [Display(Name = "Medication Type")]
        [Required()]
        public string medicationType { get; set; }
        [Display(Name = "Total Cost")]
        [Required()]
        public int totalCostNominal { get; set; }
        public int totalCostReimburse { get; set; }
        public IFormFile Image { get; set; }

        internal Data.Entities.RequestMedical ToEntity()
        {
            return new Data.Entities.RequestMedical
            {
                dateRequestMedical = this.dateRequestMedical,
                medicationType = this.medicationType,
                totalCostNominal = this.totalCostNominal,
                totalCostReimburse = this.totalCostReimburse,
                //Image = this.Image,
            };
        }
    }
}
