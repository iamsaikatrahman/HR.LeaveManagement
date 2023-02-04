using HR.LeavManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeavManagement.Application.Features.LeaveRequestes.Requests.Queries
{
	public class GetLeaveRequestDetailRequest : IRequest<LeaveRequestDto>
	{
		public int Id { get; set; }
	}
}
