using Microsoft.EntityFrameworkCore;
using TarefaAPI.Infra.Data;
using TarefaAPI.Repository.Interfaces;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConexaoPadrao")));
builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers(); 

app.Run();