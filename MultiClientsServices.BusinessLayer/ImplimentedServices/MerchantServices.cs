using MultiClientsServices.BusinessLayer.Inerfaces;
using MultiClientsServices.DataLayer.NHibernate;
using MultiClientsServices.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiClientsServices.BusinessLayer.ImplimentedServices
{
    public class MerchantServices : IMerchantServices
    {
        private readonly IMapperSession _session;

        public MerchantServices(IMapperSession session)
        {
            _session = session;
        }

        public Goods AddGoods(Goods goods)
        {
            throw new NotImplementedException();
        }

        public Services AddServices(Services services)
        {
            throw new NotImplementedException();
        }

        public bool CreateWebsitPage(Merchants merchant)
        {
            throw new NotImplementedException();
        }

        public List<Goods> DisplayAllGoods(int merchantId)
        {
            throw new NotImplementedException();
        }

        public List<Services> DisplayServices(int merchantId)
        {
            throw new NotImplementedException();
        }

        public Goods GetGoodsById(int goodsId)
        {
            throw new NotImplementedException();
        }

        public Merchants GetMerchantsById(int merchantId)
        {
            throw new NotImplementedException();
        }

        public Services GetServicesById(int servicesId)
        {
            throw new NotImplementedException();
        }

        public Merchants SignIn(string Name, string password)
        {
            throw new NotImplementedException();
        }

        public Merchants SignUp(Merchants merchant)
        {
            throw new NotImplementedException();
        }
    }
}
