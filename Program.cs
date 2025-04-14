using MyOrca.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<OrcaDataContext>();
var app = builder.Build();

app.MapControllers();
//app.MapGet("/", () => "Hello World!");

app.Run();