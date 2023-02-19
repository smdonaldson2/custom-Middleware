namespace WebRazor;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }

    public class CustomAuthenticationMiddleWare
    {
        private readonly ReqDel _next;

        public CustomAuthenticationMiddleWare(ReqDel next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!IsAuthorized(context))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
            }
            else
            {
                await _next(context);
            }
        }
        private bool IsAuthorized(HttpContext context)
        {
            string username = context.Request.Query["username"];
            string password = context.Request.Query["password"];

            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && 
                username == "user1" && password == "password1";
        }
    }
}
