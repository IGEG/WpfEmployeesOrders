using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEmployeesOrders.Models
{
   public partial class Division : ObservableObject
    {
        [ObservableProperty] private int _id;

        [ObservableProperty] private string? _divisionName;

        [ObservableProperty] private int _employeeId;

        [ObservableProperty] private Employee? _chief;


        public override string ToString()
        {
            return $"{DivisionName}";
        }


    }
}
