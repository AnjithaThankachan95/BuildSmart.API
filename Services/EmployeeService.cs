using System.Collections.Generic;
using System.Linq;
using BuildSmart.API.Data;
using BuildSmart.API.DTOs;
using BuildSmart.API.Models;
using BuildSmart.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BuildSmart.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            return _context.Employees
                .Select(e => new EmployeeDto
                {
                    EmployeeId = e.EmployeeId,
                    FullName = e.FullName,
                    Role = e.Role,
                    Email = e.Email
                }).ToList();
        }

        public EmployeeDto? GetById(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp == null) return null;

            return new EmployeeDto
            {
                EmployeeId = emp.EmployeeId,
                FullName = emp.FullName,
                Role = emp.Role,
                Email = emp.Email
            };
        }

        public EmployeeDto Create(EmployeeDto dto)
        {
            var emp = new Employee
            {
                FullName = dto.FullName,
                Role = dto.Role,
                Email = dto.Email
            };

            _context.Employees.Add(emp);
            _context.SaveChanges();

            dto.EmployeeId = emp.EmployeeId;
            return dto;
        }

        public EmployeeDto? Update(int id, EmployeeDto dto)
        {
            var emp = _context.Employees.Find(id);
            if (emp == null) return null;

            emp.FullName = dto.FullName;
            emp.Role = dto.Role;
            emp.Email = dto.Email;

            _context.SaveChanges();
            return dto;
        }

        public bool Delete(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp == null) return false;

            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return true;
        }
    }
}
