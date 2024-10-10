using C__project.Entity;
using C__project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayOptions();
            Console.ReadKey();
        }
        public static void DisplayOptions()
        {
            Console.WriteLine("1 Show All Employee");
            Console.WriteLine("2 Insert Employee");
            Console.WriteLine("3 Update Employee");
            Console.WriteLine("4 Delete Employee");
            var index=int.Parse(Console.ReadLine());
            Show(index);
        }
        public static void Show(int index)
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            //index 1 for get all employee Data
            if (index == 1)
            {
                var employeelist = employeeRepo.GetAll();
                if (employeelist.Count() == 0)
                {
                    Console.WriteLine("=======================================");
                    Console.WriteLine("No item found in the list");
                    Console.WriteLine("=======================================");
                    DisplayOptions();
                }
                else
                {
                    foreach (var item in employeeRepo.GetAll())
                    {
                        Console.WriteLine($"EmployeeId:{item.EmpId},EmployeeName:{item.EmpName},Employee Age:{item.empAge}");
                    }
                    Console.WriteLine("=======================================");
                    DisplayOptions();
                }
            }
            else if (index == 2)
            {
                Console.WriteLine("===========================================");
                Console.Write("Name:");
                string name = Console.ReadLine();


                Console.Write("Age:");
                int age = int.Parse(Console.ReadLine());

                int maxId = employeeRepo.GetAll().Any() ? employeeRepo.GetAll().Max(x => x.EmpId) : 0;
                Employee employee = new Employee
                {
                    EmpId = maxId + 1,
                    EmpName = name,
                    empAge = age
                };
                employeeRepo.Insert(employee);
                Console.WriteLine("Data Inserted SuccesFully!!!");
                Console.WriteLine("=======================================");
                DisplayOptions();
            }
            //index 3 for update Data
            else if (index == 3)
            {

                Console.WriteLine("=======================================");
                Console.WriteLine("Entry EmpId no to update data:");
                int id = int.Parse(Console.ReadLine());
                var _employee = employeeRepo.GetById(id);

                if (_employee == null)
                {
                    Console.WriteLine("======================================");
                    Console.WriteLine("Employee Id is invalid!!!");
                    Console.WriteLine("=======================================");
                    DisplayOptions();
                    return;
                }
                else
                {
                    Console.WriteLine($"Update info for Employee Id:{id}");
                    Console.WriteLine("===================================");
                    Console.Write("Name:");
                    string name = Console.ReadLine();


                    Console.Write("Age:");
                    int age = int.Parse(Console.ReadLine());

                    Employee employee = new Employee
                    {
                        EmpId = id,
                        EmpName = name,
                        empAge = age
                    };
                    employeeRepo.Update(employee);
                    Console.WriteLine("data updated successfully");
                    Console.WriteLine("==========================================");
                    DisplayOptions();


                }
            }
            //index 3 for delete Data
            else if (index == 4)
            {
                Console.WriteLine("================================================");
                int id = int.Parse(Console.ReadLine());
                var _employee = employeeRepo.GetById(id);
                if (_employee == null)
                {
                    Console.WriteLine("======================================");
                    Console.WriteLine("Employee Id is invalid!!!");
                    Console.WriteLine("=======================================");
                    DisplayOptions();
                    return;
                }
                else
                {
                    employeeRepo.Delete(id);
                    Console.WriteLine("data  successfully");
                    Console.WriteLine("=======================================");
                    DisplayOptions();
                }
            }


        }
    }
}
