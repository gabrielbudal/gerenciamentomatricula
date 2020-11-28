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
    /// Interaction logic for frmManterPresenca.xaml
    /// </summary>
    public partial class frmManterPresenca : Window
    {
        private List<Presenca> presencas = new List<Presenca>();
        public frmManterPresenca()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnCadastrar.IsEnabled = false;
            //Dia da semana de hoje para carregar as grades
            //DateTime dataatual = DateTime.Now.AddDays(+14);
            DateTime dataatual = DateTime.Now;
            string datavalidador = dataatual.ToString("dddd");
            //Lista de presenças de hoje
            List<Presenca> presencasfeitashoje = new List<Presenca>();
            //Aqui nao precisa ser uma lista, posso fazer apenas um firstordefault da mesma consulta,
            //pq se um cara do ConjuntoAluno tem presenca gravada, o mesmo se aplica pro resto
            //presencasfeitashoje = PresencaDAO.ListarPresencasHoje(dia, dataatual)

            //Lista de grades de hoje
            //List<Grade> gradesfeitashoje = new List<Grade>();
            //gradesfeitashoje = presencasfeitashoje;
            //Carregar os dados da grade
            //cboGrades.ItemsSource = TurmaDAO.ListarGradeHoje(dia);
            cboGrades.ItemsSource = GradeDAO.ListarGradeHoje(datavalidador);
            string datalabel = dataatual.ToString("dd/MM/yyyy h:mm tt");
            string dia = dataatual.ToString("dddd");
            //cboAdms.DisplayMemberPath = "Nome";
            cboGrades.SelectedValuePath = "Id";
            labelDia.Content = "Dia da semana: " + Convert.ToString(dia);
            labelData.Content = datalabel;

        }
        private void PopularDataGrid(Presenca presenca)
        {
            presencas.Add(new Presenca
            {
                Grade = presenca.Grade,
                ConjuntoAluno = presenca.ConjuntoAluno,
                Presente = presenca.Presente
            });
        }
        private void cboGrades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            presencas.Clear();
            dtaConjuntoAlunos.ItemsSource = presencas;
            dtaConjuntoAlunos.Items.Refresh();
            //Carregar os dados da grade selecionada
            Grade g = new Grade();
            g.Id = (int)cboGrades.SelectedValue;
            g = GradeDAO.BuscarGradePorId(g.Id);

            //A partir da grade obteve a turma
            int idturma = g.Turma.Id;
            //dtaConjuntoAlunos.Columns.IndexOf.ckbPresente;

            //A partir da turma obteve conjunto aluno que preencherá a grid
            var conjuntoaluno = ConjuntoAlunoDAO.BuscarConjuntoAlunoPorIdTurma(idturma);
            foreach (var ca in conjuntoaluno)
            {
                Presenca newpresenca = new Presenca();
                newpresenca.ConjuntoAluno = ca;
                newpresenca.Presente = true;
                newpresenca.Grade = g;
                //conjuntoalunos.Add(newconjuntoaluno);
                PopularDataGrid(newpresenca);
            }
            if (presencas != null && presencas.Count > 0)
            {
                dtaConjuntoAlunos.ItemsSource = presencas;
                dtaConjuntoAlunos.Items.Refresh();
                btnCadastrar.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Não existem registros para esta busca!", "Matricula WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                presencas.Clear();
                dtaConjuntoAlunos.ItemsSource = presencas;
                dtaConjuntoAlunos.Items.Refresh();
                btnCadastrar.IsEnabled = false;
            }
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            int contadorjacadastrado = 0;
            foreach (var pa in presencas)
            {
                //Instanciando novo objeto cada vez que o loop roda para não inserir 
                //duas vezes na mesma entrada no EF
                Presenca newpresenca = new Presenca();
                newpresenca.ConjuntoAluno = pa.ConjuntoAluno;
                newpresenca.Grade = pa.Grade;
                newpresenca.Presente = pa.Presente;
                if (PresencaDAO.Cadastrar(newpresenca))
                {

                }
                else
                {
                    contadorjacadastrado++;
                }
            }
            if (contadorjacadastrado > 0)
            {
                MessageBox.Show("Já foi preenchida a lista de presença dessa grade hoje!", "Matricula WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Lista de presença preenchida com sucesso!", "Matricula WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }
    }
}
