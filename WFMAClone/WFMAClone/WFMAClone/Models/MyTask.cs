using System;
using System.Collections.Generic;
using System.Text;

namespace WFMAClone
{
	class MyTask
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string JobId { get; set; }
		public string Status { get; set; }
		public string JobType { get; set; }
		public int TaskPriority { get; set; }
		public string Type { get; set; }
		public DateTime DueDate { get; set; }
	}

	class TaskList
	{
		public List<MyTask> Tasks { get; set; }
	}
}
