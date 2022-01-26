using System.Linq;

namespace Service.Core.Client.Education
{
	public static class EducationHelper
	{
		public const int TutorialCount = 9;

		public static (EducationTutorial Tutorial, int Unit, int Task)[] GetProjections() => EducationStructure.Tutorials.Values
			.SelectMany(tutorial => tutorial.Units
				.SelectMany(unit => unit.Value.Tasks
					.Select(task => (tutorial.Tutorial, unit.Value.Unit, task.Value.Task))))
			.ToArray();

		public static EducationStructureTutorial GetTutorial(EducationTutorial tutorial) =>
			EducationStructure.Tutorials.TryGetValue(tutorial, out EducationStructureTutorial value) ? value : null;

		public static EducationStructureUnit GetUnit(EducationTutorial tutorial, int unit)
		{
			EducationStructureTutorial structureTutorial = GetTutorial(tutorial);
			return structureTutorial == null
				? null
				: structureTutorial.Units.TryGetValue(unit, out EducationStructureUnit value) ? value : null;
		}

		public static EducationStructureTask GetTask(EducationTutorial tutorial, int unit, int task)
		{
			EducationStructureUnit structureUnit = GetUnit(tutorial, unit);
			return structureUnit == null
				? null
				: structureUnit.Tasks.TryGetValue(task, out EducationStructureTask value) ? value : null;
		}

		public static (EducationStructureUnit unit, EducationStructureTask task)? GetUnitTask(EducationTutorial tutorial, int unit, int task)
		{
			EducationStructureUnit structureUnit = GetUnit(tutorial, unit);
			if (structureUnit == null)
				return null;

			if (!structureUnit.Tasks.TryGetValue(task, out EducationStructureTask value))
				return null;

			return (structureUnit, value);
		}
	}
}