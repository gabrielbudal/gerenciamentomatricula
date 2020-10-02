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
        public frmCadastrarMentor()
        {
            InitializeComponent();
            txtNome.Focus();
        }
        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtNome.Text))
            {
                Mentor mentor = new Mentor
                {
                    Nome = txtNome.Text,
                    Cpf = txtCpf.Text
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
                    Console.WriteLine("CPF inválido!!!");
                }
            }
            else
            {
                MessageBox.Show("Preencha o campo nome!", "Matricula WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LimparFormulario ()
        {
            txtId.Clear();
            txtNome.Clear();
            txtCpf.Clear();
            txtCriadoEm.Clear();
            txtNome.Focus();
        }
    }
}
