using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
					var builtConfig = configBuilder.Build();

					using (var store = new X509Store(StoreLocation.CurrentUser))
					{
						store.Open(OpenFlags.ReadOnly);
						var certs = store.Certificates
							.Find(X509FindType.FindByThumbprint, builtConfig["Azure:CertificateThumb"], false);

						configBuilder.AddAzureKeyVault(
							builtConfig["Azure:KeyVault:DNS"],
							builtConfig["Azure:ApplicationId"],
							certs.OfType<X509Certificate2>().Single());

						store.Close();
					}
				});
	}
}
