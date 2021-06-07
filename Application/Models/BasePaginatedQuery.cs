using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public record BasePaginatedQuery(int ItemPerPage = 10, int PageNumber = 1);
}
