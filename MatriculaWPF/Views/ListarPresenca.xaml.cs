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
    /// Interaction logic for ListarPresenca.xaml
    /// </summary>
    public partial class ListarPresenca : Window
    {
        private List<Presenca> presencas = new List<Presenca>();
        private List<dynamic> itens = new List<dynamic>();
        public ListarPresenca()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Grade> gradesfeitashoje = new List<Grade>();
            //Carregar os dados da grade
            cboTurmas.ItemsSource = TurmaDAO.Listar();
            //cboAdms.DisplayMemberPath = "Nome";
            cboTurmas.SelectedValuePath = "Id";
        }

        private void PopularDataGrid(Presenca presenca)
        {
            itens.Add(new
            {
                Grade = presenca.Grade,
                ConjuntoAluno = presenca.ConjuntoAluno,
                Presente = presenca.Presente,
                Data = presenca.Data.ToString("dd/MM/yyyy hh:mm")
            });
        }
        private void cboGrades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            itens.Clear();
            dtaConjuntoAlunos.ItemsSource = itens;
            dtaConjuntoAlunos.Items.Refresh();
            //Carregar os dados da grade selecionada
            Turma t = new Turma();
            t.Id = (int)cboTurmas.SelectedValue;

            var listgrades = GradeDAO.ListarPorTurma(t.Id);
            var listpresencas = PresencaDAO.ListarPresencasPorListaGrade(listgrades);
            foreach (var pa in listpresencas)
            {
                //Presenca newpresenca = new Presenca();
                //newpresenca.ConjuntoAluno = pa.ConjuntoAluno;
                //newpresenca.Presente = pa.Presente;
                //newpresenca.Grade = pa.Grade;
                //conjuntoalunos.Add(newconjuntoaluno);
                PopularDataGrid(pa);
            }
            if (itens != null && itens.Count > 0) 
            {
                dtaConjuntoAlunos.ItemsSource = itens;
                dtaConjuntoAlunos.Items.Refresh();
            } 
            else
            {
            MessageBox.Show("Não existem registros para esta busca!", "Matricula WPF",
                MessageBoxButton.OK, MessageBoxImage.Error);
                itens.Clear();
                dtaConjuntoAlunos.ItemsSource = itens;
                dtaConjuntoAlunos.Items.Refresh();
            }
        }
    }
}
