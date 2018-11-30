using Crud.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Crud.Infra.Data.Contexto
{
    public class ContextoGerente : IContextoGerente
    {

        private const string ChaveContexto = "ContextoGerente.Contexto";
        public CrudSimplesContexto GetContext()
        {
            if (HttpContext.Current.Items[ChaveContexto] == null)
            {
                HttpContext.Current.Items[ChaveContexto] = new CrudSimplesContexto();
            }

            return (CrudSimplesContexto)HttpContext.Current.Items[ChaveContexto];
        }
    }
}
