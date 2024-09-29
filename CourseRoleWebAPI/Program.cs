using CourseRoleWebAPI.Models;
using CourseRoleWebAPI.Repositories;
using CourseRoleWebAPI.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using CourseRoleWebAPI.Mappings;
using CourseRoleWebAPI.Services.IServices;
using CourseRoleWebAPI.Services;
using FluentValidation.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repositorios y Servicios
builder.Services.AddScoped<ICourseTypeRepository, CourseTypeRepo>();
builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddScoped<ILogRepository, LogRepo>();
builder.Services.AddScoped<ILogService, LogService>();

builder.Services.AddScoped<IPermissionRepository, PermissionRepo>();
builder.Services.AddScoped<IPermissionService, PermissionService>();

builder.Services.AddScoped<ICourseRepository, CourseRepo>();
builder.Services.AddScoped<ICourseTypeService, CourseTypeService>();

//Fluent
builder.Services.AddFluentValidation((options) =>
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly())
);

//AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//DbContext
builder.Services.AddDbContext<CoursesRolesContext>((context) =>
{
    context.UseSqlServer(builder.Configuration.GetConnectionString("coursesDb"));
});

var app = builder.Build();

//CORS
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});


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
