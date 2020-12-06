using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWEB.Utils
{
    public class Sessao
    {
        private readonly IHttpContextAccessor _http;
        public Sessao(IHttpContextAccessor http) => _http = http;
        private const string TURMA_ID = "TURMA_ID";
        private const string TIPO_USUARIO = "TIPO_USUARIO";

        public int BuscarTurmaId(int idturma)
        {
            if(_http.HttpContext.Session.GetInt32(TURMA_ID) == null)
            {
                _http.HttpContext.Session.SetInt32(TURMA_ID, idturma);
            }
            return (int)_http.HttpContext.Session.GetInt32(TURMA_ID);
        }
        public string BuscarTipoUsuario(string tipousuario)
        {
            if (_http.HttpContext.Session.GetString(TIPO_USUARIO) == null)
            {
                _http.HttpContext.Session.SetString(TIPO_USUARIO, tipousuario);
            }
            return _http.HttpContext.Session.GetString(TIPO_USUARIO);
        }
    }
}
