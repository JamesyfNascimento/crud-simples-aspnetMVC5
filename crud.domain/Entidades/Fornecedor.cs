using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.domain.Entidades
{
    public class Fornecedor
    {

        public Guid FornecedorID { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
    }
}
