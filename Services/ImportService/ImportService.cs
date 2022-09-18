using OfficeOpenXml;
using OnlyVacancyApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyVacancyApp.Services
{
    public class ImportService : IImportService
    {
        private readonly AppDbContext _db;

        public ImportService(AppDbContext db)
        {
            _db = db;
        }
        public async Task ImportExcelAsync(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
                throw new BadRequestException("Некорректный параметр");

            var filePath = $"{Directory.GetCurrentDirectory()}{@"\files"}" + "\\" + fileName;
            FileInfo fileInfo = new FileInfo(filePath);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using(ExcelPackage excelPackage = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.FirstOrDefault();
                int colCount = worksheet.Dimension.End.Column;
                int rowCount = worksheet.Dimension.End.Row;

                for(int row = 2; row <= rowCount; row++)
                {
                    UserModel orgStructure = new UserModel();

                    for(int col = 1; col <= colCount; col++)
                    {
                        switch (col)
                        {
                            case 1: orgStructure.Department = (string)worksheet.Cells[row, col].Value; break;
                            case 2: orgStructure.ParentDepartment = (string)worksheet.Cells[row, col].Value; break;
                            case 3: orgStructure.Position = (string)worksheet.Cells[row, col].Value; break;
                            case 4: orgStructure.User = (string)worksheet.Cells[row, col].Value; break;
                        }
                    }

                    _db.Add(orgStructure);
                    await _db.SaveChangesAsync();
                }

            }

        }
    }
}
