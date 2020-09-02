using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectConfigurationDemo.Models
{
	public class ConfigurationDbContext : DbContext
	{
		public ConfigurationDbContext(DbContextOptions options)
			: base(options)
		{
		}

		public DbSet<ConfigurationEntity> ConfigurationEntities { get; set; }
	}
}
