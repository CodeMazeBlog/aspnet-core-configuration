using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectConfigurationDemo.Models;
using ProjectConfigurationDemo.Models.ConfigurationProviders;

namespace ProjectConfigurationDemo
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				})
				.ConfigureAppConfiguration((hostingContext, configBuilder) =>
				{
					var config = configBuilder.Build();

					var configSource = new EFConfigurationSource(opts =>
						opts.UseSqlServer(config.GetConnectionString("sqlConnection")));

					configBuilder.Add(configSource);
				});
	}
}
