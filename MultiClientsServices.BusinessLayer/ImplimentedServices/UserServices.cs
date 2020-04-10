using MultiClientsServices.BusinessLayer.Inerfaces;
using MultiClientsServices.DataLayer.NHibernate;
using MultiClientsServices.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiClientsServices.BusinessLayer.ImplimentedServices
{
  public  class UserServices : IUserServices
    {
        private readonly IMapperSession _session;

        public UserServices(IMapperSession session)
        {
            _session = session;
        }

        public Goods CancellGoodsOrder(string goodsName)
        {
            throw new NotImplementedException();
        }

        public Services CancellServices(string serviceName)
        {
            throw new NotImplementedException();
        }

        public Services ClaimServices(int servicesId)
        {
            throw new NotImplementedException();
        }

        public Goods GetGoodsById(int goodsId)
        {
            throw new NotImplementedException();
        }

        public Services GetServicesById(int servicesId)
        {
            throw new NotImplementedException();
        }

        public Users GetUsersById(int userId)
        {
            throw new NotImplementedException();
        }

        public bool MakePayment(Merchants merchant, Payment payment)
        {
            throw new NotImplementedException();
        }

        public Goods PurchaseGoods(int goodsId)
        {
            throw new NotImplementedException();
        }

        public List<Goods> SearchGoods(string goodsName)
        {
            throw new NotImplementedException();
        }

        public List<Services> SearchServices(string serviceName)
        {
            throw new NotImplementedException();
        }

        public Users SignIn(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Users SignUp(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
