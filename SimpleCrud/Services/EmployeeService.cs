﻿using Microsoft.EntityFrameworkCore;
using SimpleCrud.DataAccess;
using SimpleCrud.DataAccess.Entities;
using SimpleCrud.ViewModels;

namespace SimpleCrud.Services
{
    public class EmployeeService(AppDbContext context)
    {
        public async Task<List<EmployeeViewModel>> GetAllEmployees()
        {
            // Query ke database untuk entitas Employee terlebih dahulu
            var employees = await context.Employees
                .OrderBy(x => x.FullName)
                .ToListAsync(); // Gunakan ToListAsync() di sini

            // Setelah mendapatkan list Employee, map ke EmployeeViewModel
            return employees.Select(x => new EmployeeViewModel
            {
                EmployeeId = x.EmployeeId,
                FullName = x.FullName,
                Department = x.Department,
                DateOfBirth = x.DateOfBirth,
                Age = DateTime.Now.Year - x.DateOfBirth.Year - (DateTime.Now.DayOfYear < x.DateOfBirth.DayOfYear ? 1 : 0),
                PhoneNumber = x.PhoneNumber,
            }).ToList(); // Tidak perlu ToListAsync() di sini
        }

        public bool CreateNewEmployee(EmployeeViewModel mode)
        {
            try
            {
                Employee employee = new Employee()
                {
                    FullName = mode.FullName,
                    Department = mode.Department,
                    DateOfBirth= mode.DateOfBirth,
                    Age= mode.Age,
                    PhoneNumber = mode.PhoneNumber,
                };

                context.Employees.Add(employee);
                var result = context.SaveChanges();
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
