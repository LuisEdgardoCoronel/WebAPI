﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaEf.Model
{
    public class TaskModel
    {
        //[Key]
        public Guid TaskId { get; set; }
        //[ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }
        //[Required]
        //[MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }

        public Priority PriorityTask { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeadLine { get; set; }
        public virtual Category Category { get; set; }
        [NotMapped]
        public string Summary { get; set; }
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
