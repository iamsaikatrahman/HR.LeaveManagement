using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeavManagement.Application.Persistence.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{

	public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IMapper _mapper;

		public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
		{
			_leaveTypeRepository = leaveTypeRepository;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateLeaveTypeDtoValidator();
			var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

			if (validationResult.IsValid == false)
				throw new ValidationException(validationResult);

			var leaveType = await _leaveTypeRepository.Get(request.LeaveTypeDto.Id);
			if (leaveType is null)
				throw new NotFoundException(nameof(leaveType), request.LeaveTypeDto.Id);

			_mapper.Map(request.LeaveTypeDto, leaveType);
			await _leaveTypeRepository.Update(leaveType);
			return Unit.Value;
		}
	}
}
