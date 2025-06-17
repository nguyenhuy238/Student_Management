using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DemoStudent.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoStudent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApContext context = new();
        public MainWindow()
        {
            InitializeComponent();
            LoadCourse();   
        }
        private void LoadCourse()
        {
            var students = context.Students.ToList();
            StudentCbBox.ItemsSource = students;
            StudentCbBox.DisplayMemberPath = "Roll";
            StudentCbBox.SelectedValuePath = "StudentId";

        }

        private void StudentCbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StudentCbBox.SelectedValue is int studentId)
            {
                var result = context.Students
                    .Where(s => s.StudentId == studentId)
                    .ToList();
                StudentGrid.ItemsSource = result;
            }
        }
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            StudentCbBox.SelectedIndex = -1;
            StudentGrid.ItemsSource = null;
        }
    }
}