using GlobalQueryFilter.Api.Services;
using GlobalQueryFilter.Application.Commands;
using GlobalQueryFilter.Application.Queries;
using GlobalQueryFilter.Data.Base;
using GlobalQueryFilter.Data.Repositories;
using GlobalQueryFilter.Domain.Contracts.Commands;
using GlobalQueryFilter.Domain.Contracts.Common;
using GlobalQueryFilter.Domain.Contracts.Queries;
using GlobalQueryFilter.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUserRequest, UserRequest>();
builder.Services.AddDbContextPool<IDatabaseContext, DatabaseContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    opt.EnableDetailedErrors();
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IAddInvoiceCommand, AddInvoiceCommand>();
builder.Services.AddScoped<IGetInvoiceByOwnerQuery, GetInvoiceByOwnerQuery>();
builder.Services.AddScoped<IGetAllInvoicesQuery, GetAllInvoicesQuery>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();
