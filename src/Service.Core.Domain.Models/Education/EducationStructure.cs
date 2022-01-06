using System.Collections.Generic;
using System.Linq;

namespace Service.Core.Domain.Models.Education
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
								Tasks = new Dictionary<int, EducationStructureTask>
								{
									{1, new EducationStructureTask(1, EducationTaskType.Text)},
									{2, new EducationStructureTask(2, EducationTaskType.Test)},
									{3, new EducationStructureTask(3, EducationTaskType.Case)},
									{4, new EducationStructureTask(4, EducationTaskType.TrueFalse)},
									{5, new EducationStructureTask(5, EducationTaskType.Game)}
								}
							}
						},
						{
							2, new EducationStructureUnit
							{
								Unit = 2,
								Tasks = new Dictionary<int, EducationStructureTask>
								{
									{1, new EducationStructureTask(1, EducationTaskType.Text)},
									{2, new EducationStructureTask(2, EducationTaskType.Test)},
									{3, new EducationStructureTask(3, EducationTaskType.Case)},
									{4, new EducationStructureTask(4, EducationTaskType.TrueFalse)},
									{5, new EducationStructureTask(5, EducationTaskType.Game)}
								}
							}
						},
						{
							3, new EducationStructureUnit
							{
								Unit = 3,
								Tasks = new Dictionary<int, EducationStructureTask>
								{
									{1, new EducationStructureTask(1, EducationTaskType.Text)},
									{2, new EducationStructureTask(2, EducationTaskType.Test)},
									{3, new EducationStructureTask(3, EducationTaskType.Case)},
									{4, new EducationStructureTask(4, EducationTaskType.TrueFalse)},
									{5, new EducationStructureTask(5, EducationTaskType.Game)}
								}
							}
						},
						{
							4, new EducationStructureUnit
							{
								Unit = 4,
								Tasks = new Dictionary<int, EducationStructureTask>
								{
									{1, new EducationStructureTask(1, EducationTaskType.Text)},
									{2, new EducationStructureTask(2, EducationTaskType.Test)},
									{3, new EducationStructureTask(3, EducationTaskType.Case)},
									{4, new EducationStructureTask(4, EducationTaskType.TrueFalse)},
									{5, new EducationStructureTask(5, EducationTaskType.Game)}
								}
							}
						},
						{
							5, new EducationStructureUnit
							{
								Unit = 5,
								Tasks = new Dictionary<int, EducationStructureTask>
								{
									{1, new EducationStructureTask(1, EducationTaskType.Text)},
									{2, new EducationStructureTask(2, EducationTaskType.Test)},
									{3, new EducationStructureTask(3, EducationTaskType.Case)},
									{4, new EducationStructureTask(4, EducationTaskType.TrueFalse)},
									{5, new EducationStructureTask(5, EducationTaskType.Game)}
								}
							}
						},
					}
				}
			}
		};
	}
}