using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Enum;

namespace WebApplication.Entity.Services
{
    public class RoleReq
    {
        [JsonProperty("role")]
        public List<UserRoleEnum> Role { get; set; }
    }
}
