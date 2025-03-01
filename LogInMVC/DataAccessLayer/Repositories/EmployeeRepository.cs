using DataAccessLayer.Context;
using DataAccessLayer.InterFace;
using Infrastructure.DataAccess.Implementation;
using ModelLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository :BaseRepository<Employee,int,ECommerceDbContext>,IEmployeeRepository
    {
        public async Task<List<Employee>> GetByCityAndCountry(string city, string country)
        {
            return await GetAllAsync(x => x.City == city && x.Country == country);
        }

        public async Task<Employee> LogInAsync(string userName, string password)
        {
            return await GetAsync(x => x.UserName == userName && x.Password == password);
        }
    }
}
