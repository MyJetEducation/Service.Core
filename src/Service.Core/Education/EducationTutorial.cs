using System.Text.Json.Serialization;

namespace Service.Core.Education
{
	[JsonConverter(typeof (JsonStringEnumConverter))]
	public enum EducationTutorial
	{
		None = 0,
		PersonalFinance = 1,
		BehavioralFinance = 2,
		FinancialServices = 3,
		FinanceMarkets = 4,
		HealthAndFinance = 5,
		PsychologyAndFinance = 6,
		FinanceSecurity = 7,
		TimeManagement = 8,
		Economics = 9
	}
}