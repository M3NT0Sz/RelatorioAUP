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
    public partial class FRNRelatorioUsuarios : Form
    {
        public FRNRelatorioUsuarios()
        {
            InitializeComponent();
        }

        public void imprimir(ListaUsuarios relatorio)
        {
            ClassUsuariosBindingSource.DataSource = relatorio;
        }

        private void FRNRelatorioUsuarios_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
