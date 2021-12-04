using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula08112021
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cliente c = new Cliente();
            dgvListar.DataSource = c.listar();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente(0, txtNome.Text, txtCidade.Text, txtEstado.Text);
            if (c.cadastrar())
                MessageBox.Show("Cadastrado com sucesso!");
            else
                MessageBox.Show("Erro ao cadastrar");
            dgvListar.DataSource = c.listar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente(Convert.ToInt32(lblId.Text), txtNome.Text, txtCidade.Text, txtEstado.Text);
            if (c.atualizar())
                MessageBox.Show("Dados atualizados!");
            else
                MessageBox.Show("Erro ao atualizar");
            dgvListar.DataSource = c.listar();
        }

        private void dgvListar_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Cliente c = new Cliente();
            int id = Convert.ToInt32(dgvListar.Rows[e.RowIndex].Cells[0].Value);
            var resposta = c.listarPorCodigo(id);
            lblId.Text = resposta.Codigo.ToString();
            txtNome.Text = resposta.Nome;
            txtCidade.Text = resposta.Cidade;
            txtEstado.Text = resposta.Estado;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente();
            int codigo = Convert.ToInt32(lblId.Text);
            if (c.deletar(codigo))
                MessageBox.Show("Dados excluídos!");
            else
                MessageBox.Show("Erro ao excluir");
            dgvListar.DataSource = c.listar();
        }
    }
    }


