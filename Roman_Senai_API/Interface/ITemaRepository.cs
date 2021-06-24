using Roman_Senai.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman_Senai.Interface
{
    interface ITemaRepository
    {
        List<TemaDomain> ListarTodos();

        TemaDomain BuscarPorId(int id);

        void Cadastrar(TemaDomain novoTema);

        void Atualizar(int id, TemaDomain temaAtualizado);

        void Deletar(int id);
    }
}
