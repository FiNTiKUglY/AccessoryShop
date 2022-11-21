using Microsoft.AspNetCore.Mvc;

namespace WEB_053505_Pronin.ExtestionMethods
{
    public static class RequestExtensions
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            var test = request.Headers["x-requested-with"].ToString().ToLower();
            return test.Equals("xmlhttprequest");

        }

    }
}
