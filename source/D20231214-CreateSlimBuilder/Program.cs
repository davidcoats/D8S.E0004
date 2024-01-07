
using Microsoft.AspNetCore.Routing.Constraints;

// You still get:
//  * User credential config
//  * Application settings config
//  * Console logger
// What is missing:
//  * No HTTPS
//  * No HTTP3 support.
//  * No regex-based routing.
//  * No support for startup assemblies.
//  * No static web assets.
//  * No IIS (but who needs that?!?).

var builder = WebApplication.CreateSlimBuilder(args);

// Add HTTPS
builder.WebHost.UseKestrelHttpsConfiguration();
// Add HTTP3
builder.WebHost.UseQuic();

// Add regex routing support.
builder.Services.AddRoutingCore().Configure<RouteOptions>(x =>
{
    x.SetParameterPolicy<RegexInlineRouteConstraint>("regex");
});

var app = builder.Build();

// Add HTTPS
app.UseHttpsRedirection();

app.MapGet("hello", () => "World");

app.Run();