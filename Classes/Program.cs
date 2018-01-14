using System;
using System.Collections.Generic;

namespace Buddies
{
    class Program
    {
        static void Main(string[] args)
        {
            var kroger = new Company("Kroger", DateTime.Now);
            var walgreens = new Company("Walgreens", DateTime.Now);
            var aldi = new Company("Aldi", DateTime.Now);

            var george = walgreens.AddEmployee("George", "Assistant to the Regional Manager");
            var leon = walgreens.AddEmployee("Leon", "Boss");
            var karen = walgreens.AddEmployee("Karen", "Janitor");

            walgreens.ListEmployees();
            Console.ReadKey();
            

        }
    }

    public class Company
    {
        /*
            Some readonly properties
        */

        public string Name { get; }
        public DateTime CreatedOn { get; }

        // Create a property for holding a list of current employees

        public List<Employee> Employees { get; set; }

        // Create a method that allows external code to add an employee

        public Employee AddEmployee(string employeeName, string employeeTitle)
        {
            var newEmployee = new Employee(employeeName, employeeTitle, this);
            Employees.Add(newEmployee);
            return newEmployee;
        }

        // Create a method that allows external code to remove an employee

        public void RemoveEmployee(Employee employee)
        {
            Employees.Remove(employee);
        }

        /*
            Create a constructor method that accepts two arguments:
                1. The name of the company
                2. The date it was created

            The constructor will set the value of the public properties
        */

        public Company(string name, DateTime createdOn)
        {
            Name = name;
            CreatedOn = createdOn;
            Employees = new List<Employee>();

        }

        public void ListEmployees()
        {
            foreach (var employee in Employees)
            {
                Console.WriteLine($"Name: {employee.Name} Title: {employee.JobTitle}");
            }
        }

    }

    public class Employee
    {
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public DateTime StartDate { get; }
        public Company Company { get; set; }

        public Employee(string employeeName, string employeeTitle, Company company)
        {
            Name = employeeName;
            JobTitle = employeeTitle;
            StartDate = DateTime.Now;
            Company = company;

        }
    }



}
