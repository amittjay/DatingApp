using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Extensions
{
    public static class DateTimeExtension
    {
        public static int CalculateAge(this DateTime Dob)
        {
            var Today = DateTime.Today;
            var Age = Dob.Year - Today.Year;
            if (Dob.Date > Today.AddYears(-Age)) Age--;
            return Age;
        }
    }
}
