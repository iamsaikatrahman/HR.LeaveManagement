using AutoMapper;
using HR.LeavManagement.Application.DTOs.LeaveAllocation;
using HR.LeavManagement.Application.Features.LeaveAllocations.Requests;
using HR.LeavManagement.Application.Features.LeaveAllocations.Requests.Queries;
using HR.LeavManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeavManagement.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationListRequestHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>
	{
		private readonly ILeaveAllocationRepository _leaveAllocationRepository;
		private readonly IMapper _mapper;
		public GetLeaveAllocationListRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
		{
			_leaveAllocationRepository = leaveAllocationRepository;
			_mapper = mapper;
		}

		public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
		{
			var leaveTypes = await _leaveAllocationRepository.GetLeaveAllocationWithDetails();
			return _mapper.Map<List<LeaveAllocationDto>>(leaveTypes);
		}
	}
}
