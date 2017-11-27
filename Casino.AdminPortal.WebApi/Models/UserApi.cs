using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Casino.AdminPortal.WebApi.Models
{
    public class UserApi
    {
        public IList<UserModelApi> userList { get; set; }
    }
}