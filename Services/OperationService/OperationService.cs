using Microsoft.EntityFrameworkCore;
using OnlyVacancyApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyVacancyApp.Services
{
    public class OperationService : IOperationService
    {
        private readonly AppDbContext _db;

        public OperationService(AppDbContext db)
        {
            _db = db;
        }
        public async Task DeleteAsync(string userName)
        {
            if (String.IsNullOrEmpty(userName))
                throw new BadRequestException("Некорректный параметр");

            var query = await _db.OrgStructures.FirstAsync(x=>x.User == userName);

            if (query == null)
                throw new NotFoundException("Информация не найдена"); 
            
            _db.OrgStructures.Remove(query);
            await _db.SaveChangesAsync();
        }

        public async Task<List<UserModel>> GetAsync(string parent)
        {
            if (String.IsNullOrEmpty(parent))
                throw new BadRequestException("Некорректный параметр");

            var query = await _db.OrgStructures.Where(x => x.ParentDepartment == parent).ToListAsync();

            if (!query.Any())
                throw new NotFoundException("Информация не найдена");

            return query;
        }

        public async Task<UserModel> PostAsync(UserModel user)
        {
            if (user == null)
                throw new BadRequestException("Некорректный параметр");

            _db.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> PutAsync(UserModel user)
        {
            if (user == null)
                throw new BadRequestException("Некорректный параметр");

            if (!_db.OrgStructures.Any(x => x.User == user.User))
                throw new NotFoundException("Информация не найдена");

            _db.Update(user);
            await _db.SaveChangesAsync();
            return user;
        }
    }
}
