using CadeMeuMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CadeMeuMedico.Controllers
{
    public class CidadeController : Controller
    {
        //
        // GET: /Cidade/

        public EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();

        //Listar cidades
        public ActionResult Index()
        {
            var cidades = db.Cidade.ToList();
            return View(cidades);
        }

        //Abrir tela para adicionar cidade
        public ActionResult Adicionar()
        {
            return View();
        }

        //Enviar cadastro de cidade
        [HttpPost]
        public ActionResult Adicionar(Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Cidade.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cidade);
        }

        //Abrir tela para alterar cidade
        public ActionResult Alterar(long id)
        {
            Cidade cidade = db.Cidade.Find(id);
            return View(cidade);
        }

        //Enviar alteração de cidade
        [HttpPost]
        public ActionResult Alterar(Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cidade);
        }

        //Enviar uma requisição para excluir uma cidade
        [HttpPost]
        public string Excluir(long id)
        {
            try
            {
                Cidade cidade = db.Cidade.Find(id);
                db.Cidade.Remove(cidade);
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
