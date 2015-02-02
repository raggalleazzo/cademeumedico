using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Repository;

namespace CadeMeuMedico.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        [HttpGet]
        public JsonResult AutenticacaoUsuario(string login, string senha)
        {
            if (UsuarioRepository.AutenticarUsuario(login, senha))
            {
                return Json(new 
                {
                    OK = true,
                    Mensagem = "Usuário autenticado. Redirecionando..."
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    OK = false,
                    Mensagem = "Usuário não encontrado. Tente novamente!"
                }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
