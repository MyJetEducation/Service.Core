using System.Text.Json.Serialization;

namespace Service.Core.Client.Constants
{
	/// <summary>
	///     Ачивки
	/// </summary>
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum UserAchievement
	{
		Starter,
		Ignition,
		Voila,
		Complaisance,
		Eyescatter,
		SoEasy,
		Habitant,
		NowIKnow,
		TakeYourTime,
		ALongWay,
		IveSeenThis,
		TheSeeker,
		Bullseye,
		Insister,
		PerfectTiming,
		DoubleQuick,
		RareCollector,
		Flash,
		TheHabitMaster,
		CheckMe,
		SuperRareCollector,
		RoundTheWorld,
		UltraRareCollector,
		Curious,
		TaDam,
		NotSoHard,
		GreenArrow,
		BadLuck,
		Unstoppable,
		Paradox,
		Split,
		Trinity,
		Stability
	}
}