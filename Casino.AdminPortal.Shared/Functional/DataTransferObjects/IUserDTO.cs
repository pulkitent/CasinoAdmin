﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.AdminPortal.Shared
{
    
    public interface IUserDTO : IDTO
    {
        int PlayerId { get; set; }
        string Name { get; set; }
        string ContactNumber { get; set; }
        string EmailId { get; set; }
        System.DateTime DateOfBirth { get; set; }
        decimal AccountBalance { get; set; }
        byte[] IdentityProof { get; set; }
        int BlockedAmount { get; set; }
    }
}
