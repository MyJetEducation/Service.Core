using System.Collections.Generic;

namespace Service.Core.Client.Education
{
	public class EducationStructure
	{
		public static IDictionary<EducationTutorial, EducationStructureTutorial> Tutorials = new Dictionary<EducationTutorial, EducationStructureTutorial>
		{
			{
				EducationTutorial.PersonalFinance, new EducationStructureTutorial
				{
					Tutorial = EducationTutorial.PersonalFinance,
					Units = new Dictionary<int, EducationStructureUnit>
					{
						{
							1, new EducationStructureUnit
							{
								Unit = 1,
								Tasks = DefaultTasks
							}
						},
						{
							2, new EducationStructureUnit
							{
								Unit = 2,
								Tasks = DefaultTasks
							}
						},
						{
							3, new EducationStructureUnit
							{
								Unit = 3,
								Tasks = DefaultTasks
							}
						},
						{
							4, new EducationStructureUnit
							{
								Unit = 4,
								Tasks = DefaultTasks
							}
						},
						{
							5, new EducationStructureUnit
							{
								Unit = 5,
								Tasks = DefaultTasks
							}
						},
					}
				}
			}
		};

		private static Dictionary<int, EducationStructureTask> DefaultTasks => new()
		{
			{1, new EducationStructureTask(1, EducationTaskType.Text)},
			{2, new EducationStructureTask(2, EducationTaskType.Test)},
			{3, new EducationStructureTask(3, EducationTaskType.Video)},
			{4, new EducationStructureTask(4, EducationTaskType.Case)},
			{5, new EducationStructureTask(5, EducationTaskType.TrueFalse)},
			{6, new EducationStructureTask(6, EducationTaskType.Game)}
		};
	}
}