﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrackEmployeeAbsence.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EmployeeAbsenceTrackerEntities1 : DbContext
    {
        public EmployeeAbsenceTrackerEntities1()
            : base("name=EmployeeAbsenceTrackerEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AbsenceList> AbsenceLists { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    
        public virtual int SP_ApplyLeave(Nullable<int> empId, string fname, string lname, Nullable<System.DateTime> date, string reason)
        {
            var empIdParameter = empId.HasValue ?
                new ObjectParameter("EmpId", empId) :
                new ObjectParameter("EmpId", typeof(int));
    
            var fnameParameter = fname != null ?
                new ObjectParameter("Fname", fname) :
                new ObjectParameter("Fname", typeof(string));
    
            var lnameParameter = lname != null ?
                new ObjectParameter("Lname", lname) :
                new ObjectParameter("Lname", typeof(string));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            var reasonParameter = reason != null ?
                new ObjectParameter("reason", reason) :
                new ObjectParameter("reason", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ApplyLeave", empIdParameter, fnameParameter, lnameParameter, dateParameter, reasonParameter);
        }
    
        public virtual ObjectResult<SP_EmpListDateRange_Result> SP_EmpListDateRange(Nullable<System.DateTime> startLeaveDate, Nullable<System.DateTime> endLeaveDate)
        {
            var startLeaveDateParameter = startLeaveDate.HasValue ?
                new ObjectParameter("startLeaveDate", startLeaveDate) :
                new ObjectParameter("startLeaveDate", typeof(System.DateTime));
    
            var endLeaveDateParameter = endLeaveDate.HasValue ?
                new ObjectParameter("endLeaveDate", endLeaveDate) :
                new ObjectParameter("endLeaveDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_EmpListDateRange_Result>("SP_EmpListDateRange", startLeaveDateParameter, endLeaveDateParameter);
        }
    
        public virtual ObjectResult<SP_EmployeeAbsenceHistory_Result> SP_EmployeeAbsenceHistory(Nullable<int> employeeID)
        {
            var employeeIDParameter = employeeID.HasValue ?
                new ObjectParameter("employeeID", employeeID) :
                new ObjectParameter("employeeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_EmployeeAbsenceHistory_Result>("SP_EmployeeAbsenceHistory", employeeIDParameter);
        }
    
        public virtual ObjectResult<SP_EmployeeList_Result> SP_EmployeeList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_EmployeeList_Result>("SP_EmployeeList");
        }
    
        public virtual int SP_UpdateLeave(Nullable<int> leaveId, string reason)
        {
            var leaveIdParameter = leaveId.HasValue ?
                new ObjectParameter("LeaveId", leaveId) :
                new ObjectParameter("LeaveId", typeof(int));
    
            var reasonParameter = reason != null ?
                new ObjectParameter("reason", reason) :
                new ObjectParameter("reason", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_UpdateLeave", leaveIdParameter, reasonParameter);
        }
    }
}
