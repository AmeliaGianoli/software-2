using Gianoli_ChinookCrudApp.Data;
// using Gianoli_ChinookCrudApp.Services;
using Microsoft.Extensions.DependencyInjection;

ServiceProvider _serviceProvider;
// MusicQueryService _musicQueryService;

var services = new ServiceCollection();

services.AddDbContext<ApplicationDbContext>();
// services.AddScoped<MusicQueryService>();

_serviceProvider = services.BuildServiceProvider();