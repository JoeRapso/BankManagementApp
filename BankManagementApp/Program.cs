

using BankManagementApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//IHost _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
//{
//    services.AddSingleton<IApp, App>();
//}).Build();

//var app = _host.Services.GetRequiredService<IApp>();

var app = new App();
app.Run();