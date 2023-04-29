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
    public partial class FRNManutProfessor : Form
    {
        string cnsql = "";
        public FRNManutProfessor(string cn)
        {
            InitializeComponent();
            cnsql = cn;
        }

        //função CONSULTAR
        private void consultar()
        {
            dataGridView1.Rows.Clear();//limpando os dados do grid
            string sql = "select * from professor ORDER BY NOME";//enviando uma instrução em sql para o banco
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando o caminho onde está alocado o banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//enviando o caminho e a instrução em sql para o banco
            conexao.Open();//abrindo conexão

            MySqlDataReader leia = comando.ExecuteReader();//enviando uma variavel que irá realizar uma leitura dos dados

            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto o leia estiver encontrando dados ele vai exibir as informações no grid, registro por registro
                {
                    dataGridView1.Rows.Add(Convert.ToString(leia["codigo"]), Convert.ToString(leia["nome"]),
                    Convert.ToString(leia["formacao"]), Convert.ToString(leia["endereco"]), Convert.ToString(leia["cep"]), Convert.ToString(leia["cidade"]),
                    Convert.ToString(leia["senha"]), Convert.ToString(leia["datanasc"]));
                }
            }
            else
            {
                MessageBox.Show("Nenhum Registro Encontrado!");
            }
            conexao.Close();
        }

        private void inserir()
        {
            string sql = "insert into professor (nome,datanasc,formacao,endereco,cep,cidade,senha) values (@nome,@datanasc,@formacao,@endereco,@cep,@cidade,@senha)";
            //enviando uma instrução em sql para a variavel com nome de sql

            MySqlConnection conexao = new MySqlConnection(cnsql);
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.Add("@nome", MySqlDbType.VarChar).Value = textBox1.Text;
            comando.Parameters.Add("@datanasc", MySqlDbType.Date).Value = dateTimePicker1.Value;
            comando.Parameters.Add("@formacao", MySqlDbType.VarChar).Value = textBox2.Text;
            comando.Parameters.Add("@endereco", MySqlDbType.VarChar).Value = textBox3.Text;
            comando.Parameters.Add("@cep", MySqlDbType.VarChar).Value = textBox4.Text;
            comando.Parameters.Add("@cidade", MySqlDbType.VarChar).Value = textBox6.Text;
            comando.Parameters.Add("@senha", MySqlDbType.VarChar).Value = textBox7.Text;

            conexao.Open();//abrindo conexão com o banco


            int result = comando.ExecuteNonQuery();
            //criando uma variavel do tipo inteiro que vai verificar se o banco existe,
            //se existe a tabela
            //se existe os campos e se os campos são do especificados

            if (result > 0)
            {
                MessageBox.Show("Dados inseridos com sucesso!");

                //chamando a função do CLICK do botão limpar
                button3_Click(null, null);

                consultar();//CHAMANDO A FUNÇÃO CONSULTAR dentro da função INSERIR
            }
            else
            {
                MessageBox.Show("Erro!");
            }
        }

        private void alterar()
        {
            string sql = "update professor set nome=@nome,datanasc=@datanasc,formacao=@formacao,endereco=@endereco,cep=@cep,cidade=@cidade,senha=@senha where codigo='" + textBox5.Text + "'";
            //enviando uma instrução em sql para a variavel com nome de sql

            MySqlConnection conexao = new MySqlConnection(cnsql);
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.Add("@nome", MySqlDbType.VarChar).Value = textBox1.Text;
            comando.Parameters.Add("@datanasc", MySqlDbType.Date).Value = dateTimePicker1.Value;
            comando.Parameters.Add("@formacao", MySqlDbType.VarChar).Value = textBox2.Text;
            comando.Parameters.Add("@endereco", MySqlDbType.VarChar).Value = textBox3.Text;
            comando.Parameters.Add("@cep", MySqlDbType.VarChar).Value = textBox4.Text;
            comando.Parameters.Add("@cidade", MySqlDbType.VarChar).Value = textBox6.Text;
            comando.Parameters.Add("@senha", MySqlDbType.VarChar).Value = textBox7.Text;

            conexao.Open();//abrindo conexão com o banco


            int result = comando.ExecuteNonQuery();
            //criando uma variavel do tipo inteiro que vai verificar se o banco existe,
            //se existe a tabela
            //se existe os campos e se os campos são do especificados

            if (result > 0)
            {
                MessageBox.Show(result + " Registro alterado com sucesso!");

                //chamando a função do CLICK do botão limpar
                button3_Click(null, null);

                consultar();//CHAMANDO A FUNÇÃO CONSULTAR dentro da função INSERIR
            }
            else
            {
                MessageBox.Show("Erro! - Dados não alterados");
            }
        }

        private void excluir()
        {
            string sql = "delete from professor where codigo = '" + textBox5.Text + "'";
            //enviando uma instrução em sql para a variavel com nome de sql
            MySqlConnection conexao = new MySqlConnection(cnsql);
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            conexao.Open();//abrindo conexão com o banco
            int result = comando.ExecuteNonQuery();
            //criando uma variavel do tipo inteiro que vai verificar se o banco existe,
            //se existe a tabela
            //se existe os campos e se os campos são do especificados
            if (result > 0)
            {
                MessageBox.Show(result + " Registro Excluido com Sucesso!");
                //chamando a função limpar
                button3_Click(null, null);
                consultar();//CHAMANDO A FUNÇÃO CONSULTAR dentro da função INSERIR
            }
            else
            {
                MessageBox.Show("Erro! Registro não Excluido!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Preencha os campos!");
            }
            else if (textBox5.Text == "")
            {
                inserir();
            }
            else
            {
                alterar();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            consultar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear(); 
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            excluir();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
            textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
            textBox5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
            textBox6.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);
            textBox7.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value);
        }

        private void dataGridView1_CellContextMenuStripChanged(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
            textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
            textBox5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
            textBox6.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);
            textBox7.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime dataAtual = DateTime.Now;
            string sql = "select * from professor where datanasc=@datanasc";
            MessageBox.Show("Seu aniversario é hoje: " + dataAtual.ToString("dd/MM"));
            dataGridView1.Rows.Clear();
            MySqlConnection conexao = new MySqlConnection(cnsql);
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.Add("@datanasc", MySqlDbType.Date).Value = dataAtual;
            conexao.Open();

            MySqlDataReader leia = comando.ExecuteReader();

            if (leia.HasRows)
            {
                while (leia.Read())
                {
                    dataGridView1.Rows.Add(Convert.ToString(leia["codigo"]), Convert.ToString(leia["nome"]),
                    Convert.ToString(leia["formacao"]), Convert.ToString(leia["endereco"]), Convert.ToString(leia["cep"]), Convert.ToString(leia["cidade"]),
                    Convert.ToString(leia["senha"]), Convert.ToString(leia["datanasc"]));
                }
            }
            else
            {
                MessageBox.Show("Nenhum Registro Encontrado!");
            }
            conexao.Close();
        }
    }
}
