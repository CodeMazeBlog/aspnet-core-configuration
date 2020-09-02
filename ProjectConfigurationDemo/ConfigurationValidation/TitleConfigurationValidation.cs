using Microsoft.Extensions.Options;
using ProjectConfigurationDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectConfigurationDemo.ConfigurationValidation
{
	public class TitleConfigurationValidation : IValidateOptions<TitleConfiguration>
	{
		private readonly string[] _colors = { "red", "green", "blue", "black", "purple", "yellow", "brown", "pink" };

		public ValidateOptionsResult Validate(string name, TitleConfiguration options)
		{
			if (string.IsNullOrEmpty(options.WelcomeMessage) || options.WelcomeMessage.Length > 60)
				return ValidateOptionsResult.Fail("Welcome message must be defined and it must be less than 60 characters long.");

			if (!_colors.Any(c => c == options.Color))
				return ValidateOptionsResult.Fail($"Provided title color '{options.Color}' is not among allowed colors.");

			return ValidateOptionsResult.Success;
		}
	}
}
