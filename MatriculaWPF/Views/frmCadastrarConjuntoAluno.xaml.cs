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
    /// Interaction logic for frmCadastrarConjuntoAluno.xaml
    /// </summary>
    public partial class frmCadastrarConjuntoAluno : Window
    {
        private ConjuntoAluno conjuntoaluno = new ConjuntoAluno();
        private List<dynamic> itens = new List<dynamic>();
        private List<Aluno> alunos = new List<Aluno>();
        public frmCadastrarConjuntoAluno()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //carregar dados de turmas
            cboTurmas.ItemsSource = TurmaDAO.Listar();
            //cboTurmas.DisplayMemberPath = "Nome";
            cboTurmas.SelectedValuePath = "Id";

            //carregar dados de alunos
            cboAlunos.ItemsSource = AlunoDAO.Listar();
            //cboTurmas.DisplayMemberPath = "Nome";
            cboAlunos.SelectedValuePath = "Id";
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            int idturma = (int)cboTurmas.SelectedValue;
            Turma turma = TurmaDAO.BuscarTurmaPorId(idturma);

            int idaluno = (int)cboAlunos.SelectedValue;
            Aluno aluno = AlunoDAO.BuscarAlunoPorId(idaluno);

            PopularDataGrid(turma,aluno);
            //PopularConjuntoLista(aluno);
            alunos.Add(aluno);
            dtaConjuntoAlunos.ItemsSource = itens;
            dtaConjuntoAlunos.Items.Refresh();
            cboTurmas.IsEnabled = false;
        }

        private void PopularDataGrid (Turma turma, Aluno aluno)
        {
            itens.Add(new
            {
                //Descricao = turma.Descricao.ToString(),
                Nome = aluno.Nome.ToString(),
                Cpf = aluno.Cpf.ToString()
            });
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            int idTurma = (int)cboTurmas.SelectedValue;
            foreach (var ca in alunos)
            {
                //Instanciando novo objeto cada vez que o loop roda para não inserir 
                //duas vezes na mesma entrada no EF
                ConjuntoAluno newconjuntoaluno = new ConjuntoAluno();
                newconjuntoaluno.Aluno = ca;
                conjuntoaluno.Turma = TurmaDAO.BuscarTurmaPorId(idTurma);
                //newconjuntoaluno.Descricao = ca.Nome + " (" + ca.Cpf + ")";
                newconjuntoaluno.Turma = conjuntoaluno.Turma;
                ConjuntoAlunoDAO.Cadastrar(newconjuntoaluno);
            }
            MessageBox.Show("Conjunto cadastrado com sucesso!!!");
        }
    }
}
