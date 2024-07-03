using BankingApp.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Application.Features.Users.Command
{
    public record AuthenticateUserCommand(string Username, string Password) : IRequest<AuthenticateResponse>;

}
