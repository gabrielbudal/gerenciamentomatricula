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
        public frmCadastrarDisciplina()
        {
            InitializeComponent();
            txtNome.Focus();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNome.Text))
            {
                Disciplina disciplina = new Disciplina
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
        }
    }
}
