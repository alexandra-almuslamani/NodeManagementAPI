using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NodeManagementAPI.Core.Entities;
using NodeManagementAPI.Core.IRepositories;
using NodeManagementAPI.Infrastructure;
using NodeManagementAPI.Infrastructure.Repository;
using NodeManagementAPI.Services.Contract.INodeContracts;
using NodeManagementAPI.Services.Contract.INodeTypeContracts;
using NodeManagementAPI.Services.Implementation.NodeImplementations;
using NodeManagementAPI.Services.Implementation.NodeTypeImplementations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<INodeService, NodeService>();
builder.Services.AddScoped<INodeTypeService, NodeTypeService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
