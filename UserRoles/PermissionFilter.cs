using Core;
using Core.Models.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRoles
{
    public class PermissionFilter : IActionFilter
    {
        private readonly IRoleService _roleService;
        public PermissionFilter(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            int.TryParse(context.HttpContext.Request.Headers["UserId"].FirstOrDefault(), out var userId);
            //Role Yetkisine bakılır.
            if (HasRoleAttribute(context))
            {
                try
                {
                    var arguments = ((ControllerActionDescriptor)context.ActionDescriptor).MethodInfo.CustomAttributes.FirstOrDefault(fd => fd.AttributeType == typeof(RoleAttribute)).ConstructorArguments;

                    int roleGroupID = (int)arguments[0].Value;
                    Int64 roleID = (Int64)arguments[1].Value;
                    RoleModel role = _roleService.GetRoleById(userId, roleGroupID, roleID).Entity;
                    if (role==null || role.Id == 0)
                    {
                        //Forbidden 403 Result. Yetkiniz Yoktur..
                        context.Result = new ObjectResult(context.ModelState)
                        {
                            Value = "You are not authorized for this page",
                            StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status403Forbidden
                        };
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }

        public bool HasRoleAttribute(FilterContext context)
        {
            return ((ControllerActionDescriptor)context.ActionDescriptor).MethodInfo.CustomAttributes.Any(filterDescriptors => filterDescriptors.AttributeType == typeof(RoleAttribute));
        }
    }
}
