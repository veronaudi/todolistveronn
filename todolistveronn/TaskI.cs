using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todolistveronn
{
    public class Taskl : INotifyPropertyChanged
    {
        private string title;
        private bool isCompleted;
        private DateTime dueDate;
        private string category;
        private int priority;

        public Taskl(string title, DateTime dueDate, string category, int priority)
        {
            this.title = title;
            this.dueDate = dueDate;
            this.category = category;
            this.priority = priority;
            this.isCompleted = false;
        }
        public Taskl()
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
            get => isCompleted;
            set
            {
                if (isCompleted != value)
                {
                    isCompleted = value;
                    OnPropertyChanged(nameof(IsCompleted));
                    OnPropertyChanged(nameof(Status)); // важно, чтобы Status тоже обновился
                }
            }
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
        public string Status => IsCompleted ? "[✓]" : "[ ]";
        public override string ToString()
        {
            string status = isCompleted ? "[✓]" : "[ ]";
            return $"{status} {title} | {dueDate:dd.MM.yyyy} | {category} | Приоритет: {priority}";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
          