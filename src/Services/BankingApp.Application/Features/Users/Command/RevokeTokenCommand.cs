using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Application.Features.Users.Command
{
    public record RevokeTokenCommand(string Token) : IRequest<bool>;
}
