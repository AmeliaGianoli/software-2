using Gianoli_ChinookMusicApp.Data;
using Microsoft.Extensions.DependencyInjection;

ServiceProvider _serviceProvider;


var services = new ServiceCollection();

services.AddDbContext<ApplicationDbContext>();

_serviceProvider = services.BuildServiceProvider();


