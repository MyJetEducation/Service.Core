namespace Service.Core.Domain.Models.Education
{
	public class EducationStructureTask
	{
		public EducationStructureTask(int task, EducationTaskType taskType)
		{
			Task = task;
			TaskType = taskType;
		}

		public int Task { get; set; }

		public EducationTaskType TaskType { get; set; }
	}
}