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
    /// Interaction logic for frmCadastrarHistoricoAluno.xaml
    /// </summary>
    public partial class frmCadastrarHistoricoAluno : Window
    {
        private HistoricoAluno historicoaluno;
        public frmCadastrarHistoricoAluno()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Carregar os dados de mentores
            cboNiveis.ItemsSource = NivelDAO.Listar();
            //cboNiveis.DisplayMemberPath = "Nome";
            cboNiveis.SelectedValuePath = "Id";

            //Carregar os dados da disciplina
            cboAlunos.ItemsSource = AlunoDAO.Listar();
            //cboAlunos.DisplayMemberPath = "Nome";
            cboAlunos.SelectedValuePath = "Id";
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            //if (cboNiveis.SelectedValue ?? null && cboAlunos.SelectedValue ?? null)
            //{
            //int idmentor = (int)cboNiveis.SelectedValue;
            //int iddisciplina = (int)cboAlunos.SelectedValue;
            //MessageBox.Show($"ID mentor: {id} - ID disciplina: {iddisc}");


            historicoaluno = new HistoricoAluno();
            Nivel n = new Nivel();
            Aluno a = new Aluno();

            //colocar throw exception aqui para quando nao vir informado dados na combobox
            n.Id = (int)cboNiveis.SelectedValue;
            a.Id = (int)cboAlunos.SelectedValue;

            n = NivelDAO.BuscarNivelPorId(n.Id);
            if (n != null)
            {
                historicoaluno.Nivel = n;
                a = AlunoDAO.BuscarAlunoPorId(a.Id);

                if (a != null)
                {
                    historicoaluno.Aluno = a;
                    if (HistoricoAlunoDAO.Cadastrar(historicoaluno))
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
                    MessageBox.Show("Aluno não localizado", "Matricula WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparFormulario();
                }
            }
            else
            {
                MessageBox.Show("Nivel não localizado!", "Matricula WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                LimparFormulario();
            }
        }
        // else
        //{
        //MessageBox.Show("Preencha todos os campos!", "Matricula WPF",
        //MessageBoxButton.OK, MessageBoxImage.Error);
        //}
        //}
        private void LimparFormulario()
        {
            //cboNiveis.ClearValue();
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
