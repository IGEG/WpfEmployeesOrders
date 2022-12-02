using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfEmployeesOrders.Models;
using WpfEmployeesOrders.Views;

namespace WpfEmployeesOrders.Data
{
    public partial class DataDivision : ObservableObject, IDataDivision
    {
        private readonly ApplicationContext _context;

        [ObservableProperty] private ObservableCollection<Division>? _divisionCollection;

        public DataDivision(ApplicationContext context)
        {
            _context = context;
            _context.Divisions.Load();
            DivisionCollection = _context.Divisions.Local.ToObservableCollection();
        }
        public void AddDivision()
        {
            DivisionWindow divisionWindow = new(new Division(), _context);
            if (divisionWindow.ShowDialog() == true)
            {
                Division newDivision = divisionWindow.Division;
                if (DivisionCollection != null && !DivisionCollection.Contains(newDivision))
                {
                    _context.Divisions.Add(newDivision);
                    _context.SaveChanges();
                }
                else MessageBox.Show($"Отдел с таким названием уже есть в базе данных");

            }
        }

        public void DeleteDivision(Division? _selectedItem)
        {
            Division? division = _selectedItem as Division;
            if (division == null) { MessageBox.Show("Отдел не выбран!"); return; }
            _context.Divisions.Remove(division);
            _context.SaveChanges();

        }

        public void EditDivision(Division? _selectedItem)
        {
            Division? division = _selectedItem as Division;
            if (division == null) { MessageBox.Show("Отдел не выбран!"); return; }
            DivisionWindow divisionWindow = new(division, _context);
            if (divisionWindow.ShowDialog() == true)
            {
                Division newDivision = divisionWindow.Division;
                _context.Entry(newDivision).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
