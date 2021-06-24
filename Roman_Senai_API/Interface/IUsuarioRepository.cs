using Roman_Senai.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman_Senai.Interface
{
    interface IUsuarioRepository
    {
        List<UsuarioDomain> ListarTodos();

        UsuarioDomain BuscarPorId(int id);
        UsuarioDomain BuscarPorEmailSenha(string email, string senha);

        void Cadastrar(UsuarioDomain novoUsuario);

        void Atualizar(int id, UsuarioDomain usuarioAtualizado);

        void Deletar(int id);

        UsuarioDomain Login(string email, string senha);
    }
}
