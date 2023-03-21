using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoRelatorio
{
    public class ListaUsuarios : List<ClassUsuarios> { }
    public class ClassUsuarios
    {
        int codigo = 0;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        string nome = "";

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        string email = "";

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        string senha = "";

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
    }
}
