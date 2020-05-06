using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackEmployeeAbsence.Models;

namespace TrackEmployeeAbsence.ViewModel
{
    public class EmployeeAbsenceViewModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LeaveDate { get; set; }
        public string LeaveReason { get; set; }
    }
}