using ADO_Net_HW_17_07.EmployeeModel;
using ADO_Net_HW_17_07.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ADO_Net_HW_17_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Model newEmp = new Model()
            {
                FirstName = "New",
                LastName = "Employee",
                BirthDate = new DateTime(2022, 10, 20),
                EmployeeID = 1009,
                PositionID = 1,
                Salary = 5550505

            };

            IEnumerable<Model> emp = DL.DL.Employee.ALL();
            foreach (var item in emp)
            {
                WriteLine($"{item.EmployeeID}\t{item.LastName}\t\t{item.FirstName}\t{item.PositionID}\t{item.Salary}");

            }
            //DL.DL.Employee.Update(newEmp);
            //DL.DL.Employee.Add(newEmp);
            //DL.DL.Employee.Delete(1010);
        }
    }
}
