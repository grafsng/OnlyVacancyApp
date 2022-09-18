using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyVacancyApp.Services
{
    public interface IOperationService
    {
        Task<List<UserModel>> GetAsync(string parentDepName);

        Task<UserModel> PostAsync(UserModel structure);

        Task<UserModel> PutAsync(UserModel structure);

        Task DeleteAsync(string userName);
    }
}
