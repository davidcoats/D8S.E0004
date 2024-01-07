
// Most stripped-back version, with nothing.
var builder = WebApplication.CreateEmptyBuilder(new WebApplicationOptions
{
    Args = args
});

//builder.WebHost.UseKestrel();
builder.WebHost.UseKestrelCore() // Without any MapGet() endpoing below, this option will allow the work. But there is not even a logger!
    // Required to actually be able to accept connections on ports other than 5000.
    //.UseUrls("http://localhost:5228")
    ;
builder.Services.AddRoutingCore();

// Results in exception:
// System.InvalidOperationException: 'No service for type 'Microsoft.AspNetCore.Hosting.Server.IServer' has been registered.'
// (Because the empty builder does not even have a server service!)
var app = builder.Build();

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("World");
//    await next(context);
//});

app.MapGet("hello", () => "World");

// Results in exception:
// System.InvalidOperationException: 'Unable to find the required services. Please add all the required services by calling 'IServiceCollection.AddRouting' inside the call to 'ConfigureServices(...)' in the application startup code.'
// (Because the empty builder does not have any routing.)
app.Run();
