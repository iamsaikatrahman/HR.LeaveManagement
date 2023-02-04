﻿using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using HR.LeavManagement.Application.Persistence.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
	public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, BaseCommandResponse>
	{
		private readonly ILeaveAllocationRepository _leaveAllocationRepository;
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IMapper _mapper;

		public CreateLeaveAllocationCommandHandler(
			ILeaveAllocationRepository leaveAllocationRepository, 
			IMapper mapper,
			ILeaveTypeRepository leaveTypeRepository)
		{
			_leaveAllocationRepository = leaveAllocationRepository;
			_mapper = mapper;
			_leaveTypeRepository = leaveTypeRepository;
		}

		public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
			var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);

			if (validationResult.IsValid == false)
			{
				response.Success = false;
				response.Message = "Allocations Failed";
				response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
			}
			else 
			{
				var leaveType = await _leaveTypeRepository.Get(request.LeaveAllocationDto.LeaveTypeId);
				var allocations = new List<LeaveAllocation>();
			}

			var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);
			leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);

			response.Success = true;
			response.Message = "Allocations Successful";
			response.Id = leaveAllocation.Id;
			return response;

		}
	}
}
