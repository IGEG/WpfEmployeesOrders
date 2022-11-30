using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEmployeesOrders.Models
{
    public partial class Order:ObservableObject
    {
        [ObservableProperty] private int _id;

        [ObservableProperty] private string? _orderNum;

        [ObservableProperty] private string? _ProductName;

        [ObservableProperty] private int _employeeId;

        [ObservableProperty] private Employee? _employee;
    }
}
