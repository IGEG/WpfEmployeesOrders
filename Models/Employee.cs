using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.ComponentModel;
using System.Windows.Navigation;

namespace WpfEmployeesOrders.Models
{
    public partial class Employee:ObservableObject,IDataErrorInfo
    {

        [ObservableProperty] private int _employeeId;

        [ObservableProperty] private string? _lastName;

        [ObservableProperty] private string? _firstName;

        [ObservableProperty] private string? _surName;

        [ObservableProperty] private string? _dateOfBirthday;

        [ObservableProperty] private Gender _genderEmployee;
       
        [ObservableProperty] private string? _divisionName;

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "LastName":
                        if (LastName?.Length <= 1)
                        {
                            error = "Укажите фамилию";
                        }
                        break;

                    case "FirstName":
                        if (FirstName?.Length <= 1)
                        {
                            error = "Укажите имя";
                        }
                        break;
                    case "SurName":
                        if (SurName?.Length <= 1)
                        {
                            error = "Укажите отчество";
                        }
                        break;
                    case "DateOfBirthday":
                        if (DateOfBirthday?.Length <= 1)
                        {
                            error = "Укажите дату рождения";
                        }
                        break;
                    case "DivisionName":
                        if (DivisionName?.Length <= 1)
                        {
                            error = "Укажите название отдела";
                        }
                        break;
                }
                return error;
            }
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {SurName}";
        }
        public override bool Equals(object? obj)
        {
            Employee? employee = obj as Employee;
            return  employee!=null && LastName == employee.LastName && FirstName == employee.FirstName && SurName == employee.SurName
                    && DateOfBirthday == employee.DateOfBirthday && GenderEmployee == employee.GenderEmployee;
           
        }

        public override int GetHashCode() => EmployeeId.GetHashCode();
        



    }

    public enum Gender
    {
        М,
        Ж
    }
}
