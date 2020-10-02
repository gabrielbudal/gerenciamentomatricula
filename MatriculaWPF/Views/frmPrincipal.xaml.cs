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
    /// Interaction logic for frmPrincipal.xaml
    /// </summary>
    public partial class frmPrincipal : Window
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void menuSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void menuCadastrarDisciplina_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarDisciplina frm = new frmCadastrarDisciplina();
            frm.ShowDialog();
        }
        private void menuCadastrarMentor_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarMentor frm = new frmCadastrarMentor();
            frm.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("Deseja realmente sair?", "Matricula WPF",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultado == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
