using C__project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__project.Repository
{
    public interface IReposy
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int Id);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(int Id);


    }
}
