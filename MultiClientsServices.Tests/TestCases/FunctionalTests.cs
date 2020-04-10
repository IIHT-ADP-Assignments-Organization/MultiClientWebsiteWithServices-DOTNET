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
   public class FunctionalTests
    {
        private readonly IMerchantServices _merchantService;
        private readonly IUserServices _userService;
        private readonly IMapperSession _session = Substitute.For<IMapperSession>();

        public FunctionalTests()
        {
            _userService = new UserServices(_session);
            _merchantService = new MerchantServices(_session);
        }

        Random random = new Random();

        [Fact]
        public void TestFor_ValidUserRegister()
        {
            //Arrange
            Users user = new Users()
            {
                UserId = 1,
                UserName = "Rose",
                Email = "abc@gmail.com",
                Password = "1234"
            };
            //Action
            var registeredUser = _userService.SignUp(user);
            var getregisteredUser = _userService.GetUsersById(user.UserId);
            //Assert
            Assert.Equal(getregisteredUser, registeredUser);
        }
        [Fact]
        public void TestFor_ValidMerchantsRegister()
        {
            //Arrange
            Merchants merchants = new Merchants()
            {
                MerchantsId = 1,
                MerchantsName = "Mar",
                Email = "John@gamail.com",
                Password = "123456789",
                Mobile = 9876554345
            };
            //Action
            var registeredMerchant = _merchantService.SignUp(merchants);
            var getregisteredMerchant = _merchantService.GetMerchantsById(merchants.MerchantsId);
            //Assert
            Assert.Equal(getregisteredMerchant, registeredMerchant);
            Assert.Equal(getregisteredMerchant, registeredMerchant);
        }

        [Fact]
        public void TestFor_ValidUserLogin()
        {
            //Arrange
            //Arrange
            Users user = new Users()
            {
                UserId = 100,
                UserName = "Rose",
                Email = "abc@gmail.com",
                Password = "1234"
            };
            //Action
            var loggedUser = _userService.SignIn(user.UserName, user.Password);
            var getregisteredUser = _userService.GetUsersById(user.UserId);
            //Assert
            Assert.Equal(getregisteredUser, loggedUser);
        }

        [Fact]
        public void TestFor_ValidMerchantLogin()
        {
            
            //Arrange
            Merchants merchants = new Merchants()
            {
                MerchantsId = 1,
                MerchantsName = "Mar",
                Email = "John@gamail.com",
                Password = "123456789",
                Mobile = 9876554345
            };
            //Action
            var loggedUser = _merchantService.SignIn(merchants.MerchantsName, merchants.Password);
            var getregisteredUser = _merchantService.GetMerchantsById(merchants.MerchantsId);
            //Assert
            Assert.Equal(getregisteredUser, loggedUser);
        }
        [Fact]
        public void TestFor_ValidPurchaseGoods()
        {
            Goods goods = new Goods()
            {
                GoodsId = 1,
                GoodsName = "Vivo F7",
                GoodsType = "Mobiles",
                GoodsBrand = "Vivo",
                Quantity = 1,
                GoodsPrice = 12000,
                MerchantId = 1
            };
            var purchaseditem = _userService.PurchaseGoods(goods.GoodsId);
            var getgoods = _userService.GetGoodsById(goods.GoodsId);
            //Assert
            Assert.Equal(getgoods, purchaseditem);
        }

        [Fact]
        public void TestFor_ValidClaimServices()
        {
            //Arrange
            Services services = new Services()
            {
                ServicesId = 1,
                ServicesName = "Electricial",
                ServicesType = "Mobiles",
                ServicesPrice = 1200,
                MerchantId = 2
            };
            //Action
            var claimed = _userService.ClaimServices(services.ServicesId);
            var getservice = _userService.GetServicesById(services.ServicesId);
            //Assert
            Assert.Equal(getservice, claimed);
        }

        [Fact]
        public void TestFor_ValidSearching()
        {
            //Arrange
            Services services = new Services()
            {
                ServicesId = 1,
                ServicesName = "Electricial",
                ServicesType = "Mobiles",
                ServicesPrice = 1200,
                MerchantId = 2
            };
            Goods goods = new Goods()
            {
                GoodsId = 1,
                GoodsName = "Vivo F7",
                GoodsType = "Mobiles",
                GoodsBrand = "Vivo",
                Quantity = 1,
                GoodsPrice = 12000,
                MerchantId = 1
            };
            //Action
            var goodsList = _userService.SearchGoods(goods.GoodsName);
            var servicesList = _userService.SearchServices(services.ServicesName);

            //Assert
            Assert.NotEmpty(servicesList);
            Assert.NotEmpty(goodsList);
        }


        [Fact]
        public void TestFor_ValidCancellServices()
        {
            //Arrange
            Services services = new Services()
            {
                ServicesId = 1,
                ServicesName = "Electricial",
                ServicesType = "Mobiles",
                ServicesPrice = 1200,
                MerchantId = 2
            };
            //Action
            var cancelled = _userService.CancellServices(services.ServicesName);
            var getservice = _userService.GetServicesById(services.ServicesId);
            //Assert
            Assert.Equal(getservice, cancelled);
        }
        [Fact]
        public void TestFor_ValidCancellGoodsOrder()
        {
            Goods goods = new Goods()
            {
                GoodsId = 1,
                GoodsName = "Vivo F7",
                GoodsType = "Mobiles",
                GoodsBrand = "Vivo",
                Quantity = 1,
                GoodsPrice = 12000,
                MerchantId = 1
            };
            var Cancelleditem = _userService.CancellGoodsOrder(goods.GoodsName);
            var getgoods = _userService.GetGoodsById(goods.GoodsId);
            //Assert
            Assert.Equal(getgoods, Cancelleditem);
        }

        [Fact]
        public void TestFor_ValidMakePayment()
        {
            Merchants merchants = new Merchants()
            {
                MerchantsId = 1,
                MerchantsName = "Mar",
                Email = "John@gamail.com",
                Password = "123456789",
                Mobile = 9876554345
            };
            Payment payment = new Payment()
            {
                PaymentId = 100,
                PaymentMode = "Online",
                Price = 12000
            };
            var IsPayed = _userService.MakePayment(merchants, payment);

            //Assert
            Assert.True(IsPayed);
        }

        [Fact]
        public void TestFor_ValidCreateWebsitPage()
        {
            //Acrrange
            Merchants merchants = new Merchants()
            {
                MerchantsId = 1,
                MerchantsName = "Mar",
                Email = "John@gamail.com",
                Password = "123456789",
                Mobile = 9876554345
            };
            //Action
            var IsCreated= _merchantService.CreateWebsitPage(merchants);

            //Assert
            Assert.True(IsCreated);
        }

        [Fact]
        public void TestFor_ValidAddGoods()
        {
            Goods goods = new Goods()
            {
                GoodsId = 1,
                GoodsName = "Vivo F7",
                GoodsType = "Mobiles",
                GoodsBrand = "Vivo",
                Quantity = 1,
                GoodsPrice = 12000,
                MerchantId = 1
            };
            var addeditem = _merchantService.AddGoods(goods);
            var getgoods = _merchantService.GetGoodsById(goods.GoodsId);
            //Assert
            Assert.Equal(getgoods, addeditem);
        }
        [Fact]
        public void TestFor_ValidAddServices()
        {
            //Arrange
            Services services = new Services()
            {
                ServicesId = 1,
                ServicesName = "Electricial",
                ServicesType = "Mobiles",
                ServicesPrice = 1200,
                MerchantId = 2
            };
            //Action
            var addedService = _merchantService.AddServices(services);
            var getservice = _merchantService.GetServicesById(services.ServicesId);
            //Assert
            Assert.Equal(getservice, addedService);
        }

        [Fact]
        public void TestFor_ValidDisplayOfServicesAndGoods()
        {
            //Arrange
            Merchants merchants = new Merchants()
            {
                MerchantsId = 1,
                MerchantsName = "Mar",
                Email = "John@gamail.com",
                Password = "123456789",
                Mobile = 9876554345
            };

            //Actions
            var allServices = _merchantService.DisplayServices(merchants.MerchantsId);
            var allGoods = _merchantService.DisplayAllGoods(merchants.MerchantsId);

            //Assert
            Assert.NotNull(allServices);
            Assert.NotNull(allGoods);
            Assert.NotEmpty(allServices);
            Assert.NotEmpty(allGoods);
        }
    }
}
