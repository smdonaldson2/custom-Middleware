namespace Middleware.Tests
{
    internal class DefaultHttpContext
    {
        public DefaultHttpContext()
        {
        }

        public object Request { get; internal set; }
        public object Response { get; internal set; }
    }
}