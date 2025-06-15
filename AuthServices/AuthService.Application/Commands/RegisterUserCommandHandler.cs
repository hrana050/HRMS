using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IAuthDbContext _context;

        public RegisterUserCommandHandler(IAuthDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existing = await _context.Users
                .FirstOrDefaultAsync(x => x.email == request.email, cancellationToken);
            if (existing != null)
                throw new Exception("User already exists");

            var user = new Users
            {
                fname = request.fname,
                lname = request.lname,
                email = request.email,
                passwordHash = BCrypt.Net.BCrypt.HashPassword(request.password),
                role = request.role,
                IsActive = true
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user.AutoId;
        }
    }
}