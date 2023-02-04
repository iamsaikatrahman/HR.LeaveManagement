using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeavManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequestes.Requests.Commands
{
	public class UpdateLeaveRequestCommand : IRequest<Unit>
	{
		public int Id { get; set; }
		public UpdateLeaveRequestDto LeaveRequestDto { get; set; }
		public ChangeLeaveRequestApprovalDto ChangeLeaveRequestApprovalDto { get; set; }
	}
}
