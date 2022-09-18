using Microsoft.EntityFrameworkCore;
using OnlyVacancyApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyVacancyApp.Services
{
    public class DepCountService: IDepCountService
    {
        private readonly AppDbContext _db;

        public DepCountService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<DepartmentCountInfo> GetInfoAsync(string department)
        {
            DepartmentCountInfo result = new DepartmentCountInfo();
            var resultList = await _db.OrgStructures.Where(x => x.Department == department).ToListAsync();

            if (resultList.Any())
            {
                result.PositinonsNumber = resultList.Select(x => x.Position).Distinct().Count();
                result.EmployeesNumber = resultList.Select(x => x.User).Distinct().Count();
            }
            return result;
        }
    }
}
