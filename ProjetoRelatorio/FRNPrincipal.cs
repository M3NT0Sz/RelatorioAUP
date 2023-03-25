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
    public partial class FRNPrincipal : Form
    {
        string cnsql = "";
        public FRNPrincipal(string cn)
        {
            cnsql = cn;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRNConsultaUsuarios consulta = new FRNConsultaUsuarios(cnsql);
            consulta.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FRNConsultaAlunos consulta = new FRNConsultaAlunos(cnsql);
            consulta.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FRNBackup backup = new FRNBackup(cnsql);
            backup.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRNConsultaUsuarios consulta = new FRNConsultaUsuarios(cnsql);
            consulta.ShowDialog();
        }

        private void alunosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRNConsultaAlunos consulta = new FRNConsultaAlunos(cnsql);
            consulta.ShowDialog();
        }

        private void alunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRNManutAlunos cadastrar = new FRNManutAlunos(cnsql);
            cadastrar.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRNManutUsuarios cadastrar = new FRNManutUsuarios(cnsql);
            cadastrar.ShowDialog();
        }

        private void professoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRNManutProfessor cadastrar = new FRNManutProfessor(cnsql);
            cadastrar.ShowDialog();
        }
    }
}
