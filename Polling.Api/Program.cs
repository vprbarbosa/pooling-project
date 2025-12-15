using Microsoft.EntityFrameworkCore;
using Polling.Infrastructure;
using Polling.Infrastructure.Persistence;
using Polling.Infrastructure.Queries;
using Pooling.Application.Interfaces;
using Pooling.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PollingDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddInfrastructure();

builder.Services.AddScoped<IQuestionnaireService, QuestionnaireService>();
builder.Services.AddScoped<IResponseService, ResponseService>();
builder.Services.AddScoped<IResultService, ResultService>();
builder.Services.AddScoped<IResultQuery, ResultQuery>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();