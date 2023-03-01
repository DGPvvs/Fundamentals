using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Company_Roster
{
	class Employee : IComparable<Employee>
	{
	    private string name;
	    private decimal salary;
	    
		public Employee(string name, decimal salary)
		{
			this.Name = name;
			this.Salary = salary;
		}
		
		public string Name
		{
			get => this.name;
			set => this.name = value;
		}
		
		public decimal Salary
		{
			get => this.salary;
			set => this.salary = value;
		}
		
		public int CompareTo(Employee other)
		{
		    if(other == null)
		    {
		        return 1;
		    }
		    
		    return this.Salary.CompareTo(other.Salary);
        }
        
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Employee e = (Employee)obj;
                return this.Name == e.Name;
            }
        }
        
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

		public override string ToString() => $"{Name} {Salary:F2}";
	}// class Employee

	class Department
	{
		private string name;
		private HashSet<Employee> employees; 
		
		public Department(string departmentName)
		{
			this.Name = departmentName;
			employees = new HashSet<Employee>(); 
		}

		public string Name
		{
			get => this.name;
			set => this.name = value;
		}
		
		public decimal AverageSalary => this.employees.Average(e => e.Salary);
		
		public void AddEmployee(Employee employee)
		{
		    this.employees.Add(employee);
		}
		
		public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Department d = (Department)obj;
                return this.Name == d.Name;
            }
        }
        
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
        
        public override string ToString() => $"Highest Average Salary: {this.Name}{Environment.NewLine}{string.Join(Environment.NewLine, this.employees.OrderByDescending(e => e.Salary))}";
	}// class Department

	class CompanyRoster
	{
		static void Main(string[] args)
		{
			HashSet<Department> departaments = new HashSet<Department>();

			int numEmployers = int.Parse(Console.ReadLine());

			for (int i = 0; i < numEmployers; i++)
			{
				string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
				
				string employeeName = command[0];
				decimal employeeSalary = decimal.Parse(command[1]);
				string departmentName = command[2];
				
				Department department = new Department(departmentName);
				
				departaments.Add(department);
				departaments.First(d => d.Name == departmentName).AddEmployee(new Employee(employeeName, employeeSalary));
			}
			
			Console.WriteLine(departaments.OrderByDescending(d => d.AverageSalary).Take(1).First().ToString());
		}
	}
}