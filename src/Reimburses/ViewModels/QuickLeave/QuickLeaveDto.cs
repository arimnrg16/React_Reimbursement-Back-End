using Employees.Data.Entities;
using Reimburses.Data.Entities;


namespace Reimburses.ViewModels.QuickLeave
{
    public class QuickLeaveDto
    {
        public QuickLeaveDto(Data.Entities.QuickLeave quickLeave)
        {
            //EmployeeName = employee.FirstName;
            Id = quickLeave.Id;

        }

        public string EmployeeName { get; set; }
        public int Id { get; }



    }
}