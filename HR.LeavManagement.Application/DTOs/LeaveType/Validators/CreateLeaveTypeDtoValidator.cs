using FluentValidation;
using HR.LeavManagement.Application.DTOs.LeaveType.LeaveTypeDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
	public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
	{
		public CreateLeaveTypeDtoValidator()
		{
			Include(new IleaveTypeDtoValidator());
		}

	}	
}
