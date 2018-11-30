using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void SaveChanges();
    }
}
