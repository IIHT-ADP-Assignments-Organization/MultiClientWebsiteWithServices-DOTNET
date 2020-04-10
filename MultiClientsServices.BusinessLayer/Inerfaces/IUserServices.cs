using MultiClientsServices.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiClientsServices.BusinessLayer.Inerfaces
{
   public interface IUserServices
    {
      Users SignUp(Users user);
      Users SignIn(string userName,string password);
      Goods PurchaseGoods(int goodsId);
      Services ClaimServices(int servicesId);
      bool MakePayment(Merchants merchant,Payment payment);
      List<Goods> SearchGoods(string goodsName);
      List<Services> SearchServices(string serviceName);
      Services CancellServices(string serviceName);
      Goods CancellGoodsOrder(string goodsName);
      Goods GetGoodsById(int goodsId);
      Users GetUsersById(int userId);
     Services GetServicesById(int servicesId);
    }
}
