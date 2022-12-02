﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfEmployeesOrders.Data;
using WpfEmployeesOrders.Models;

namespace WpfEmployeesOrders.Views
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public Employee Employee { get; private set; }
        ApplicationContext applicationContext ;
        public EmployeeWindow(Employee employee, ApplicationContext context)
        {
            applicationContext = context;
            InitializeComponent();
            Employee = employee;
            DataContext = Employee; 
        }
        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string?> divisionNames = new();
            applicationContext.Divisions.Load();
            divisionNames = applicationContext.Divisions.Local.Select(d => d.DivisionName).ToList();
            DivisionComboBox.ItemsSource = divisionNames;
            
        }

        private void DivisionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? divisionName = DivisionComboBox.SelectedItem as string;
            if (divisionName != null)
            Employee.DivisionName = divisionName;
            else MessageBox.Show("Список сотрудников пуст!");
        }
    }
}
