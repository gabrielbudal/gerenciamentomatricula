using MatriculaWPF.DAL;
using MatriculaWPF.Models;
using MatriculaWPF.Utils;
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
    /// Interaction logic for frmCadastrarAluno.xaml
    /// </summary>
    public partial class frmCadastrarAluno : Window
    {
        private Aluno aluno;
        public frmCadastrarAluno()
        {
            InitializeComponent();
            txtNome.Focus();
        }
        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrWhiteSpace(txtCpf.Text))
            {
                aluno = new Aluno
                {
                    Nome = txtNome.Text,
                    Cpf = txtCpf.Text
                };
                if (Validacao.ValidarCpf(aluno.Cpf))
                {
                    if (AlunoDAO.Cadastrar(aluno))
                    {
                        MessageBox.Show("Aluno cadastrado com sucesso!", "Matricula WPF",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        LimparFormulario();
                    }
                    else
                    {
                        MessageBox.Show("Este aluno já existe", "Matricula WPF",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("CPF inválido", "Matricula WPF",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!", "Matricula WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void LimparFormulario()
        {
            txtId.Clear();
            txtNome.Clear();
            txtCpf.Clear();
            txtCriadoEm.Clear();
            txtNome.Focus();
            btnCadastrar.IsEnabled = true;
            btnAlterar.IsEnabled = false;
            btnRemover.IsEnabled = false;
        }
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCpf.Text))
            {
                aluno = AlunoDAO.BuscarAlunoPorCpf(txtCpf.Text);
                if (aluno != null)
                {
                    btnCadastrar.IsEnabled = false;
                    btnAlterar.IsEnabled = true;
                    btnRemover.IsEnabled = true;

                    txtId.Text = aluno.Id.ToString();
                    txtNome.Text = aluno.Nome;
                    txtCpf.Text = aluno.Cpf.ToString();
                    txtCriadoEm.Text = aluno.CriadoEm.ToString();
                }
                else
                {
                    MessageBox.Show("Esse aluno não existe!!!", "Vendas WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    LimparFormulario();
                }
            }
            else
            {
                MessageBox.Show("Preencha o campo do CPF!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            LimparFormulario();
        }
        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            if (aluno != null)
            {
                AlunoDAO.Remover(aluno);
                MessageBox.Show("O aluno foi removido com sucesso!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("O aluno não foi removido!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            LimparFormulario();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (aluno != null)
            {
                aluno.Nome = txtNome.Text;
                aluno.Cpf = txtCpf.Text;
                AlunoDAO.Alterar(aluno);
                MessageBox.Show("O aluno foi alterado com sucesso!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("O aluno não foi alterado!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            LimparFormulario();
        }
    }
}
