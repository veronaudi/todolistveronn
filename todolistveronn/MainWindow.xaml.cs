using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace todolistveronn
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Taskl> Tasks { get; set; } = new ObservableCollection<Taskl>();
        public MainWindow()
        {
            InitializeComponent();
            tgTodo.ItemsSource = Tasks;
        }

        private void CreateTask_Click(object sender, RoutedEventArgs e)
        {
            var window = new CreateWindow();
            if (window.ShowDialog() == true)  // проверяем, нажата ли кнопка "Создать"
            {
                Tasks.Add(window.NewTask);    // добавляем новую задачу в ObservableCollection
            }
        }
        private void ToggleCompleted_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is Taskl task)
            {
                task.IsCompleted = !task.IsCompleted;
            }
        }

    }
}

