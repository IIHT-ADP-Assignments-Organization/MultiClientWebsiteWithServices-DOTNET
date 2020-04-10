using System;
using System.Collections.Generic;
using System.Text;

namespace MultiClientsServices.Entities
{
   public class Payment
    {
        public virtual int PaymentId { get; set; }
        public virtual string PaymentMode { get; set; }
        public virtual double Price { get; set; }

    }
}
