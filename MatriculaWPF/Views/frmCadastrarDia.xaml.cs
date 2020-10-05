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
    /// Interaction logic for frmCadastrarDia.xaml
    /// </summary>
    public partial class frmCadastrarDia : Window
    {
        private Dia dia;
        public frmCadastrarDia()
        {
            InitializeComponent();
            txtDescricao.Focus();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDescricao.Text))
            {
                dia = new Dia
                {
                    Descricao = txtDescricao.Text,
                    Ordenacao = Convert.ToInt32(txtOrdenacao.Text)
                };
                if (DiaDAO.BuscarDiaPorOrdenacao(dia.Ordenacao) == null)
                {
                    if (DiaDAO.Cadastrar(dia))
                    {
                        MessageBox.Show("Dia cadastrado com sucesso!", "Matricula WPF",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        LimparFormulario();
                    }
                    else
                    {
                        MessageBox.Show("Este dia já existe", "Matricula WPF",
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
                MessageBox.Show("Preencha o campo descrição!", "Matricula WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void LimparFormulario()
        {
            //txtId.Clear();
            txtDescricao.Clear();
            txtOrdenacao.Clear();
            //txtCriadoEm.Clear();
            //txtNome.Focus();
            btnCadastrar.IsEnabled = true;
            //btnAlterar.IsEnabled = false;
            //btnRemover.IsEnabled = false;
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            LimparFormulario();
        }
    }
}
