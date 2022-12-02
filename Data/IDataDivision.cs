using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployeesOrders.Models;

namespace WpfEmployeesOrders.Data
{
    public interface IDataDivision
    {
        void AddDivision();
        void EditDivision(Division? division);
        void DeleteDivision(Division? division);

    }
}
