using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployeesOrders.Data;
using WpfEmployeesOrders.Models;

namespace WpfEmployeesOrders.ViewModels
{
    public partial class EmployeeViewModel : ObservableObject
    {
        ApplicationContext appContext = new ApplicationContext();
        [ObservableProperty] private ObservableCollection<Employee> _employeesCollection;
        public EmployeeViewModel()
        {
            appContext.Employees.Load();
            EmployeesCollection = appContext.Employees.Local.ToObservableCollection();
        }
    }
}
