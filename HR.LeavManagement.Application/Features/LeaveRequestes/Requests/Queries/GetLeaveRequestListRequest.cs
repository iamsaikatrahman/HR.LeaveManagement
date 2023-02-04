using HR.LeavManagement.Application.DTOs;
using HR.LeavManagement.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeavManagement.Application.Features.LeaveRequestes.Requests.Queries
{
	public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestListDto>>
	{

	}
}
