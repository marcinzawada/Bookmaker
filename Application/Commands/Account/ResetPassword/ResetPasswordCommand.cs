﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using MediatR;

namespace Application.Commands.Account.ResetPassword
{
    public record ResetPasswordCommand(string Email) : IRequest<Response>;
}