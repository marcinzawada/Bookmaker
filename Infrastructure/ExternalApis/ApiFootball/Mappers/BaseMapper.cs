using System;
using Infrastructure.Data;

namespace Infrastructure.ExternalApis.ApiFootball.Mappers
{
    public class BaseMapper
    {
        protected readonly AppDbContext _context;

        public BaseMapper(AppDbContext context)
        {
            _context = context;
        }

        protected bool ParseDate(string date, out DateTime parsedDate)
        {
            return DateTime.TryParseExact(
                date, "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out parsedDate);
        }
    }
}
