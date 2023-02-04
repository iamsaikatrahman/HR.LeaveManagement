using HR.LeavManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR.LeavManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationDetailRequest : IRequest<LeaveAllocationDto>
	{
		public int Id { get; set; }
	}
}
