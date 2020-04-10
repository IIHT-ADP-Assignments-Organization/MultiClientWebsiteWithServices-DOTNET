using System;
using System.Collections.Generic;
using System.Text;

namespace MultiClientsServices.Entities
{
  public  class Services
    {
        public virtual int ServicesId { get; set; }
        public virtual string ServicesName { get; set; }
        public virtual string ServicesType { get; set; }
        public virtual double ServicesPrice { get; set; }
        public virtual int MerchantId { get; set; }
    }
}
