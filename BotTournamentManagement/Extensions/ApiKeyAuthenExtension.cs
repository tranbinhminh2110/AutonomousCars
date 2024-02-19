namespace DocnetCorePractice.Extensions
{
    public class ApiKeyAuthenExtension
    {
        private readonly RequestDelegate _requestDelegate;

        private readonly string KeyName = "x-api-key";

        private readonly string KeyValue = "bsdugf98whf89fh8wfhsdsadsadasdqw";

        public ApiKeyAuthenExtension(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            var apiToken = context.Request.Headers[KeyName].FirstOrDefault();

            if (apiToken == null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("ApiKey Name is not authorzation!");
                return;
            }

            if (apiToken != KeyValue)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("ApiKey Value is not authorzation!");
                return;
            }

            await _requestDelegate(context);
        }
    }
}