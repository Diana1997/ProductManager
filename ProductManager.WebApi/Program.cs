
using ProductManager.Application;
using ProductManager.Infrastructure;
using ProductManager.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication(builder.Configuration);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();     

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();      
    app.UseSwaggerUI(c =>  
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseCors("AllowAngularApp");

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();

