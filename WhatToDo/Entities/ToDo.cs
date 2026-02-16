// model class used for definition of the data structure

namespace WhatToDo.Entities
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // controls for the overdue tasks
        public bool IsOverdue => Status != "Done" && DueDate < DateTime.Now;
    }
}
