using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi.Helpers
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        //private readonly IUserPermissionsRepository permissionRepository;

        //public PermissionHandler(IUserPermissionsRepository permissionRepository)
        //{
        //    if (permissionRepository == null)
        //        throw new ArgumentNullException(nameof(permissionRepository));

        //    this.permissionRepository = permissionRepository;
        //}

        //protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        //                                        IsAllowedToManageProductRequirement requirement)
        //{
        //    if (context.User.HasClaim(f => f.Type == "Employee"))
        //    {
        //        context.Succeed(requirement);
        //    }
        //    return Task.CompletedTask;
        //}

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User == null)
            {
                // no user authorizedd. Alternatively call context.Fail() to ensure a failure 
                // as another handler for this requirement may succeed
                return null;
            }


            //bool hasPermission = permissionRepository.CheckPermissionForUser(context.User, requirement.Permission);
            //if (hasPermission)
            //{
            //    context.Succeed(requirement);
            //}
            bool hasPermission = false;
            foreach (var claim in context.User.Claims)
            {
                if (claim.Type == ClaimTypes.UserData)
                    if (claim.Value.Equals(requirement.Permission.Name))
                    {
                        hasPermission = true;
                        break;
                    }
            }


            if (hasPermission)
                context.Succeed(requirement);
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
