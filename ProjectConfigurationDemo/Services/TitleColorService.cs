using Microsoft.Extensions.Options;
using ProjectConfigurationDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectConfigurationDemo.Services
{
	public class TitleColorService : ITitleColorService
	{
		private readonly string[] _colors = { "red", "green", "blue", "black", "purple", "yellow", "brown", "pink" };
		private readonly IOptionsMonitor<TitleConfiguration> _titleConfiguration;

		public TitleColorService(IOptionsMonitor<TitleConfiguration> titleConfiguration)
		{
			_titleConfiguration = titleConfiguration;
		}

		public string GetTitleColor(string pageTitleConfiguration)
		{
			var random = new Random();
			var colorIndex = random.Next(7);
			var titleConfiguration = _titleConfiguration.Get(pageTitleConfiguration);

			return titleConfiguration.UseRandomTitleColor ?
				_colors[colorIndex] :
				titleConfiguration.Color;
		}
	}
}
