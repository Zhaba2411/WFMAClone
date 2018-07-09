using System;
using System.Collections.Generic;
using System.Text;

namespace WFMAClone.Models
{
	class ColoredTask : MyTaskList
	{
		public string Color {get;set;}
        public string ShortDate { get; set; }
		public ColoredTask(MyTaskList task)
		{
			Id = task.Id;
			Name = task.Name;
			JobId = task.JobId;
			Status = task.Status;
			JobType = task.JobType;
			TaskPriority = task.TaskPriority;
			DueDate = task.DueDate.Date;
            var temp = task.DueDate.Date;

            ShortDate = temp.ToString("dd.M.yyyy");

			if (Status.Equals("new")) {
				Color = "Lime";
			}
			else if(Status.Equals("accepted")) {
				Color = "Orange";
			}
			else if (Status.Equals("downloaded")) {
				Color = "Red";
			}
			else if(Status.Equals("not downloaded")) {
				Color = "Blue";
			}
			else {
				Color = "Black";
			}
		}
    }
}
