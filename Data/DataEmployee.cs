using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfEmployeesOrders.Models;
using WpfEmployeesOrders.Views;

namespace WpfEmployeesOrders.Data
{
    public partial class DataEmployee : ObservableObject, IDataEmployee
    {
        private readonly ApplicationContext _context;
        private readonly IDataDivision _dataDivision;

        [ObservableProperty] private ObservableCollection<Employee>? _employeesCollection;
      
        public DataEmployee(ApplicationContext context, IDataDivision dataDivision)
        {
            _context = context;
            _dataDivision = dataDivision;
            _context.Employees.Load();
            EmployeesCollection = _context.Employees.Local.ToObservableCollection();

        }
        public void AddEmployee()
        {
            EmployeeWindow? employeeWindow = new(new(), _dataDivision);
            if (employeeWindow.ShowDialog() == true)
            {
                Employee newEmployee = employeeWindow.Employee;
                if (EmployeesCollection != null && !EmployeesCollection.Contains(newEmployee))
                {
                    _context.Employees.Add(newEmployee);
                    _context.SaveChanges();
                }
                else MessageBox.Show($"Сотрудник уже есть в базе данных");

            }
        }

        public void DeleteEmployee(Employee? _selectedItem)
        {
            Employee? employee = _selectedItem as Employee;
            if (employee == null) { MessageBox.Show("Сотрудник не выбран!"); return; }
            _context.Employees.Remove(employee);
            _context.SaveChanges();

        }

        public void EditEmployee(Employee? _selectedItem)
        {
            Employee? employee = _selectedItem as Employee;
            if (employee == null) { MessageBox.Show("Сотрудник не выбран!"); return; }
            EmployeeWindow employeeWindow = new(employee, _dataDivision);
            if (employeeWindow.ShowDialog() == true)
            {
                Employee newEmployee = employeeWindow.Employee;
                _context.Entry(newEmployee).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public Employee GetEmployeeByName(string Name)
        {

            Employee emp = _context.Employees.First(n=>n.LastName == Name);
            if (emp != null) return emp;
            else return new();
        }

        public ObservableCollection<Employee> GetEmployees()
        {
            if (EmployeesCollection != null)
                return EmployeesCollection;
            else return new ObservableCollection<Employee>();
        }
    }
}
