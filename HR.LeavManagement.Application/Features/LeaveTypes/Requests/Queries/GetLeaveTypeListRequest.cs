using HR.LeavManagement.Application.DTOs.LeaveTypeDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeavManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
	{

	}
}
