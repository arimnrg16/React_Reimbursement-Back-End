using Reimburses.Data.Entities;
using ExtCore.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reimburses.Data.EntityFramework.SqlServer
{
    public class EntityRegistrar : IEntityRegistrar
    {
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<RequestOvertime>(etb => {
                etb.ToTable("RequestOvertimes");
                etb.HasKey(e => e.Id);

                etb.Property(p => p.overtimeType).HasMaxLength(64).IsRequired();
                //etb.Property(p => p.dateOvertime).HasMaxLength(25).IsRequired();
                //etb.Property(p => p.startTime).HasMaxLength(25).IsRequired();
                //etb.Property(p => p.finishTime).HasMaxLength(25).IsRequired();
                ////etb.Property(p => p.totalOvertime).HasMaxLength(25).IsRequired();
                //etb.Property(p => p.departementOrGroup).HasMaxLength(64).IsRequired();
                etb.Property(p => p.projectName).HasMaxLength(64).IsRequired();
                etb.Property(p => p.requestTo).HasMaxLength(25).IsRequired();
                //etb.Property(p => p.transportReimbursement).HasMaxLength(10).IsRequired();
                //etb.Property(p => p.mealReimbursement).HasMaxLength(10).IsRequired();
                                               
                etb.Property(e => e.Id).ValueGeneratedOnAdd();

               
            });

            modelbuilder.Entity<RequestMedical>(etb => {
                etb.ToTable("RequestMedicals");
                etb.HasKey(e => e.Id);

                //etb.Property(p => p.dateRequestMedical).HasMaxLength(25).IsRequired();
                etb.Property(p => p.medicationType).HasMaxLength(64).IsRequired();
                //etb.Property(p => p.totalCostNominal).HasMaxLength(10).IsRequired();
                //etb.Property(p => p.totalCostReimburse).HasMaxLength(10).IsRequired();
  
                etb.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelbuilder.Entity<RequestBusinesstrip>(etb => {
                etb.ToTable("RequestBusinesstrips");
                etb.HasKey(e => e.Id);
                //etb.Property(p => p.dateBusinessTrip).HasMaxLength(25).IsRequired();
                etb.Property(p => p.from).HasMaxLength(64).IsRequired();
                etb.Property(p => p.to).HasMaxLength(64).IsRequired();
                //etb.Property(p => p.totalCostNominal).HasMaxLength(10).IsRequired();
                //etb.Property(p => p.totalCostReimburse).HasMaxLength(10).IsRequired();
              
                etb.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelbuilder.Entity<QuickLeave>(etb => {
                etb.ToTable("QuickLeaves");
                etb.HasKey(e => e.Id);

                //etb.Property(p => p.Date).HasMaxLength(20).IsRequired();
                //etb.Property(p => p.StartTime).HasMaxLength(20).IsRequired();
                //etb.Property(p => p.FinishTime).HasMaxLength(25).IsRequired();
                //etb.Property(p => p.TotalOvertime).HasMaxLength(25).IsRequired();
                etb.Property(p => p.purpose).HasMaxLength(64).IsRequired();
                etb.Property(p => p.departmentId).HasMaxLength(64).IsRequired();
                etb.Property(p => p.projectName).HasMaxLength(64).IsRequired();
                etb.Property(p => p.requestTo).HasMaxLength(64).IsRequired();


                etb.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelbuilder.Entity<Department>(etb => {
                etb.ToTable("Departments");
                etb.HasKey(e => e.Id);
                etb.Property(p => p.departmentName).HasMaxLength(25).IsRequired();

                etb.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelbuilder.Entity<Group>(etb => {
                etb.ToTable("Groups");
                etb.HasKey(e => e.Id);
                etb.Property(p => p.groupName).HasMaxLength(25).IsRequired();

                etb.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}