using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeavManagement.Application.DTOs.Common;

namespace HR.LeavManagement.Application.DTOs.LeaveType
{
    public class LeaveTypeDto : BaseDto, ILeaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
