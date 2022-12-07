using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using WpfEmployeesOrders.Data;
using WpfEmployeesOrders.Models;
using WpfEmployeesOrders.ViewModels;
using WpfEmployeesOrders.Views;

namespace WpfEmployeesOrders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDataDivision _dataDivision;
        private readonly IDataEmployee _dataEmployee;
      
        public MainWindow(IDataDivision dataDivision, IDataEmployee dataEmployee)
        {
            _dataDivision = dataDivision;
            _dataEmployee = dataEmployee;
            InitializeComponent();
            var viewModel = new MainViewModel( _dataDivision, _dataEmployee);
            DataContext = viewModel;
            EmployeesGrid.DataContext = _dataEmployee.GetEmployees();
            DivisionGrid.DataContext = _dataDivision.GetDivisions();
      
        }

        private void GetChiefBtn(object sender, RoutedEventArgs e)
        {
            var btn = ((Button)sender);
            var btnContent = btn.Content.ToString();
            if (btnContent != null)
            { Employee employee = _dataEmployee.GetEmployeeByName(btnContent);
              EmployeeWindow window = new(employee, _dataDivision);
                window.Show();
            }
            else { MessageBox.Show("Сотрудник не выбран"); }
            

        }
    }
}
