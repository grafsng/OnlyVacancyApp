using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlyVacancyApp.DAL
{
    public class DepartmentCountInfo
    {
        [JsonPropertyName("Общее количество работников отдела")] 
        public int EmployeesNumber { get; set; }

        [JsonPropertyName("Общее количество позиций в отделе")]
        public int PositinonsNumber { get; set; }
    }
}
