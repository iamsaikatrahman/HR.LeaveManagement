using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequestes.Requests.Commands;
using HR.LeaveManagement.Domain;
using HR.LeavManagement.Application.Persistence.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
	public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
	{
		private readonly ILeaveRequestRepository _leaveRequestRepository;
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IMapper _mapper;

		public UpdateLeaveRequestCommandHandler(
			ILeaveRequestRepository leaveRequestRepository, 
			IMapper mapper,
			ILeaveTypeRepository leaveTypeRepository)
		{
			_leaveRequestRepository = leaveRequestRepository;
			_mapper = mapper;
			_leaveTypeRepository = leaveTypeRepository;
		}

		public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
		{
			var leaveRequest = await _leaveRequestRepository.Get(request.Id);

			if (leaveRequest is null)
				throw new NotFoundException(nameof(leaveRequest), request.Id);

			if (request.LeaveRequestDto != null)
			{
				var validator = new UpdateLeaveRequestDtoValidator(_leaveTypeRepository);
				var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);
				if (validationResult.IsValid == false)
					throw new ValidationException(validationResult);

				_mapper.Map(request.LeaveRequestDto, leaveRequest);
				await _leaveRequestRepository.Update(leaveRequest);
				
			}
			else if(request.ChangeLeaveRequestApprovalDto != null)
			{
				await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDto.Approved);
				if (request.ChangeLeaveRequestApprovalDto.Approved)
				{ 
					
				}
			}
			return Unit.Value;
		}
	}
}
