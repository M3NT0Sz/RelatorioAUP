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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string cnsql = @"SERVER=localhost;DATABASE=escola;UID=root;PASSWORD=''";
        //string cnsql = @"SERVER=192.168.225.41;DATABASE=escola;UID=sa2;PASSWORD=123456";

        private void button1_Click(object sender, EventArgs e)
        {
            FRNPrincipal principal = new FRNPrincipal(cnsql);
            principal.ShowDialog();
        }
    }
}
