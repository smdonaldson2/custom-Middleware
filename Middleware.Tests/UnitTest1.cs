namespace Middleware.Tests;

public class UnitTest1
{
    [Theory]
    [InlineData("", 401, "Unauthorized")]
    [InlineData("?username=user1", 401, "Unauthorized")]
    [InlineData("?username=user1&password=password1", 200, "")]
    [InlineData("?username=user5&password=password2", 401, "Unauthorized")]
    public async Task Middleware_ShouldReturn_CorrectStatusAndBody(string queryString, int expectedStatusCode, string expectedResponseBody)
    {
        // Arrange
        var context = new DefaultHttpContext();
        context.Request.QueryString = new QueryString(queryString);
        var middleware = new CustomAuthenticationMiddleware(_ => Task.CompletedTask);

        // Act
        await middleware.InvokeAsync(context);

        // Assert
        Assert.Equal(expectedStatusCode, context.Response.StatusCode);
        Assert.Equal(expectedResponseBody, await context.Response.ReadAsStringAsync());
    }
}