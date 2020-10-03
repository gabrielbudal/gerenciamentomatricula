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
    /// Interaction logic for frmCadastrarTurma.xaml
    /// </summary>
    public partial class frmCadastrarTurma : Window
    {
        private Turma turma;
        public frmCadastrarTurma()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Carregar os dados de adms
            cboAdms.ItemsSource = AdministracaoHorarioDAO.Listar();
            //cboAdms.DisplayMemberPath = "Nome";
            cboAdms.SelectedValuePath = "Id";

            //Carregar os dados de niveis
            cboNiveis.ItemsSource = NivelDAO.Listar();
            //cboNiveis.DisplayMemberPath = "Nome";
            cboNiveis.SelectedValuePath = "Id";
        }
        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            //if (cboAdms.SelectedValue ?? null && cboNiveis.SelectedValue ?? null)
            //{
            //int idmentor = (int)cboAdms.SelectedValue;
            //int iddisciplina = (int)cboNiveis.SelectedValue;
            //MessageBox.Show($"ID mentor: {id} - ID disciplina: {iddisc}");


            turma = new Turma();
            AdministracaoHorario a = new AdministracaoHorario();
            Nivel n = new Nivel();
            turma.Descricao = txtDescricao.Text;

            //colocar throw exception aqui para quando nao vir informado dados na combobox
            a.Id = (int)cboAdms.SelectedValue;
            n.Id = (int)cboNiveis.SelectedValue;

            n = NivelDAO.BuscarNivelPorId(n.Id);
            if (n != null)
            {
                turma.Nivel = n;
                a = AdministracaoHorarioDAO.BuscarAdmPorId(a.Id);

                if (a != null)
                {
                    turma.AdministracaoHorario = a;
                    if (TurmaDAO.Cadastrar(turma))
                    {
                        MessageBox.Show("Atrelamento realizado com sucesso!", "Matricula WPF",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        LimparFormulario();
                    }
                    else
                    {
                        MessageBox.Show("Atrelamento já existente!", "Matricula WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                        LimparFormulario();
                    }
                }
                else
                {
                    MessageBox.Show("Administração não localizada", "Matricula WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparFormulario();
                }
            }
            else
            {
                MessageBox.Show("Nível não localizado!", "Matricula WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                LimparFormulario();
            }
        }
        private void LimparFormulario()
        {
            //cboMentores.ClearValue();
            //txtNome.Clear();
            //txtCpf.Clear();
            //txtCriadoEm.Clear();
            //txtNome.Focus();
            //btnCadastrar.IsEnabled = true;
            //btnAlterar.IsEnabled = false;
            //btnRemover.IsEnabled = false;
        }
    }
}
