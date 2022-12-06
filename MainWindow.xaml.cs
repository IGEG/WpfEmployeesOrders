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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfEmployeesOrders.Data;
using WpfEmployeesOrders.ViewModels;

namespace WpfEmployeesOrders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDataDivision _dataDivision;
        private readonly IDataEmployee _dataEmployee;
        private readonly ApplicationContext _applicationContext;
        public MainWindow( ApplicationContext context, IDataDivision dataDivision, IDataEmployee dataEmployee)
        {
            _dataDivision = dataDivision;
            _dataEmployee = dataEmployee;
            _applicationContext = context;
            InitializeComponent();
            var viewModel = new MainViewModel(_applicationContext, _dataDivision, _dataEmployee);
            DataContext = viewModel;
            EmployeesGrid.DataContext = _dataEmployee.GetEmployees();
            DivisionGrid.DataContext = _dataDivision.GetDivisions();
      
        }

    }
}
