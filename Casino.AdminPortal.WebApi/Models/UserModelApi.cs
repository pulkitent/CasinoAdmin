﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Casino.AdminPortal.WebApi.Models
{
    public class UserModelApi
    {
        public string Name { get; set; }

        public string EmailId { get; set; }

        public decimal AccountBalance { get; set; }

        public int BlockedAmount { get; set; }
    }
}


 