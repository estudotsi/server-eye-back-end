using Microsoft.EntityFrameworkCore;
using server_eye_back_end.Data;
using server_eye_back_end.Services.Interfaces;
using server_eye_back_end.Services.Service;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>
	(opts =>
	{
		opts.UseMySql(connString, ServerVersion.AutoDetect(connString));
	});

builder.Services.AddControllers().AddNewtonsoftJson
	(
		options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
	);

// Add services to the container.
builder.Services.AddScoped<IServerService, ServerService>();
builder.Services.AddScoped<IOsService, OsService>();
builder.Services.AddScoped<IAppService, AppService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin());

app.MapControllers();

app.Run();
