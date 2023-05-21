using NewUpstorm.Service.Exceptions;

namespace NewUpstorm.Web.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (CustomException ex)
            {
                context.Response.StatusCode = ex.Code;
                await context.Response.WriteAsJsonAsync(new
                {
                    Code = ex.Code,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                this.logger.LogError($"{ex.ToString()}\n");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new
                {
                    Code = 500,
                    Message = ex.Message
                });
            }
        }
    }
}
