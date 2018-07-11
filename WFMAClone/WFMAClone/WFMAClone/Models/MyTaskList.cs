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
		public string Color
		{
			get
			{
				if (Status.Equals("new"))
				{
					return "Red";
				}
				else if (Status.Equals("accepted"))
				{
					return "Orange";
				}
				else if (Status.Equals("downloaded"))
				{
					return "Lime";
				}
				else if (Status.Equals("not downloaded"))
				{
					return "Blue";
				}
				else
				{
					return "Black";
				}
			}
		}
		public string ShortDate
		{
			get
			{
				var temp = DueDate.Date;

				return temp.ToString("dd.M.yyyy");
			}
		}
	}

	class MyTaskList
	{
		public List<MyTask> Tasks { get; set; }
	}
}
