using System;

namespace Service.Core.Client.Helpers
{
	public class ProgramHelper
	{
		public const string JwtSecretDefaultEnviromentVariable = "JWT_SECRET";
		public const string JwtAudienceDefaultEnviromentVariable = "JWT_AUDIENCE";
		public const string SettingsFileName = ".myjeteducation";
		public const string AppNameProfix = "ED-";

		public static string LoadJwtSecret(string enviromentVariable = JwtSecretDefaultEnviromentVariable)
		{
			string value = GetEnvVariable(enviromentVariable);

			if (value.Length <= 15)
			{
				ShowError($"Length of environment variable {enviromentVariable} must be greater or equal than 16 symbols!");
				return null;
			}

			return value;
		}

		public static string LoadJwtAudience(string enviromentVariable = JwtAudienceDefaultEnviromentVariable)
		{
			return GetEnvVariable(enviromentVariable);
		}

		public static int LoadPort(string enviromentVariable, string defaultPort)
		{
			string value = GetEnvVariable(enviromentVariable, defaultPort);

			if (int.TryParse(value, out int port))
			{
				Console.WriteLine($"{enviromentVariable}: {port}");

				return port;
			}

			ShowError($"Value of environment variable {enviromentVariable} is not int: {value}");

			return 0;
		}

		public static string GetEnvVariable(string enviromentVariable, string defaultValue = null)
		{
			string value = Environment.GetEnvironmentVariable(enviromentVariable);

			if (string.IsNullOrWhiteSpace(value) && defaultValue == null)
				ShowError($"Environment variable {enviromentVariable} is not found");

			return value ?? defaultValue;
		}

		public static void ShowError(string message)
		{
			var value = $"ERROR! {message}";

			Console.WriteLine(value);
			throw new Exception(value);
		}
	}
}