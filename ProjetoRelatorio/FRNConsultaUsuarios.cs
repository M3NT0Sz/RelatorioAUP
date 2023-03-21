using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace ProjetoRelatorio
{
    public partial class FRNConsultaUsuarios : Form
    {
        string cnsql = "";
        public FRNConsultaUsuarios(string cn)
        {
            cnsql = cn;
            InitializeComponent();
        }

        private void consultar()
        {
            dataGridView1.Rows.Clear();//limpando os dados do grid
            string sql = "select * from USUARIOS ORDER BY NOME";//envniando uma instrução em sql para o banco
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando o caminho onde está alocado o banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//enviando o caminho e a instrução em sql para o  banco
            conexao.Open();//abrindo conexão
            MySqlDataReader leia = comando.ExecuteReader();//enviando uma variavel que irá realizar uma leitura dos dados
            if (leia.HasRows)//encontrou alguma coisa?
            {
                button2.Visible = true; //habilita o botÃO IMPRIMIR
                int x = 0;
                while (leia.Read())//enquanto o leia estiver encontrando dados ele vai exibir as informações no grid, registro por registro
                {
                    x++;
                    dataGridView1.Rows.Add(Convert.ToString(leia["codigo"]), Convert.ToString(leia["nome"]), Convert.ToString(leia["email"]), Convert.ToString(leia["senha"]));
                }
                textBox1.Text = Convert.ToString(x);
            }

            else
            {
                MessageBox.Show("Nenhum Registro Encontrado!", "Ajuda do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }

        private void imprimir()
        {
            ListaUsuarios cadastro = new ListaUsuarios(); //aponta para a lista
            string sql = "select * from usuarios";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando o caminho onde está alocado o banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//enviando o caminho e a instrução em sql para o  banco
            conexao.Open();//abrindo conexão
            MySqlDataReader leia = comando.ExecuteReader();//enviando uma variavel que irá realizar uma leitura dos dados
            if (leia.HasRows)
            {
                //int x = 0;
                while (leia.Read())
                {
                    //  x++;
                    ClassUsuarios linha = new ClassUsuarios();
                    linha.Codigo = Convert.ToInt32(leia["codigo"]);
                    linha.Nome = Convert.ToString(leia["nome"]);
                    linha.Email = Convert.ToString(leia["email"]);
                    linha.Senha = Convert.ToString(leia["senha"]);
                    cadastro.Add(linha);
                }
            }
            conexao.Close();
            FRNRelatorioUsuarios relatorio = new FRNRelatorioUsuarios();
            relatorio.imprimir(cadastro);
            relatorio.ShowDialog();
            relatorio.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            consultar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            imprimir();
        }
    }
}