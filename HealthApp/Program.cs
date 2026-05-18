using System;
using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<HealthRecordDB>();
services.AddScoped<IHealthRecordService, HealthRecordService>();
services.AddScoped<IHealthRecordRepository, HealthRecordRepository>();
var provider = services.BuildServiceProvider();

class Program
{
    static void Main(string[] args)
    {
        DoctorMenu menu = new DoctorMenu();
        menu.ShowMenu();
    }
}