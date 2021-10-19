using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Enums;

namespace WebApi.Helpers
{
    public interface IUserPermissionsRepository
    {
        public bool CheckPermissionForUser(ClaimsPrincipal principal, Permission permissions);
    }
}
