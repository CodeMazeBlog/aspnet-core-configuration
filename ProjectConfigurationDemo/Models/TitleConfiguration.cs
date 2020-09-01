using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectConfigurationDemo.Models
{
	public class TitleConfiguration
	{
		public string WelcomeMessage { get; set; }
		public bool ShowWelcomeMessage { get; set; }
		public string Color { get; set; }
		public bool UseRandomTitleColor { get; set; }
	}
}
