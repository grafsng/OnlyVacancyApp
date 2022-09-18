using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyVacancyApp
{
    public class UserModel
    {
        [Key]
        public string User { get; set; }
        public string? Department { get; set; }
        public string? ParentDepartment { get; set; }
        public string? Position { get; set; }

    }
}
