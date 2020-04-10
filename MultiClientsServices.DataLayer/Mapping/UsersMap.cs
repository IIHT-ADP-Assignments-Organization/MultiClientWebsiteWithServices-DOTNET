using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MultiClientsServices.Entities;

namespace BookFinder.DataLayer.Mapping
{
    public class UsersMap : ClassMap<Users>
    {
        public UsersMap()
        {
            Id(x => x.UserId);
            Map(x => x.UserName);
            Map(x => x.Role);
            Map(x => x.Email);
            Map(x => x.Password);
            Map(x => x.Address);
            Map(x => x.Mobile);
            Map(x => x.PaymentId);

            Table("Users");

        }
    }

}
