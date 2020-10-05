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
    /// Interaction logic for frmCadastrarNivel.xaml
    /// </summary>
    public partial class frmCadastrarNivel : Window
    {
        private Nivel nivel;
        public frmCadastrarNivel()
        {
            InitializeComponent();
            txtNome.Focus();
        }
        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNome.Text))
            {
                nivel = new Nivel
                {
                    Nome = txtNome.Text,
                    Ordenacao = Convert.ToInt32(txtOrdenacao.Text)
                };
                if (NivelDAO.BuscarNivelPorOrdenacao(nivel.Ordenacao) == null) { 
                    if (NivelDAO.Cadastrar(nivel))
                    {
                        MessageBox.Show("Nível cadastrado com sucesso!", "Matricula WPF",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        LimparFormulario();
                    }
                    else
                    {
                        MessageBox.Show("Este nível já existe", "Matricula WPF",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Esta ordenação já existe", "Matricula WPF",
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
            txtOrdenacao.Clear();
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
                nivel = NivelDAO.BuscarNivelPorNome(txtNome.Text);
                if (nivel != null)
                {
                    btnCadastrar.IsEnabled = false;
                    btnAlterar.IsEnabled = true;
                    btnRemover.IsEnabled = true;

                    txtId.Text = nivel.Id.ToString();
                    txtNome.Text = nivel.Nome;
                    txtOrdenacao.Text = nivel.Ordenacao.ToString();
                    txtCriadoEm.Text = nivel.CriadoEm.ToString();
                }
                else
                {
                    MessageBox.Show("Este nível não existe!!!", "Vendas WPF",
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
            if (nivel != null)
            {
                NivelDAO.Remover(nivel);
                MessageBox.Show("Nível foi removido com sucesso!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("O nível não foi removida!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            LimparFormulario();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (nivel != null)
            {
                nivel.Nome = txtNome.Text;
                nivel.Ordenacao = Convert.ToInt32(txtOrdenacao.Text);
                NivelDAO.Alterar(nivel);
                MessageBox.Show("O nível foi alterada com sucesso!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("O nível não foi alterado!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            LimparFormulario();
        }
    }
}
