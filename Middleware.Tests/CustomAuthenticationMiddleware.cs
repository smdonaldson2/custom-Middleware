namespace Middleware.Tests
{
    internal class CustomAuthenticationMiddleware
    {
        private Func<object, Task> value;

        public CustomAuthenticationMiddleware(Func<object, Task> value)
        {
            this.value = value;
        }

        internal Task InvokeAsync(DefaultHttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}