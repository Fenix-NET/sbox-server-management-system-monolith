﻿using SboxServersManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public string Message { get; private set; }
        public Status Status { get; private set; }
        public DateTime? SentAt { get; private set; }
    }
}
