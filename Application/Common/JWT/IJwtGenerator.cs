using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.JWT
{
    public interface IJwtGenerator
    {
        public string Generate(User user);
    }
}
