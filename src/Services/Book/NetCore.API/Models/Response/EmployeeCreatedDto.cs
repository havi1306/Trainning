﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.API.Models.Response
{
    public class EmployeeCreatedDto
    {
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
