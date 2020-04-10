using MultiClientsServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiClientsServices.DataLayer.NHibernate
{
    public interface IMapperSession
    {
        void BeginTransaction();
        System.Threading.Tasks.Task Commit();
        System.Threading.Tasks.Task Rollback();
        void CloseTransaction();
        System.Threading.Tasks.Task Save(List<Users> entity);
        System.Threading.Tasks.Task Delete(Users entity);
        IQueryable<Users> user { get; }
    }
}
