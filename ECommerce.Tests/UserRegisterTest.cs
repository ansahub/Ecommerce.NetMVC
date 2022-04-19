using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.Options;

namespace Ecommerce.Web.Tests
{
    /// <summary> 
    /// Testing methods from UserRepository class
    /// </summary>
    public class UserRegisterTest
    {       

        [SetUp]
        public void Setup()
        {
           
        }
                

        [Test]
        public async Task CreateUserAndCheckById_True()
        {
            var mockStore = Mock.Of<IUserStore<IdentityUser>>();
            var mockUserManager = new Mock<UserManager<IdentityUser>>(mockStore, null, null, null, null, null, null, null, null);

            var user = new IdentityUser
            {
                Id = "1",
                UserName = "Test",
                Email = "Test"
            };

            mockUserManager
                .Setup(x => x.CreateAsync(It.IsAny<IdentityUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            await mockUserManager.Object.CreateAsync(user);

            mockUserManager
               .Setup(x => x.FindByIdAsync("1"))
               .ReturnsAsync(user);

            var result = mockUserManager.Object.FindByIdAsync("1").Result;

            Assert.AreEqual(result.UserName, "Test");
        }

        [Test]
        //If we try to find a user by ID that's not in the Db
        public async Task CreateUserAndCheckByUnvalidId_True()
        {
            var mockStore = Mock.Of<IUserStore<IdentityUser>>();
            var mockUserManager = new Mock<UserManager<IdentityUser>>(mockStore, null, null, null, null, null, null, null, null);

            var user = new IdentityUser
            {
                Id = "1",
                UserName = "Test",
                Email = "Test"
            };

            mockUserManager
                .Setup(x => x.CreateAsync(It.IsAny<IdentityUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            await mockUserManager.Object.CreateAsync(user);

            var result = mockUserManager.Object.FindByIdAsync("3");

            Assert.AreNotEqual(result.Id, 3);

        }
    }

    public class FakeUserManager : UserManager<IdentityUser>
    {
        public FakeUserManager()
           : base(new Mock<IUserStore<IdentityUser>>().Object,
              new Mock<IOptions<IdentityOptions>>().Object,
              new Mock<IPasswordHasher<IdentityUser>>().Object,
              new IUserValidator<IdentityUser>[0],
              new IPasswordValidator<IdentityUser>[0],
              new Mock<ILookupNormalizer>().Object,
              new Mock<IdentityErrorDescriber>().Object,
              new Mock<IServiceProvider>().Object,
              new Mock<ILogger<UserManager<IdentityUser>>>().Object)
        { }
    }

}