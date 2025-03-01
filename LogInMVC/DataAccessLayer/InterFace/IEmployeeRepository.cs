using Infrastructure.DataAccess.InterFace;
using ModelLayer.Entities;

namespace DataAccessLayer.InterFace
{
    public interface IEmployeeRepository:IRepository<Employee,int>
    {
        Task<List<Employee>> GetByCityAndCountry(string city, string country);
        Task<Employee> LogInAsync(string userName, string password);
    }
}
