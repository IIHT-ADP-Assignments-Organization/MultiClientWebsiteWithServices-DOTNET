using System;
using System.Collections.Generic;
using System.Text;

namespace MultiClientsServices.Entities
{
  public  class Goods
    {
        public virtual int GoodsId { get; set; }
        public virtual string GoodsName { get; set; }
        public virtual string GoodsType { get; set; }
        public virtual string GoodsBrand { get; set; }
        public virtual int Quantity { get; set; }
        public virtual double GoodsPrice { get; set; }
        public virtual int MerchantId { get; set; }
    }
}
