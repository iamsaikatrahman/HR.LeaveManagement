using AutoMapper;
using HR.LeavManagement.Application.DTOs.LeaveRequest;
using HR.LeavManagement.Application.Features.LeaveRequestes.Requests.Queries;
using HR.LeavManagement.Application.Persistence.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeavManagement.Application.Features.LeaveRequestes.Handlers.Queries
{
	public class GetLeaveRequestListRequestHandler : IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestListDto>>
	{
		private readonly ILeaveRequestRepository _leaveRequestRepository;
		private readonly IMapper _mapper;
		public GetLeaveRequestListRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
		{
			_leaveRequestRepository = leaveRequestRepository;
			_mapper = mapper;
		}

		public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
		{
			var leaveRequests = await _leaveRequestRepository.GetLeaveRequestWithDetails();
			return _mapper.Map<List<LeaveRequestListDto>>(leaveRequests);
		}
	}
}
