using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todolistveronn
{
    public class Task
    {
        private string title;
        private bool isCompleted;
        private DateTime dueDate;
        private string category;
        private int priority;

        public Task(string title, DateTime dueDate, string category, int priority)
        {
            this.title = title;
            this.dueDate = dueDate;
            this.category = category;
            this.priority = priority;
            this.isCompleted = false;
        }
        public Task()
        {
            this.title = "Новая задача";
            this.dueDate = DateTime.Now;
            this.category = "Общее";
            this.priority = 1;
            this.isCompleted = false;
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public bool IsCompleted
        {
            get { return isCompleted; }
            set { isCompleted = value; }
        }
        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }
        public override string ToString()
        {
            string status = isCompleted ? "[✓]" : "[ ]";
            return $"{status} {title} | {dueDate:dd.MM.yyyy} | {category} | Приоритет: {priority}";
        }
    }
}
          