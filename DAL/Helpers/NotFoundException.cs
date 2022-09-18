using System;

namespace OnlyVacancyApp.DAL
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string message): base(message)
        {
                
        }
    }
}
