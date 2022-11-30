﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfEmployeesOrders.Data;
using WpfEmployeesOrders.Models;
using WpfEmployeesOrders.Views;

namespace WpfEmployeesOrders.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        ApplicationContext appContext = new ApplicationContext();
        [ObservableProperty] private ObservableCollection<Employee> _employeesCollection;
        [ObservableProperty] private ObservableCollection<Division> _divisionCollection;


        //--добавляем нового сотрудникаа--//
        private ICommand _addEmployeeCommand;
        public ICommand AddEmployeeCommand { get => _addEmployeeCommand; set => SetProperty(ref _addEmployeeCommand, value); }

        private void AddEmployee()
        {
            EmployeeWindow employeeWindow = new EmployeeWindow(new Employee());
            if (employeeWindow.ShowDialog() == true)
            {
                Employee newEmployee = employeeWindow.Employee;
                appContext.Employees.Add(newEmployee);
                appContext.SaveChanges();
           
            }
        }

         //--добавляем новый отдел--//
        private ICommand _addDivisionCommand;
        public ICommand AddDivisionCommand { get => _addDivisionCommand; set => SetProperty(ref _addDivisionCommand, value); }

        private void AddDivision()
        {
            DivisionWindow divisionWindow = new DivisionWindow(new Division());
            if (divisionWindow.ShowDialog() == true)
            {
                Division newDivision = divisionWindow.Division;
                appContext.Divisions.Add(newDivision);
                appContext.SaveChanges();
           
            }
        }


        public MainViewModel()
        {
            appContext.Employees.Load();
            EmployeesCollection = appContext.Employees.Local.ToObservableCollection();
            appContext.Divisions.Load();
            DivisionCollection = appContext.Divisions.Local.ToObservableCollection();
            AddEmployeeCommand = new RelayCommand(AddEmployee);
            AddDivisionCommand = new RelayCommand(AddDivision);

        }
    }
}
