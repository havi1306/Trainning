﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Core.Models
{
    /// <summary>
    /// Result between services
    /// </summary>
    public class ActResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
