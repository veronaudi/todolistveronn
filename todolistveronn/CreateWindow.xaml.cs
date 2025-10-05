using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Shell;

namespace todolistveronn
{
    public partial class CreateWindow : Window
    {
        public Taskl NewTask { get; private set; }
        public CreateWindow()
        {
            InitializeComponent();
            DueDatePicker.SelectedDate = DateTime.Now;
        }

        private void AddSubTask_Click(object sender, RoutedEventArgs e)
        {
            var tb = new TextBox
            {
                Height = 25,
                Margin = new Thickness(20, 2, 0, 2), // отступ слева, чтобы показать вложенность
                Text = "Новая подзадача"
            };
            SubTasksPanel.Children.Add(tb);
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TaskTitle.Text?.Trim();
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Введите название задачи!");
                return;
            }
            foreach (var child in SubTasksPanel.Children)
            {
                if (child is TextBox tb && !string.IsNullOrWhiteSpace(tb.Text))
                {
                    NewTask.SubTasks.Add(new Taskl(tb.Text.Trim(), NewTask.DueDate, NewTask.Category, NewTask.Priority));
                }
            }

            string category = CategoryTextBox.Text?.Trim() ?? "Общее";
            DateTime due = DueDatePicker.SelectedDate ?? DateTime.Now;
            int priority = PriorityComboBox.SelectedIndex + 1;

            NewTask = new Taskl(title, due, category, priority);
            DialogResult = true;
            Close();
        }
    }
}