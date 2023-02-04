using HR.LeaveManagement.Application.Responses;
using HR.LeavManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequestes.Requests.Commands
{
	public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
	{
		public CreateLeaveRequestDto LeaveRequestDto { get; set; }
	}
}
