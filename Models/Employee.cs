using CommunityToolkit.Mvvm.ComponentModel;
using System;


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
       
        [ObservableProperty] private Division? _division;
        public override string ToString()
        {
            return $"{LastName} {FirstName} {SurName}";
        }


    }

    public enum Gender
    {
        М,
        Ж
    }
}
