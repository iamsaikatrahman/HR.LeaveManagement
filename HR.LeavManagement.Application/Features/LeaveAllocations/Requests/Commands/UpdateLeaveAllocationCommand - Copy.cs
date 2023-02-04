using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeavManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
	public class UpdateLeaveAllocationCommand : IRequest<Unit>
	{
		public UpdateLeaveAllocationDto LeaveAllocationDto { get; set; }
	}
}
