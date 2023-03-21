using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjetoRelatorio
{
    public partial class FRNRelatorioAlunos : Form
    {
        public FRNRelatorioAlunos()
        {
            InitializeComponent();
        }

        public void imprimir(ListaAlunos relatorio)
        {
            ClassAlunosBindingSource.DataSource = relatorio;
        }

        private void FRNRelatorioAlunos_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
