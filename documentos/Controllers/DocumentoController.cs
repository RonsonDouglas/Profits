using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Teste;
using documentos.Data;
using MySql.Data.MySqlClient;



namespace documentos.Controllers
{
    public class DocumentoController : Controller
    {
        private documentosContext db = new documentosContext();

        // GET: Documento
        public async Task<ActionResult> Index()
        {



            List<Documento> tese = new List<Documento>();
            tese.Add(new Documento
            {
                id = 1,
                codigo = "3",
                titulo = "Teste",
                data = new DateTime(),
                revisao = "A",
                valor = 2012
            });


            List<Documento> documento = await db.Documento.ToListAsync();

            return View(documento);
        }

        // GET: Documento/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documento documento = await db.Documento.FindAsync(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        // GET: Documento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Documento/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,codigo,titulo,revisao,data,valor")] Documento documento)
        {
            if (ModelState.IsValid)
            {
                
                documento.data = new DateTime(2023,2,2);
                db.Documento.Add(documento);
                await db.SaveChangesAsync();

            }
            
            return View(documento);
        }

        // GET: Documento/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documento documento = await db.Documento.FindAsync(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,codigo,titulo,revisao,data,valor")] Documento documento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(documento);
        }

        // GET: Documento/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documento documento = await db.Documento.FindAsync(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        // POST: Documento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Documento documento = await db.Documento.FindAsync(id);
            db.Documento.Remove(documento);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
