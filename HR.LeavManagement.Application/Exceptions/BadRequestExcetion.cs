﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Exceptions
{
	public class BadRequestExcetion : ApplicationException
	{
		public BadRequestExcetion(string message) : base(message)
		{
		}
	}
}
