using MVCCoreAngular.Data;
using MVCCoreAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreAngular.Controllers
{
    public class DbInitializer
    {
        public static void Initialize(EmployeeContext context)
        {
            context.Database.EnsureCreated();

            if (context.Employees.Any())
            {
                return;
            }

            var employees = new Employee[]
            {
            new Employee{EmployeeCode="R001",FirstName="Ryan",LastName="Richard"},
            new Employee{EmployeeCode="D001",FirstName="Bob",LastName="Dylan"},
            new Employee{EmployeeCode="J001",FirstName="Steve",LastName="Jobs"},
            };
            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();
        }

    }
}
