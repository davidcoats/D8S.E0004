
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("hello", () => "World");

app.Run();
