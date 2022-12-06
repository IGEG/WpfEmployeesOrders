using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployeesOrders.Models;

namespace WpfEmployeesOrders.Data
{
    public interface IDataEmployee
    {
        void AddEmployee();
        void EditEmployee(Employee? employee);
        void DeleteEmployee(Employee? employee);
        ObservableCollection<Employee> GetEmployees();
    }
}
