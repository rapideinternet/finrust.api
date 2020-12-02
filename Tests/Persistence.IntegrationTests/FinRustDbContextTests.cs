using FinRust.Application.Common.Interfaces;
using FinRust.Common;
using FinRust.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;

namespace Persistence.IntegrationTests
{
    public class FinRustDbContextTests : IDisposable
    {
        private readonly string _userId;
        private readonly DateTime _dateTime;
        private readonly Mock<IDateTime> _dateTimeMock;
        private readonly Mock<ICurrentUserService> _currentUserServiceMock;
        private readonly FinRustDbContext _sut;

        public FinRustDbContextTests()
        {
            _dateTime = new DateTime(3001, 1, 1);
            _dateTimeMock = new Mock<IDateTime>();
            _dateTimeMock.Setup(m => m.Now).Returns(_dateTime);

            _userId = "00000000-0000-0000-0000-000000000000";
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _currentUserServiceMock.Setup(m => m.UserId).Returns(_userId);

            var options = new DbContextOptionsBuilder<FinRustDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _sut = new FinRustDbContext(options, _currentUserServiceMock.Object, _dateTimeMock.Object);

            //Fill database with test objects

            _sut.SaveChanges();
        }

        public void Dispose()
        {
            _sut?.Dispose();
        }
    }
}
