using HR.LeavManagement.Application.DTOs.LeaveType.LeaveTypeDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
	public class DeleteLeaveRequestCommand : IRequest
	{
		public int Id { get; set; }
	}
}
