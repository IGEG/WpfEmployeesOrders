using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfEmployeesOrders.Models
{
   public partial class Division : ObservableObject, IDataErrorInfo
    {
        [ObservableProperty] private int _id;

        [ObservableProperty] private string? _divisionName;

        [ObservableProperty] private int _employeeId;

        [ObservableProperty] private Employee? _chief;

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "DivisionName":
                        if (DivisionName?.Length <= 3)
                        {
                            error = "Название отдела должно содержать больше 3 букв";
                        }
                        break;
                }
                return error;
            }
        }

        public string Error => throw new NotImplementedException();

        public override string ToString()
        {
            return $"{DivisionName}";
        }


    }
}
