using BookFinder.Tests.Exceptions;
using MultiClientsServices.BusinessLayer.ImplimentedServices;
using MultiClientsServices.BusinessLayer.Inerfaces;
using MultiClientsServices.DataLayer.NHibernate;
using MultiClientsServices.Entities;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookFinder.Tests
{
   public class ExceptionalTest
    {
        private readonly IMerchantServices _merchantService;
        private readonly IUserServices _userService;
        private readonly IMapperSession _session = Substitute.For<IMapperSession>();

        public ExceptionalTest()
        {
            _userService = new UserServices(_session);
            _merchantService = new MerchantServices(_session);
        }

        Random random = new Random();

        [Fact]
        public void ExceptionTestFor_ValidRegistration()
        {
            Users user = new Users()
            {
                UserId =1,
                UserName = "Mary",
                Email = "John@gamail.com",
                Password = "123456789",
            };
            Merchants merchants = new Merchants()
            {
                MerchantsId = 1,
                MerchantsName = "Mary",
                Email = "John@gamail.com",
                Password = "123456789",
                Mobile = 9876554345
            };
            //Action
            //Assert
            var ex = Assert.Throws<UserExistException>(() => _userService.SignUp(user));
            var exc = Assert.Throws<UserExistException>(() => _merchantService.SignUp(merchants));
            Assert.Equal("Already have an Account please login", ex.Messages);
            Assert.Equal("Already have an Account please login", exc.Messages);
        }

        [Fact]
        public void ExceptionTestFor_UserNotFound()
        {
            //Assert
            Users user = new Users()
            {
                UserId = random.Next(100, 10000000),
                UserName = "Mary",
                Email = "John@gamail.com",
                Password = "123456789",
            };
            Merchants merchants = new Merchants()
            {
                MerchantsId = random.Next(100, 10000000),
                MerchantsName = "Mary",
                Email = "John@gamail.com",
                Password = "123456789",
                Mobile = 9876554345
            };
            var ex = Assert.Throws<UserNotFoundException>(() => _userService.SignIn(user.UserName,user.Password));
            var exc = Assert.Throws<UserNotFoundException>(() => _merchantService.SignIn(merchants.MerchantsName, merchants.Password));
            Assert.Equal("User Not Found ", ex.Messages);
            Assert.Equal("User Not Found ", exc.Messages);
        }
       

        [Fact]
        public void ExceptionTestFor_ValidUserName_InvalidPassword()
        {
            Users user = new Users()
            {
                UserId = 1,
                UserName = "Mary",
                Email = "John@gamail.com",
                Password = "1235",
            };
            Merchants merchants = new Merchants()
            {
                MerchantsId = 1,
                MerchantsName = "Mary",
                Email = "John@gamail.com",
                Password = "12345",
                Mobile = 9876554345
            };
            //Assert
            var ex = Assert.Throws<InvalidCredentialsExceptions>(() => _userService.SignIn(user.UserName, user.Password));
            var exc = Assert.Throws<InvalidCredentialsExceptions>(() => _merchantService.SignIn(merchants.MerchantsName, merchants.Password));
            Assert.Equal("Please enter valid usename & password", ex.Messages);
            Assert.Equal("Please enter valid usename & password", exc.Messages);
        }

        [Fact]
        public void ExceptionTestFor_InvalidUserName_validPassword()
        {
            //Action
            Users user = new Users()
            {
                UserId = 1,
                UserName = "abcd",
                Email = "hn@gamail.com",
                Password = "123789",
            };
            Merchants merchants = new Merchants()
            {
                MerchantsId = 1,
                MerchantsName = "Mar",
                Email = "John@gamail.com",
                Password = "123456789",
                Mobile = 9876554345
            };
            //Assert
            var ex = Assert.Throws<InvalidCredentialsExceptions>(() => _userService.SignIn(user.UserName, user.Password));
            var exc = Assert.Throws<InvalidCredentialsExceptions>(() => _merchantService.SignIn(merchants.MerchantsName, merchants.Password));
            Assert.Equal("Please enter valid usename & password", ex.Messages);
            Assert.Equal("Please enter valid usename & password", exc.Messages);
        }
    }
}
