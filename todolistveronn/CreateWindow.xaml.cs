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

    private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TaskTitle.Text?.Trim();
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Введите название задачи!");
                return;
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