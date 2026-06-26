using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Gianoli_BankApp.Data;
using Gianoli_BankApp.Services;
using System.Security.Authentication.ExtendedProtection;

ServiceProvider _serviceProvider;
BankQueryService _queryService;

var services = new ServiceCollection();

services.AddDbContext<ApplicationDbContext>();
services.AddScoped<BankQueryService>();

_serviceProvider = services.BuildServiceProvider();
_queryService = _serviceProvider.GetRequiredService<BankQueryService>();