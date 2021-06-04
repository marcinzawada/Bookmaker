using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public record Error(string ErrorCode, string Message,
        HttpStatusCode StatusCode = HttpStatusCode.BadRequest);
}
