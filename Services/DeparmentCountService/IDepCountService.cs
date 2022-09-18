using OnlyVacancyApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyVacancyApp.Services
{
    public interface IDepCountService
    {
        Task<DepartmentCountInfo> GetInfoAsync(string department);
    }
}
