using AutoMapper;
using HR.LeavManagement.Application.DTOs.LeaveRequest;
using HR.LeavManagement.Application.Features.LeaveRequestes.Requests.Queries;
using HR.LeavManagement.Application.Persistence.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeavManagement.Application.Features.LeaveRequestes.Handlers.Queries
{
	public class GetLeaveRequestDetailRequestHandler : IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDto>
	{
		private readonly ILeaveRequestRepository _leaveRequestRepository;
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IMapper _mapper;

		public GetLeaveRequestDetailRequestHandler(ILeaveRequestRepository leaveRequestRepository,
		ILeaveTypeRepository leaveTypeRepository,
		IMapper mapper)
		{
			_leaveRequestRepository = leaveRequestRepository;
			_leaveTypeRepository = leaveTypeRepository;
			_mapper = mapper;
		}

		public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
		{
			var leaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id);
			return _mapper.Map<LeaveRequestDto>(leaveRequest);
		}
	}
}
