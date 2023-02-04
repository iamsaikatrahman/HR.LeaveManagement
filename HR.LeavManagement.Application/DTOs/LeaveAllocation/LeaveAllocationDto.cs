using HR.LeaveManagement.Domain;
using HR.LeavManagement.Application.DTOs.Common;
using HR.LeavManagement.Application.DTOs.LeaveType.LeaveTypeDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeavManagement.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
		//public Employee Employee { get; set; }
		//public string EmployeeId { get; set; }
		public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
