using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using FluentValidation;
using MediatR;

namespace Application.Queries.Clubs.GetAll
{

    public record GetAllClubsQuery() : IRequest<Response>;

}
