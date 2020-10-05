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
    /// Interaction logic for frmCadastrarRelacionamentoMentorDisciplina.xaml
    /// </summary>
    public partial class frmCadastrarRelacionamentoMentorDisciplina : Window
    {
        private MentorDisciplina mentordisciplina;
        public frmCadastrarRelacionamentoMentorDisciplina()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Carregar os dados de mentores
            cboMentores.ItemsSource = MentorDAO.Listar();
            //cboMentores.DisplayMemberPath = "Nome";
            cboMentores.SelectedValuePath = "Id";

            //Carregar os dados da disciplina
            cboDisciplinas.ItemsSource = DisciplinaDAO.Listar();
            //cboDisciplinas.DisplayMemberPath = "Nome";
            cboDisciplinas.SelectedValuePath = "Id";
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            //if (cboMentores.SelectedValue ?? null && cboDisciplinas.SelectedValue ?? null)
            //{
            //int idmentor = (int)cboMentores.SelectedValue;
            //int iddisciplina = (int)cboDisciplinas.SelectedValue;
            //MessageBox.Show($"ID mentor: {id} - ID disciplina: {iddisc}");

             
                mentordisciplina = new MentorDisciplina();
                Mentor m = new Mentor();
                Disciplina d = new Disciplina();
                mentordisciplina.Descricao = txtDescricao.Text;

                //colocar throw exception aqui para quando nao vir informado dados na combobox
                m.Id = (int)cboMentores.SelectedValue;
                d.Id = (int)cboDisciplinas.SelectedValue;

                m = MentorDAO.BuscarMentorPorId(m.Id);
                if (m != null)
                {
                    mentordisciplina.Mentor = m;
                    d = DisciplinaDAO.BuscarDisciplinaPorId(d.Id);

                    if (d != null)
                    {
                        mentordisciplina.Disciplina = d;
                        if (MentorDisciplinaDAO.Cadastrar(mentordisciplina))
                        {
                        MessageBox.Show("Atrelamento realizado com sucesso!", "Matricula WPF",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        LimparFormulario();
                        }
                        else
                        {
                        MessageBox.Show("Atrelamento já existente!", "Matricula WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                        LimparFormulario();
                        }
                    }
                    else
                    {
                    MessageBox.Show("Disciplina não localizada", "Matricula WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    LimparFormulario();
                }
                }
                else
                {
                MessageBox.Show("Mentor não localizado!", "Matricula WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
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
