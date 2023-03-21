using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoRelatorio
{
    public class ListaAlunos : List<ClassAlunos> { }
    public class ClassAlunos
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

        string cpf = "";

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        string rg = "";

        public string Rg
        {
            get { return rg; }
            set { rg = value; }
        }
    }
}
