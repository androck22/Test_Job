
using Test_Job.Models.Error;
using Test_Job.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IConverter, Converter>();
builder.Services.AddTransient<IDecrypter, Decrypter>();
builder.Services.AddTransient<IDeserializer, Deserializer>();
builder.Services.AddTransient<IDomBuilder, DomBuilder>();
builder.Services.AddTransient<IDomParser, DomParser>();
builder.Services.AddTransient<IEmailParser, EmailParser>();
builder.Services.AddTransient<IInformationResponse, InformationResponse>();

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

app.MapControllers();

app.Run();
