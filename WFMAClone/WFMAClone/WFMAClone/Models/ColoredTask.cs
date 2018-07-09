using System;
using System.Collections.Generic;
using System.Text;

namespace WFMAClone.Models
{
	class ColoredTask : MyTask
	{
		public string Color {get;set;}
		public ColoredTask(MyTask task)
		{
			Id = task.Id;
			Name = task.Name;
			JobId = task.JobId;
			Status = task.Status;
			JobType = task.JobType;
			TaskPriority = task.TaskPriority;
			DueDate = task.DueDate.Date;

			if (Status.Equals("new"))
			{
				Color = "Lime";
			}
			else if(Status.Equals("accepted")){
				Color = "Orange";
			}
			else if (Status.Equals("downloaded"))
			{
				Color = "Red";
			}
			else if(Status.Equals("not downloaded"))
			{
				Color = "Blue";
			}
			else
			{
				Color = "Black";
			}
		}
    }
}
