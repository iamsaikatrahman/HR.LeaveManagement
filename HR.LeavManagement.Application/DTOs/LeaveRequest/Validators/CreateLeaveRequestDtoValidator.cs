using FluentValidation;
using HR.LeavManagement.Application.DTOs.LeaveRequest;
using HR.LeavManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
	public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository) 
		{
			_leaveTypeRepository = leaveTypeRepository;
			Include(new ILeaveRequestDtoValidator(_leaveTypeRepository));
		}
	}
}
