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
    /// Interaction logic for frmCadastrarAdministracaoHorario.xaml
    /// </summary>
    public partial class frmCadastrarAdministracaoHorario : Window
    {
        private AdministracaoHorario administracaohorario;
        public frmCadastrarAdministracaoHorario()
        {
            InitializeComponent();
            txtHoraComeco.Focus();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtHoraComeco.Text) && !string.IsNullOrEmpty(txtHoraFim.Text) && !string.IsNullOrEmpty(txtTotal.Text))
            {
                administracaohorario = new AdministracaoHorario
                {
                    HoraInicio = txtHoraComeco.Text,
                    HoraFim = txtHoraFim.Text,
                    TotalAulas = Convert.ToInt32(txtTotal.Text)
                };
                    AdministracaoHorarioDAO.Cadastrar(administracaohorario);
                    MessageBox.Show("Administração cadastrada com sucesso!", "Matricula WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparFormulario();
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
            txtHoraComeco.Clear();
            txtHoraFim.Clear();
            txtTotal.Clear();
            txtHoraComeco.Focus();
            btnCadastrar.IsEnabled = true;
            btnAlterar.IsEnabled = false;
            btnRemover.IsEnabled = false;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
