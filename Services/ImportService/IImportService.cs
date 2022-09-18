using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyVacancyApp.Services
{
    public interface IImportService
    {
        Task ImportExcelAsync(string fileName);
    }
}
