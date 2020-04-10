using System;
using System.Collections.Generic;
using System.Text;

namespace MultiClientsServices.Entities
{
    public class Merchants
    {
        public virtual int MerchantsId { get; set; }
        public virtual string MerchantsName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Address { get; set; }
        public virtual long Mobile { get; set; }
        public virtual int PaymentId { get; set; }

    }
}
