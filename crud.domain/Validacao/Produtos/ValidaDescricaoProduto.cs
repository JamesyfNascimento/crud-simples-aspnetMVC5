using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.domain.Validacao.Produtos
{
    public class ValidaDescricaoProduto
    {
        public static bool Validate(string nome)
        {
            if (nome.Length > 3)
            {
                return true;
            }
            return false;
        }
    }
}

