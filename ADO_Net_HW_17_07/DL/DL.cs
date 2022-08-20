using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO_Net_HW_17_07.EmployeeModel;
using System.Data.Entity.Core.Objects;

namespace ADO_Net_HW_17_07.DL
{
    internal class DL
    {
        public static class Employee
        {
            public static int Add(Model newEmpl)
            {
                using (var db = new CompanyDBEntities())
                {
                    ObjectParameter newEmp_ID = new ObjectParameter("EmployeeID", 0);
                    db.stp_EmployeeAdd(
                        firstName: newEmpl.FirstName,
                        lastName: newEmpl.LastName,
                        birthDate: newEmpl.BirthDate,
                        positionID: newEmpl.PositionID,
                        employeeID: newEmp_ID
                        ); ;
                    return (int)newEmp_ID.Value;

                }
            }

            public static IEnumerable<Model> ALL()
            {
                using (var db = new CompanyDBEntities())
                {
                    List<Model> employees = new List<Model>();
                    var res = db.stp_EmployeeALL().ToList();
                    foreach (var item in res)
                    {
                        Model tmp = new Model();
                        tmp.EmployeeID = item.EmployeeID;
                        tmp.FirstName = item.FirstName;
                        tmp.LastName = item.LastName;
                        tmp.BirthDate = item.BirthDate;
                        tmp.PositionID = item.PositionID;
                        tmp.Salary = item.Salary;
                        employees.Add(tmp);
                    }
                    return employees;
                }
            }

            public static void Delete (int empID)
            {
                using (var db = new CompanyDBEntities())
                {
                    db.stp_EmployeeDelete_1(employeeID: empID);
                }
            }

            public static void Update(Model emp)
            {
                using (var db = new CompanyDBEntities())
                {
                    ObjectParameter res= new ObjectParameter("result", 1);
                    db.stp_EmployeeUpdate
                        (employeeID: emp.EmployeeID,
                        firstName: emp.FirstName, lastName: emp.LastName,
                        birthDate: emp.BirthDate,
                        positionID: emp.PositionID,
                        result: res
                        ) ;
                }
            }

            

        }
    }
}
