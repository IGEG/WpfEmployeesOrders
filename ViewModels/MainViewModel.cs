using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using WpfEmployeesOrders.Data;
using WpfEmployeesOrders.Models;
using WpfEmployeesOrders.Views;

namespace WpfEmployeesOrders.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        ApplicationContext appContext;
        [ObservableProperty] private ObservableCollection<Employee>? _employeesCollection;
        [ObservableProperty] private ObservableCollection<Division>? _divisionCollection;
        [ObservableProperty] private ObservableCollection<Order>? _ordersCollection;

        //--добавляем нового сотрудникаа--//
        private ICommand? _addEmployeeCommand;
        public ICommand? AddEmployeeCommand { get => _addEmployeeCommand; set => SetProperty(ref _addEmployeeCommand, value); }

        private void AddEmployee()
        {
            EmployeeWindow? employeeWindow = new(new(), appContext);
            if (employeeWindow.ShowDialog() == true)
            {
                Employee newEmployee = employeeWindow.Employee;
                if (EmployeesCollection != null && !EmployeesCollection.Contains(newEmployee))
                {
                    appContext.Employees.Add(newEmployee);
                    appContext.SaveChanges();
                }
                else MessageBox.Show($"Сотрудник уже есть в базе данных");
           
            }
        }

        //--редактирование данных выбранного сотрудника--//
        private ICommand? _editEmployeeCommand;
        public ICommand? EditEmployeeCommand { get => _editEmployeeCommand; set => SetProperty(ref _editEmployeeCommand, value); }
        private void EditEmployee(Employee? _selectedItem)
        {
            Employee? employee = _selectedItem as Employee;
            if (employee == null) { MessageBox.Show("Сотрудник не выбран!"); return; }
            EmployeeWindow employeeWindow = new (employee, appContext);
            if (employeeWindow.ShowDialog() == true)
            {
                Employee newEmployee = employeeWindow.Employee;
                    appContext.Entry(newEmployee).State = EntityState.Modified;
                    appContext.SaveChanges();
            }

        }


        //--удаляем выбранного сотрудника--//
        private ICommand? _deleteEmployeeCommand;
        public ICommand? DeleteEmployeeCommand { get => _deleteEmployeeCommand; set => SetProperty(ref _deleteEmployeeCommand, value); }
        private void DeleteEmployee(Employee? _selectedItem)
        {
            Employee? employee = _selectedItem as Employee;
            if (employee == null) { MessageBox.Show("Сотрудник не выбран!"); return; }
            appContext.Employees.Remove(employee);
            appContext.SaveChanges();


        }

        //--добавляем новый отдел--//
        private ICommand? _addDivisionCommand;
        public ICommand? AddDivisionCommand { get => _addDivisionCommand; set => SetProperty(ref _addDivisionCommand, value); }

        private void AddDivision()
        {
            DivisionWindow divisionWindow = new (new Division(),appContext);
            if (divisionWindow.ShowDialog() == true)
            {
                Division newDivision = divisionWindow.Division;
                if (DivisionCollection != null && !DivisionCollection.Contains(newDivision))
                {
                    appContext.Divisions.Add(newDivision);
                    appContext.SaveChanges();
                }
                else MessageBox.Show($"Отдел с таким названием уже есть в базе данных");

            }
        }

        //--редактирование отдела--//
        private ICommand? _editDivisionCommand;
        public ICommand? EditDivisionCommand { get => _editDivisionCommand; set => SetProperty(ref _editDivisionCommand, value); }
        private void EditDivision(Division? _selectedItem)
        {
            Division? division = _selectedItem as Division;
            if (division == null) { MessageBox.Show("Отдел не выбран!"); return; }
            DivisionWindow divisionWindow = new (division, appContext);
            if (divisionWindow.ShowDialog() == true)
            {
                Division newDivision = divisionWindow.Division;
                appContext.Entry(newDivision).State = EntityState.Modified;
                appContext.SaveChanges();
            }

        }


        //--удаляем отдел--//
        private ICommand? _deleteDivisionCommand;
        public ICommand? DeleteDivisionCommand { get => _deleteDivisionCommand; set => SetProperty(ref _deleteDivisionCommand, value); }
        private void DeleteDivision(Division? _selectedItem)
        {
            Division? division = _selectedItem as Division;
            if (division == null) { MessageBox.Show("Отдел не выбран!"); return; }
            appContext.Divisions.Remove(division);
            appContext.SaveChanges();


        }

        public MainViewModel( ApplicationContext applicationContext)
        {
            appContext = applicationContext;
            appContext.Employees.Load();
            EmployeesCollection = appContext.Employees.Local.ToObservableCollection();
            appContext.Divisions.Load();
            DivisionCollection = appContext.Divisions.Local.ToObservableCollection();
            AddEmployeeCommand = new RelayCommand(AddEmployee);
            EditEmployeeCommand = new RelayCommand<Employee>(EditEmployee);
            EditDivisionCommand = new RelayCommand<Division>(EditDivision);
            DeleteEmployeeCommand = new RelayCommand<Employee>(DeleteEmployee);
            DeleteDivisionCommand = new RelayCommand<Division>(DeleteDivision);
            AddDivisionCommand = new RelayCommand(AddDivision);

        }

    }
}
