using MultiClientsServices.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiClientsServices.BusinessLayer.Inerfaces
{
  public interface IMerchantServices
    {
        Merchants SignUp(Merchants merchant);
        Merchants SignIn(string Name, string password);
        bool CreateWebsitPage(Merchants merchant);
        Goods AddGoods(Goods goods);
       Services AddServices(Services services);
       List<Services> DisplayServices(int merchantId);
       List<Goods> DisplayAllGoods(int merchantId);
        Goods GetGoodsById(int goodsId);
        Merchants GetMerchantsById(int merchantId);
        Services GetServicesById(int servicesId);

    }
}
