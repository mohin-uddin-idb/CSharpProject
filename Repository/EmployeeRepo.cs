using C__project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__project.Repository
{
    public class EmployeeRepo : IReposy
    {
        public void Delete(int Id)
        {
            Employee employee=EmployeeInfo.Employeelist.FirstOrDefault(x=>x.EmpId==Id);
            EmployeeInfo.Employeelist.Remove(employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            return EmployeeInfo.Employeelist;
        }

        public Employee GetById(int Id)
        {
            Employee employee= EmployeeInfo.Employeelist.FirstOrDefault(x=>x.EmpId==Id);
            return employee;
        }

        public void Insert(Employee employee)
        {
            EmployeeInfo.Employeelist.Add(employee);
        }

        public void Update(Employee employee)
        {
            Employee _employee=EmployeeInfo.Employeelist.FirstOrDefault(x=> x.EmpId==employee.EmpId);
            if(employee.EmpName != null)
            {
                _employee.EmpName = employee.EmpName;
            }
            if(employee.empAge != 0)
            {
                _employee.empAge= employee.empAge;
            }
        }
    }
}
