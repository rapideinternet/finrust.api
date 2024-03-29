﻿using FinRust.Application.Common.Interfaces;
using FinRust.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinRust.Application.System.Commands.SeedSampleData
{
    public class SeedSampleDataCommand : IRequest
    {
    }

    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand>
    {
        private readonly IFinRustDbContext _context;
        private readonly IUserManager _userManager;

        public SeedSampleDataCommandHandler(IFinRustDbContext context, IUserManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new SampleDataSeeder(_context, _userManager);

            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
