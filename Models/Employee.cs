using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Windows.Navigation;

namespace WpfEmployeesOrders.Models
{
    public partial class Employee:ObservableObject
    {

        [ObservableProperty] private int _employeeId;

        [ObservableProperty] private string? _lastName;

        [ObservableProperty] private string? _firstName;

        [ObservableProperty] private string? _surName;

        [ObservableProperty] private string? _dateOfBirthday;

        [ObservableProperty] private Gender _genderEmployee;
       
        [ObservableProperty] private string? _divisionName;
        public override string ToString()
        {
            return $"{LastName} {FirstName} {SurName}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Employee employee)
            return _lastName == employee._lastName && FirstName == employee.FirstName && SurName == employee.SurName
                    && DateOfBirthday == employee.DateOfBirthday && GenderEmployee == employee.GenderEmployee;
            return false;
        }

        public override int GetHashCode() => EmployeeId.GetHashCode();
        



    }

    public enum Gender
    {
        М,
        Ж
    }
}
