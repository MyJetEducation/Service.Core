﻿using System.Collections.Generic;

namespace Service.Core.Domain.Models.Education
{
	public class EducationStructureTutorial
	{
		public EducationTutorial Tutorial { get; set; }

		public IDictionary<int, EducationStructureUnit> Units { get; set; }
	}
}