using FluentValidation;
using HR.LeavManagement.Application.DTOs.LeaveType.LeaveTypeDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
	public class UpdateLeaveTypeDtoValidator : AbstractValidator<LeaveTypeDto>
	{
		public UpdateLeaveTypeDtoValidator() 
		{
			Include(new IleaveTypeDtoValidator());
			RuleFor(p => p.Id)
				.NotNull()
				.WithMessage("{PropertyName} must be present");
		}
	}
}
