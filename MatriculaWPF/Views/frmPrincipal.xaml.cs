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

        private void menuCadastrarRelacionamentoMentorDisciplina_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarRelacionamentoMentorDisciplina frm = new frmCadastrarRelacionamentoMentorDisciplina();
            frm.ShowDialog();
        }

        private void menuCadastrarAluno_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarAluno frm = new frmCadastrarAluno();
            frm.ShowDialog();
        }

        private void menuCadastrarNivel_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarNivel frm = new frmCadastrarNivel();
            frm.ShowDialog();
        }

        private void menuCadastrarHistoricoAluno_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarHistoricoAluno frm = new frmCadastrarHistoricoAluno();
            frm.ShowDialog();
        }
        private void menuCadastrarAdministracaoHorario_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarAdministracaoHorario frm = new frmCadastrarAdministracaoHorario();
            frm.ShowDialog();
        }

        private void menuCadastrarTurma_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarTurma frm = new frmCadastrarTurma();
            frm.ShowDialog();
        }

        private void menuCadastrarConjuntoAlunos_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarConjuntoAluno frm = new frmCadastrarConjuntoAluno();
            frm.ShowDialog();
        }
    }
}
