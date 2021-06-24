using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman_Senai.Domains
{
    public class ProjetoDomain
    {
        public int idProjeto { get; set; }
        public TemaDomain tema { get; set; }
        public string nomeProfessor { get; set; }
        public string nomeProjeto { get; set; }
        public string descricao { get; set; }
    }
}
