using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;
using WpfEmployeesOrders.Data;
using WpfEmployeesOrders.Models;

namespace WpfEmployeesOrders.Views
{
    /// <summary>
    /// Interaction logic for DivisionWindow.xaml
    /// </summary>
    public partial class DivisionWindow : Window
    {
        ApplicationContext applicationContext;
        public Division Division { get; private set; }

        public DivisionWindow(Division division, ApplicationContext context)
        {
            applicationContext = context;
            InitializeComponent();
            Division = division;
            DataContext = Division;
          
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void LoadedEmployees(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Employee> employeesName = new();
            applicationContext.Employees.Load();
            employeesName = applicationContext.Employees.Local.ToObservableCollection();
            EmplComboBox.ItemsSource = employeesName;
            EmplComboBox.Text = employeesName.ToString();
        }

        private void EmplComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee? employee = EmplComboBox.SelectedItem as Employee;
            if (employee != null)
            {
                Division.Chief = employee;
            }
            else MessageBox.Show("Список сотрудников пуст!");

        }
    }
}

