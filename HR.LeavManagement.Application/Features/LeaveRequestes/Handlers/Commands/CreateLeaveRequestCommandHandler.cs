using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequestes.Requests.Commands;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using HR.LeavManagement.Application.Persistence.Contracts;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
	public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
	{
		private readonly ILeaveRequestRepository _leaveRequestRepository;
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IMapper _mapper;

		public CreateLeaveRequestCommandHandler(
			ILeaveRequestRepository leaveRequestRepository, 
			IMapper mapper,
			ILeaveTypeRepository leaveTypeRepository)
		{
			_leaveRequestRepository = leaveRequestRepository;
			_mapper = mapper;
			_leaveTypeRepository = leaveTypeRepository;
		}

		public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
			var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

			if (validationResult.IsValid == false)
			{
				response.Success = false;
				response.Message = "Creation Failed";
				response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
			}
			
			var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);
			leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

			response.Success = true;
			response.Message = "Creation Successful";
			response.Id = leaveRequest.Id;
			return response;
		}
	}
}
