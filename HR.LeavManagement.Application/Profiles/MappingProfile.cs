﻿using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Domain;
using HR.LeavManagement.Application.DTOs.LeaveAllocation;
using HR.LeavManagement.Application.DTOs.LeaveRequest;
using HR.LeavManagement.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeavManagement.Application.Profiles
{
    public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			#region LeaveRequestMapping
			CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
			CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
			CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
			CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();
			#endregion
			#region LeaveAllocationMapping
			CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
			CreateMap<LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
			CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();
			#endregion
			#region LeaveTypeMapping
			CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
			CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
			#endregion
		}
	}
}
