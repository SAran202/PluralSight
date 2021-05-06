using System;
using System.Collections.Generic;

namespace Collection
{
    public class EmployeeComparer : IEqualityComparer<Employee>, IComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return String.Equals(x.Name, y.Name);
        }

        public int GetHashCode(Employee obj)
        {
            return obj.Name.GetHashCode();
        }
        public int Compare(Employee x, Employee y)
        {
            return String.Compare(x.Name, y.Name);
        }
    }

    public class DepartmentCollection : SortedDictionary<string, SortedSet<Employee>>
    {
        public DepartmentCollection Add(string departmentName, Employee employee)
        {
            if(ContainsKey(departmentName))
            {
                Add(departmentName, new SortedSet<Employee>(new EmployeeComparer()));
            }
            this[departmentName].Add(employee);
            return this;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var departments = new DepartmentCollection();

            departments.Add("Engineering",new Employee { Name = "SA" })
                       .Add("Engineering",new Employee { Name = "AS" })
                       .Add("Engineering",new Employee { Name = "S" });

            departments.Add("Sales",new Employee { Name = "SA" })
                       .Add("Sales",new Employee { Name = "AS" })
                       .Add("Sales", new Employee { Name = "AS" });

            foreach (var department in departments)
            {
                Console.WriteLine(department.Key);
                foreach(var employee in department.Value)
                {
                    Console.WriteLine(" "+employee.Name);
                }
            }
        }
    }
}
