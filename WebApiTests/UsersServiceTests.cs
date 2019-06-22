using Lab3Movie.Models;
using Lab3Movie.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Tests
{
    public class UsersServiceTests
    {
        private IOptions<AppSettings> config;

        [SetUp]
        public void Setup()
        {
            config = Options.Create(new AppSettings
            {
                Secret = "dsadhjcghduihdfhdifd8ih"
            });
        }


        /// <summary>
        /// TO DO: AAAA- Arrage, Act,Assert
        /// </summary>
        [Test]
        public void ValidRegisterShouldCreateANewUser()
        {
            var options = new DbContextOptionsBuilder<MoviesDbContext>()
              .UseInMemoryDatabase(databaseName: nameof(ValidRegisterShouldCreateANewUser))// "ValidRegisterShouldCreateANewUser")
              .Options;

            using (var context = new MoviesDbContext(options))
            {
                var usersService = new UsersService(context, config);
                var added = new Lab3Movie.ViewModels.RegisterPostModel
                    {
                    Email = "a@a.b",
                    FirstName = "fdsfsdfs",
                    LastName = "fdsfs",
                    Password = "1234567",
                    Username = "test_username"
                };
                var result = usersService.Register(added);

                Assert.IsNotNull(result);
                Assert.AreEqual(added.Username, result.Username);
            }
         }
    }
}