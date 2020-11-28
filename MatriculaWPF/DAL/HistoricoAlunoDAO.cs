using MatriculaWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatriculaWPF.DAL
{
    class HistoricoAlunoDAO
    {
        private static Context _context = SingletonContext.GetInstance();
        public static bool Cadastrar(HistoricoAluno historicoaluno)
        {
            if (BuscarHistoricoAluno(historicoaluno) == null)
            {
                _context.HistoricoAlunos.Add(historicoaluno);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public static List<HistoricoAluno> Listar() => _context.HistoricoAlunos.ToList();
        public static HistoricoAluno BuscarHistoricoAluno(HistoricoAluno historicoaluno) => _context.HistoricoAlunos.Where(ha => ha.Nivel == historicoaluno.Nivel && ha.Aluno == historicoaluno.Aluno)
                    .FirstOrDefault();
    }
}
