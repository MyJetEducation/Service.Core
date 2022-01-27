﻿using System.Text.Json.Serialization;

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
		Welcome,
		Complaisance,
		FirstTouch,
		Eyescatter,
		PjFry,
		SoEasy,
		Habitant,
		NowIKnow,
		TakeYourTime,
		ALongWay,
		IveSeenThis,
		Bender,
		TheSeeker,
		TheGreatChanger,
		WeGotCompany,
		Companion,
		NewBeginning,
		Bullseye,
		Insister,
		PerfectTiming,
		DoubleQuick,
		RareCollector,
		Flash,
		YouCantHide,
		FaceTime,
		TheHabitMaster,
		CheckMe,
		SuperRareCollector,
		AllTheKingsMen,
		RoundTheWorld,
		DayByDay,
		InStore,
		UltraRareCollector,
		Curious,
		TaDam,
		NotSoHard,
		MyPride,
		GreenArrow,
		BadLuck,
		Unstoppable,
		Paradox,
		Split,
		Dwarf,
		Spender,
		Trinity,
		Stability
	}
}