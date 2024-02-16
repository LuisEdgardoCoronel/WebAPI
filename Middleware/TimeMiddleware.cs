namespace WebAPI.Middleware
{
    public class TimeMiddleware
    {
        readonly RequestDelegate next;

        public TimeMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await next(context);

            if (context.Request.Query.Any(p=>p.Key=="time"))
            {
                await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
            }
        }

    }












        public static class TimeMiddleExtension
        {
            public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder app)
            {
                return app.UseMiddleware<TimeMiddleware>();
            }
        }
}
