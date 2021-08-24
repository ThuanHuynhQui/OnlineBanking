using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using OnlineBanking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace OnlineBanking.ActionFilter
{
    public class SessionCheckCustomer : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                Account account = JsonConvert.DeserializeObject<Account>(context.HttpContext.Session.GetString("Account"));
                if (account == null)
                {
                    context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                            { "Controller", "Login" },
                            { "Action", "Login" }
                                });
                }

            }
            catch
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                            { "Controller", "Login" },
                            { "Action", "Login" }
                                });
            }
        }
    }
}
