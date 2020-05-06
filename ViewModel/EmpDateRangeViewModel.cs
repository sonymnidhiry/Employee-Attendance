using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackEmployeeAbsence.ViewModel
{
    public class EmpDateRangeViewModel
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Counts { get; set; }
    }
}