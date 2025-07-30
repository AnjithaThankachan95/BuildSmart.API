using BuildSmart.API.DTOs;

namespace BuildSmart.API.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAll();
        EmployeeDto? GetById(int id);
        EmployeeDto Create(EmployeeDto dto);
        EmployeeDto? Update(int id, EmployeeDto dto);
        bool Delete(int id);
    }
}
