using HR.LeaveManagement.Application.Responses;
using HR.LeavManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
	public class CreateLeaveAllocationCommand : IRequest<BaseCommandResponse>
	{
		public CreateLeaveAllocationDto LeaveAllocationDto { get; set; }
	}
}
