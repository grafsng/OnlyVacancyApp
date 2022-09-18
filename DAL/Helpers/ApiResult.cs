using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyVacancyApp.DAL
{
    public class ApiResult
    {
        public ApiResult(int code, List<string> errors)
        {
            Code = code;    
            Errors = errors;
        }
        public List<string> Errors { get; set; }

        public int Code { get; set; }
    }
}
