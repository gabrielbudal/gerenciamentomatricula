using MatriculaWPF.DAL;
using MatriculaWPF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MatriculaWPF.Views
{
    /// <summary>
    /// Interaction logic for frmCadastrarDisciplina.xaml
    /// </summary>
    public partial class frmCadastrarDisciplina : Window
    {
        private Disciplina disciplina;
        public frmCadastrarDisciplina()
        {
            InitializeComponent();
            txtNome.Focus();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNome.Text))
            {
                disciplina = new Disciplina
                {
                    Nome = txtNome.Text,
                    Descricao = txtDescricao.Text
                };
                if (DisciplinaDAO.Cadastrar(disciplina))
                {
                    MessageBox.Show("Disciplina cadastrada com sucesso!", "Matricula WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparFormulario();
                }
                else
                {
                    MessageBox.Show("Esta disciplina já existe", "Matricula WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Preencha o campo nome!", "Matricula WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void LimparFormulario()
        {
            txtId.Clear();
            txtNome.Clear();
            txtDescricao.Clear();
            txtCriadoEm.Clear();
            txtNome.Focus();
            btnCadastrar.IsEnabled = true;
            btnAlterar.IsEnabled = false;
            btnRemover.IsEnabled = false;
        }
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                disciplina = DisciplinaDAO.BuscarDisciplinaPorNome(txtNome.Text);
                if (disciplina != null)
                {
                    btnCadastrar.IsEnabled = false;
                    btnAlterar.IsEnabled = true;
                    btnRemover.IsEnabled = true;

                    txtId.Text = disciplina.Id.ToString();
                    txtNome.Text = disciplina.Nome;
                    txtDescricao.Text = disciplina.Descricao;
                    txtCriadoEm.Text = disciplina.CriadoEm.ToString();
                }
                else
                {
                    MessageBox.Show("Esta disciplina não existe!!!", "Vendas WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    LimparFormulario();
                }
            }
            else
            {
                MessageBox.Show("Preencha o campo nome!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            LimparFormulario();
        }
        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            if (disciplina != null)
            {
                DisciplinaDAO.Remover(disciplina);
                MessageBox.Show("Disciplina foi removida com sucesso!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("A disciplina não foi removida!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            LimparFormulario();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (disciplina != null)
            {
                disciplina.Nome = txtNome.Text;
                disciplina.Descricao = txtDescricao.Text;
                DisciplinaDAO.Alterar(disciplina);
                MessageBox.Show("A disciplina foi alterada com sucesso!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("A disciplina não foi alterada!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            LimparFormulario();
        }
    }
}
