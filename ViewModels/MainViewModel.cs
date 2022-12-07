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
        private readonly IDataDivision _dataDivision;
        private readonly IDataEmployee _dataEmployee;
        
        #region методы CRUD Employee
        //--добавляем нового сотрудникаа--//
        private ICommand? _addEmployeeCommand;
        public ICommand? AddEmployeeCommand { get => _addEmployeeCommand; set => SetProperty(ref _addEmployeeCommand, value); }

        private void AddEmployee()
        {
            _dataEmployee.AddEmployee();
        }

        //--редактирование данных выбранного сотрудника--//
        private ICommand? _editEmployeeCommand;
        public ICommand? EditEmployeeCommand { get => _editEmployeeCommand; set => SetProperty(ref _editEmployeeCommand, value); }
        private void EditEmployee(Employee? _selectedItem)
        {
            _dataEmployee.EditEmployee(_selectedItem);
        }


        //--удаляем выбранного сотрудника--//
        private ICommand? _deleteEmployeeCommand;
        public ICommand? DeleteEmployeeCommand { get => _deleteEmployeeCommand; set => SetProperty(ref _deleteEmployeeCommand, value); }
        private void DeleteEmployee(Employee? _selectedItem)
        {
            _dataEmployee.DeleteEmployee(_selectedItem);
        }
        #endregion

        #region методы CRUD Division
        //--добавляем новый отдел--//
        private ICommand? _addDivisionCommand;
        public ICommand? AddDivisionCommand { get => _addDivisionCommand; set => SetProperty(ref _addDivisionCommand, value); }

        private void AddDivision()
        {
            _dataDivision.AddDivision();
        }

        //--редактирование отдела--//
        private ICommand? _editDivisionCommand;
        public ICommand? EditDivisionCommand { get => _editDivisionCommand; set => SetProperty(ref _editDivisionCommand, value); }
        private void EditDivision(Division? _selectedItem)
        {
            _dataDivision.EditDivision(_selectedItem);

        }


        //--удаляем отдел--//
        private ICommand? _deleteDivisionCommand;
        public ICommand? DeleteDivisionCommand { get => _deleteDivisionCommand; set => SetProperty(ref _deleteDivisionCommand, value); }
        private void DeleteDivision(Division? _selectedItem)
        {
            _dataDivision.DeleteDivision(_selectedItem);
        }
        #endregion
        public MainViewModel(IDataDivision dataDivision, IDataEmployee dataEmployee)
        {
            _dataDivision = dataDivision;
            _dataEmployee = dataEmployee;

            AddEmployeeCommand = new RelayCommand(AddEmployee);
            EditEmployeeCommand = new RelayCommand<Employee>(EditEmployee);
            EditDivisionCommand = new RelayCommand<Division>(EditDivision);
            DeleteEmployeeCommand = new RelayCommand<Employee>(DeleteEmployee);
            DeleteDivisionCommand = new RelayCommand<Division>(DeleteDivision);
            AddDivisionCommand = new RelayCommand(AddDivision);

        }

    }
}
