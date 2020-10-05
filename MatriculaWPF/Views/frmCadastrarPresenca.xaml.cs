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
    /// Interaction logic for frmCadastrarPresenca.xaml
    /// </summary>
    public partial class frmCadastrarPresenca : Window
    {
        private Grade grade;
        public frmCadastrarPresenca()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Carregar os dados da grade
            cboGrades.ItemsSource = GradeDAO.Listar();
            //cboAdms.DisplayMemberPath = "Nome";
            cboGrades.SelectedValuePath = "Id";


        }
        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            //if (cboAdms.SelectedValue ?? null && cboNiveis.SelectedValue ?? null)
            //{
            //int idmentor = (int)cboAdms.SelectedValue;
            //int iddisciplina = (int)cboNiveis.SelectedValue;
            //MessageBox.Show($"ID mentor: {id} - ID disciplina: {iddisc}");


            grade = new Grade();
            Turma t = new Turma();
            MentorDisciplina md = new MentorDisciplina();
            Dia d = new Dia();

            //colocar throw exception aqui para quando nao vir informado dados na combobox
            //t.Id = (int)cboTurmas.SelectedValue;
            //md.Id = (int)cboMentorDisciplinas.SelectedValue;
            //d.Id = (int)cboDias.SelectedValue;

            t = TurmaDAO.BuscarTurmaPorId(t.Id);
            if (t != null)
            {
                grade.Turma = t;
                md = MentorDisciplinaDAO.BuscarMentorDisciplinaPorId(md.Id);

                if (md != null)
                {
                    grade.MentorDisciplina = md;
                    d = DiaDAO.BuscarDiaPorId(d.Id);
                    if (d != null)
                    {
                        grade.Dia = d;
                        if (GradeDAO.Cadastrar(grade))
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
                        MessageBox.Show("Dia não localizado", "Matricula WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                        LimparFormulario();
                    }
                }
                else
                {
                    MessageBox.Show("Relação entre mentor e disciplina não localizada", "Matricula WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    LimparFormulario();
                }
            }
            else
            {
                MessageBox.Show("Turma não localizada!", "Matricula WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
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
            //txtHorarioInicio.Clear();
            //txtHorarioFim.Clear();
        }

        private void cboGrades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Carregar os dados de alunos
            Grade g = new Grade();
            g.Id = (int)cboGrades.SelectedValue;
            g = GradeDAO.BuscarGradePorId(g.Id);
            //ta.

            //ConjuntoAluno ca = new ConjuntoAluno();
            //ca.Turma = g.Turma;
            int idturma = g.Turma.Id;
            cboConjuntoAlunos.ItemsSource = ConjuntoAlunoDAO.BuscarConjuntoAlunoPorIdTurma(idturma);
        }
    }
}
