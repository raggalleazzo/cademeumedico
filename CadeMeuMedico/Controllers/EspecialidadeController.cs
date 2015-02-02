using CadeMeuMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CadeMeuMedico.Controllers
{
    public class EspecialidadeController : Controller
    {
        //
        // GET: /Especialidade/

        EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();

        //Listar especialidades
        public ActionResult Index()
        {
            var especialidades = db.Especialidade.ToList();
            return View(especialidades);
        }

        //Abrir tela para adicionar especialidade
        public ActionResult Adicionar()
        {
            return View();
        }

        //Enviar cadastro de especialidade
        [HttpPost]
        public ActionResult Adicionar(Especialidade especialidade)
        {
            if (ModelState.IsValid)
            {
                db.Especialidade.Add(especialidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidade);
        }

        //Abrir tela para alterar especialidade
        public ActionResult Alterar(long id)
        {
            Especialidade especialidade = db.Especialidade.Find(id);
            return View(especialidade);
        }

        //Enviar alteração de especialidade
        [HttpPost]
        public ActionResult Alterar(Especialidade especialidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidade);
        }

        //Enviar uma requisição para excluir uma especialidade
        [HttpPost]
        public string excluir(long id)
        {
            try
            {
                Especialidade especialidade = db.Especialidade.Find(id);
                db.Especialidade.Remove(especialidade);
                db.SaveChanges();
                return Boolean.TrueString;
            }
            catch
            {
                return Boolean.FalseString;
            }
        }
    }
}
