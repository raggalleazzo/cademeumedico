using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models;
using System.Data.Entity;

namespace CadeMeuMedico.Controllers
{
    public class MedicoController : Controller
    {
        //
        // GET: /Medico/

        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();

        //Listar médicos
        public ActionResult Index()
        {
            var medicos = db.Medico.Include("Cidade").Include("Especialidade").ToList();
            return View(medicos);
        }

        //Abrir tela para adicionar médico
        public ActionResult Adicionar()
        {
            ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade", "Nome");
            ViewBag.IDEspecialidade = new SelectList(db.Especialidade, "IDEspecialidade", "Nome");
            return View();
        }

        //Enviar cadastro de médico
        [HttpPost]
        public ActionResult Adicionar(Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Medico.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidade, "IDEspecialidade", "Nome", medico.IDEspecialidade);

            return View(medico);
        }

        //Abrir tela para alterar médico
        public ActionResult Alterar(long id)
        {
            Medico medico = db.Medico.Find(id);

            ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidade, "IDEspecialidade", "Nome", medico.IDEspecialidade);
            
            return View(medico);
        }

        //Enviar alteração de médico
        [HttpPost]
        public ActionResult Alterar(Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidade, "IDEspecialidade", "Nome", medico.IDEspecialidade);

            return View(medico);
        }

        //Enviar uma requisição para exculir um médico
        [HttpPost]
        public string Excluir(long id)
        {
            try
            {
                Medico medico = db.Medico.Find(id);
                db.Medico.Remove(medico);
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
