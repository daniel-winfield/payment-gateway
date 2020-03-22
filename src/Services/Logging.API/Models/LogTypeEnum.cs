﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logging.API.Models
{
    public enum LogType
    {
        // Many more log types could be added 
        Error,
        ValidationSuccess,
        ValidationFailure,
        PaymentSuccess,
        PaymentFailure
    }
}