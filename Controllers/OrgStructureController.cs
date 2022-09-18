using Microsoft.AspNetCore.Mvc;
using OnlyVacancyApp.DAL;
using OnlyVacancyApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyVacancyApp.Controllers
{
    [ApiController]
    [Route("api/v1/orgstructure")]
    public class OrgStructureController: ControllerBase
    {
        private readonly IImportService _service1;
        private readonly IDepCountService _service2;
        private readonly IOperationService _service3;

        public OrgStructureController(IImportService service1, IDepCountService service2, IOperationService service3)
        {
            _service1 = service1;
            _service2 = service2;
            _service3 = service3;
        }
        [HttpGet("import")]
        public async Task<ActionResult> ImportFromExcelAsync(string fileName= "Тестовые данные(1).xlsx")
        {
            await _service1.ImportExcelAsync(fileName);
            return Ok();
        }

        #region CRUD

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAsync(string parentDepName)
        {
            return Ok(await _service3.GetAsync(parentDepName));
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> PostAsync(UserModel user)
        {
            return Ok(await _service3.PostAsync(user));
        }

        [HttpPut]
        public async Task<ActionResult<UserModel>> PutAsync(UserModel user)
        {
            return Ok(await _service3.PutAsync(user));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(string userName)
        {
            await _service3.DeleteAsync(userName);
            return Ok();
        }
        #endregion


        [HttpGet("department/countinfo")]
        public async Task<ActionResult<DepartmentCountInfo>> GetCountInfo(string depName = "Отдел разработки мобильных приложений")
        {
            try
            {
                return Ok(await _service2.GetInfoAsync(depName));
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
