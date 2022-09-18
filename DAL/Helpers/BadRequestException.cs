using System;

namespace OnlyVacancyApp.DAL
{
    public class BadRequestException: Exception
    {
        public BadRequestException(string message): base(message)
        {
            
        }
    }
}
