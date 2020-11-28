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
    /// Interaction logic for frmCadastrarMentor.xaml
    /// </summary>
    public partial class frmCadastrarMentor : Window
    {
        private Mentor mentor;
        public frmCadastrarMentor()
        {
            InitializeComponent();
            txtNome.Focus();
        }
        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrWhiteSpace(txtCpf.Text))
            {
                mentor = new Mentor
                {
                    Nome = txtNome.Text,
                    Cpf = txtCpf.Text,
                    Sobrenome = txtSobrenome.Text
                };
                if (Validacao.ValidarCpf(mentor.Cpf))
                {
                    if (MentorDAO.Cadastrar(mentor))
                    {
                        MessageBox.Show("Mentor cadastrado com sucesso!", "Matricula WPF",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        LimparFormulario();
                    }
                    else
                    {
                        MessageBox.Show("Este mentor já existe", "Matricula WPF",
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

        private void LimparFormulario ()
        {
            txtId.Clear();
            txtNome.Clear();
            txtSobrenome.Clear();
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
                mentor = MentorDAO.BuscarMentorPorCpf(txtCpf.Text);
                if (mentor != null)
                {
                    btnCadastrar.IsEnabled = false;
                    btnAlterar.IsEnabled = true;
                    btnRemover.IsEnabled = true;

                    txtId.Text = mentor.Id.ToString();
                    txtNome.Text = mentor.Nome;
                    txtSobrenome.Text = mentor.Sobrenome;
                    txtCpf.Text = mentor.Cpf.ToString();
                    txtCriadoEm.Text = mentor.CriadoEm.ToString();
                }
                else
                {
                    MessageBox.Show("Esse mentor não existe!!!", "Vendas WPF",
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
            if (mentor != null)
            {
                MentorDAO.Remover(mentor);
                MessageBox.Show("O mentor foi removido com sucesso!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("O mentor não foi removido!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            LimparFormulario();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (mentor != null)
            {
                mentor.Nome = txtNome.Text;
                mentor.Cpf = txtCpf.Text;
                mentor.Sobrenome = txtSobrenome.Text;
                MentorDAO.Alterar(mentor);
                MessageBox.Show("O mentor foi alterado com sucesso!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("O mentor não foi alterado!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            LimparFormulario();
        }
    }
}
