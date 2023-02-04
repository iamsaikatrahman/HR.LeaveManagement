using HR.LeavManagement.Application.DTOs.LeaveTypeDto;
using MediatR;

namespace HR.LeavManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeDetailRequest : IRequest<LeaveTypeDto>
	{
		public int Id { get; set; }
	}
}
