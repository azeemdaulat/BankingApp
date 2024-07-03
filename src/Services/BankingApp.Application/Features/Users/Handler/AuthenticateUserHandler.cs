using BankingApp.Application.Features.Users.Command;
using BankingApp.Application.Response;
using BankingApp.Application.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Application.Features.Users.Handler
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateResponse>
    {
        private readonly IUserService _userService;

        public AuthenticateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<AuthenticateResponse> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.AuthenticateAsync(request.Username, request.Password);
        }
    }

}
