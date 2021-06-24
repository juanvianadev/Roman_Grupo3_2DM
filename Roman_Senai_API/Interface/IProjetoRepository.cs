using Roman_Senai.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman_Senai.Interface
{
    interface IProjetoRepository
    {
        List<ProjetoDomain> ListarTodos();

        ProjetoDomain BuscarPorId(int id);

        void Cadastrar(ProjetoDomain novoProjeto);

        void Atualizar(int id, ProjetoDomain projetoAtualizado);

        void Deletar(int id);
    }
}
