using BankingApp.Application.Dtos;
using BankingApp.Application.Features.Users.Command;
using BankingApp.Application.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Application.Features.Users.Handler
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserDto>
    {
        private readonly IUserService _userService;

        public RegisterUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.RegisterAsync(request.UserDto);
        }
    }

}
