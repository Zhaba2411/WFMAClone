using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WFMAClone
{
    public class MyTask
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public DateTime createdAt { get; set; }
        public int AcceptedBy { get; set; }
        public DateTime AcceptedAt { get; set; }
        public int FinalizedBy { get; set; }
        public DateTime FinalizedAt { get; set; }

        public Job Job { get; set; }
        public TaskType TaskType { get; set; }
        public List<WebPart> WebParts { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Document> Documents { get; set; }

        public DateTime dueDate { get; set; }
    }

    public class Job
    {
        public int Id { get; set; }
        public int JobTypeId { get; set; }
        public string JobTypeName { get; set; }
        public string JobTypeDescription { get; set; }
        public string CreateFormConfiguration { get; set; }
        public string CreateFormValues { get; set; }
        public string RelatedMapLayerSelection { get; set; }
    }

    public class TaskType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AssignableTo { get; set; }
        public List<TaskWebParts> WebParts { get; set; }
    }

    // part of TaskType
    public class TaskWebParts
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public bool IsDefault { get; set; }
        public string ViewMode { get; set; }
        public TaskWebPart WebPart { get; set; }
    }

    // part of TaskType
    public class TaskWebPart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TabName { get; set; }
        public bool IsSystemWebPart { get; set; }
        public string Description { get; set; }
        public string Configuration { get; set; }
    }

    public class WebPart
    {
        public int Id { get; set; }
        public int WebPartId { get; set; }
        // TODO - ??? {} ?
        public Object Values { get; set; }
    }

    public class Comment
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public string WorkerName { get; set; }
        public DateTime DateEntered { get; set; }
        public DateTime DateEdited { get; set; }
        // TODO - renamed "Comment" (cant be same as class name)
        [JsonProperty("comment")]
        public string CommentText { get; set; }
        public string CommentType { get; set; }
        public string ContextId { get; set; }
		public string Initials { get; set; }
	}

    public class Document
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Woid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OriginalFileName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public string MimeType { get; set; }
        public string LocationId { get; set; }
        public int TaskId { get; set; }
        public string TaskPublicId { get; set; }
        public int DocumentTypeId { get; set; }
        public string DownloadUrl { get; set; }
    }

}
