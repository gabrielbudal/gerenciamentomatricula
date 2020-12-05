using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatriculaWEB.DAL;
using MatriculaWEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatriculaWEB.Controllers
{
    [Route("api/ConjuntoAluno")]
    [ApiController]
    public class ConjuntoAlunoAPIController : ControllerBase
    {
        private readonly ConjuntoAlunoDAO _conjuntoalunoDAO;
        private readonly TurmaDAO _turmaDAO;
        private readonly AlunoDAO _alunoDAO;
        public ConjuntoAlunoAPIController(ConjuntoAlunoDAO conjuntoalunoDAO,
            TurmaDAO turmaDAO,
            AlunoDAO alunoDAO)
        {
            _conjuntoalunoDAO = conjuntoalunoDAO;
            _turmaDAO = turmaDAO;
            _alunoDAO = alunoDAO;
        }

        // GET: /api/ConjuntoAluno/Listar
        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            List<ConjuntoAluno> conjuntoalunos = _conjuntoalunoDAO.Listar();
            if(conjuntoalunos.Count > 0 )
            {
                return Ok(conjuntoalunos);
            }
            return BadRequest(new {msg = "Pesquisa não retornou resultado!"});
        }


        // GET: /api/ConjuntoAluno/Buscar/1
        [HttpGet]
        [Route("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            ConjuntoAluno conjuntoaluno = _conjuntoalunoDAO.BuscarConjuntoAlunoPorId(id);
            if (conjuntoaluno != null)
            {
                return Ok(conjuntoaluno);
            }
            return NotFound(new { msg = "Conjunto aluno não localizado!" });
        }
    }
}
