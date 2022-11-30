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
using WpfEmployeesOrders.Models;

namespace WpfEmployeesOrders.Views
{
    /// <summary>
    /// Interaction logic for DivisionWindow.xaml
    /// </summary>
    public partial class DivisionWindow : Window
    {
        public Division Division { get; private set; }     
        public DivisionWindow( Division division)
        {
            InitializeComponent();
            Division = division;
            DataContext = Division;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
