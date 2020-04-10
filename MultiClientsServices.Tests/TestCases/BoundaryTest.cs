using MultiClientsServices.BusinessLayer.ImplimentedServices;
using MultiClientsServices.BusinessLayer.Inerfaces;
using MultiClientsServices.DataLayer.NHibernate;
using MultiClientsServices.Entities;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace BookFinder.Tests
{
    public  class BoundaryTest
    {
        private readonly IMerchantServices _merchantService;
        private readonly IUserServices _userService;
        private readonly IMapperSession _session = Substitute.For<IMapperSession>();

        public BoundaryTest()
        {
            _userService = new UserServices(_session);
            _merchantService = new MerchantServices(_session);
        }

        Random random = new Random();


        [Fact]
        public void BoundaryTestFor_validUserNameLength()
        {
            //Arrange

            Users user = new Users()
            {
                UserId = 1,
                UserName = "Mary",
                Email = "John@gamail.com",
                Password = "123456789",
            };
            var MinLength = 3;
            var MaxLength = 50;

            //Action
            var actualLength = user.UserName.Length;
            var getregisteredUser = _userService.GetUsersById(user.UserId);
            //Assert
            Assert.InRange(getregisteredUser.UserName.Length, MinLength, MaxLength);
            Assert.InRange(actualLength, MinLength, MaxLength);
        }
        [Fact]
        public void BoundaryTestfor_ValidUserName()
        {
            //Action
            var user = new Users()
            {
                UserId =1,
                UserName = "Rose",
                Email = "abc@gmail.com",
                Password = "1234"
            };
            var getregisteredUser = _userService.GetUsersById(user.UserId);
           bool getisUserName = Regex.IsMatch(getregisteredUser.UserName, @"^[a-zA-Z0-9]{4,10}$", RegexOptions.IgnoreCase);
            bool isUserName = Regex.IsMatch(user.UserName, @"^[a-zA-Z0-9]{4,10}$", RegexOptions.IgnoreCase);
            //Assert
            Assert.True(isUserName);
           Assert.True(getisUserName);
        }

        [Fact]
        public void BoundaryTestfor_ValidMerchantUserName()
        {
            //Action
            Merchants merchants = new Merchants()
            {
                MerchantsId = 1,
                MerchantsName = "Mary",
                Email = "John@gamail.com",
                Password = "123456789",
                Mobile = 9876554345
            };
            var getregisteredUser = _merchantService.GetMerchantsById(merchants.MerchantsId);
            bool getisUserName = Regex.IsMatch(getregisteredUser.MerchantsName, @"^[a-zA-Z0-9]{4,10}$", RegexOptions.IgnoreCase);
            bool isUserName = Regex.IsMatch(merchants.MerchantsName, @"^[a-zA-Z0-9]{4,10}$", RegexOptions.IgnoreCase);
            //Assert
            Assert.True(isUserName);
            Assert.True(getisUserName);
        }

        [Fact]
        public void BoundaryTestFor_PasswordLength()
        {
            Users user = new Users()
            {
                UserId = 1,
                UserName = "Mary",
                Email = "John@gamail.com",
                Password = "123456789",
            };
            var MinLength = 8;
            var MaxLength = 25;

            //Action
            var actualLength = user.Password.Length;
            var getregisteredUser = _userService.GetUsersById(user.UserId);
            //Assert
            Assert.InRange(getregisteredUser.Password.Length, MinLength, MaxLength);
            Assert.InRange(actualLength, MinLength, MaxLength);
        }

        [Fact]
        public void BoundaryTest_ValidMobileNumberLength()
        {
            //Arrange
            Users user = new Users()
            {
                UserId = 1,
                UserName = "Mary",
                Email = "John@gamail.com",
                Password = "123456789",
                Mobile=9876554345
            };

            Merchants merchants = new Merchants()
            {
                MerchantsId = 1,
                MerchantsName = "Mary",
                Email = "John@gamail.com",
                Password = "123456789",
                Mobile = 9876554345
            };

            var MinLength = 13;
            var MaxLength = 13;

            //Action
            var actualLengthUser = user.Mobile.ToString().Length;
            var getUser = _userService.GetUsersById(user.UserId);
            var getMerchants = _merchantService.GetMerchantsById(merchants.MerchantsId);
            //Assert
            Assert.InRange(user.Mobile.ToString().Length, MinLength, MaxLength);
            Assert.InRange(actualLengthUser, MinLength, MaxLength);

            Assert.InRange(getMerchants.Mobile.ToString().Length, MinLength, MaxLength);
        }


        [Fact]
        public void BoundaryTestfor_ValidUserEmail()
        {
            //Arrange
            var user = new Users()
            {
                UserId = 1,
                UserName = "Rose",
                Email = "abc@gmail.com",
                Password = "1234"
            };
           
            ////Action
            var getregisteredUser = _userService.GetUsersById(user.UserId);
            bool CheckEmail = Regex.IsMatch(getregisteredUser.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            bool isEmail = Regex.IsMatch(user.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

            //Assert
            Assert.True(isEmail);
            Assert.True(CheckEmail);
        }

        [Fact]
        public void BoundaryTestfor_ValidMerchantsEmail()
        {
            Merchants merchants = new Merchants()
            {
                MerchantsId = 1,
                MerchantsName = "Mary",
                Email = "John@gamail.com",
                Password = "123456789",
                Mobile = 9876554345
            };

            var getregisteredMerchant = _merchantService.GetMerchantsById(merchants.MerchantsId);
            bool CheckEmailforMerchant = Regex.IsMatch(getregisteredMerchant.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            bool isEmail = Regex.IsMatch(merchants.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

            //Assert
            Assert.True(isEmail);
            Assert.True(CheckEmailforMerchant);
      
        }
        }
}
