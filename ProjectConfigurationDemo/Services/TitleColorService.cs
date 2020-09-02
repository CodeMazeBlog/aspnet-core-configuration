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
		private readonly TitleConfiguration _titleConfiguration;

		public TitleColorService(IOptionsMonitor<TitleConfiguration> titleConfiguration)
		{
			_titleConfiguration = titleConfiguration.CurrentValue;
		}

		public string GetTitleColor()
		{
			var random = new Random();
			var colorIndex = random.Next(7);

			return _titleConfiguration.UseRandomTitleColor ?
				_colors[colorIndex] :
				_titleConfiguration.Color;
		}
	}
}
