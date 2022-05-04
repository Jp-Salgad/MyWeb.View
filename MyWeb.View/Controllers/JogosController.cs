using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MyView.Model;


namespace MyWeb.View.Controllers
{
    public class JogosController : Controller
    {
        DB_JogosContext odb;
        public JogosController()
        {

            odb = new DB_JogosContext();
        }
        // GET: JogosController
        public ActionResult Index()
        {
            List<DboTbjogos> oLista = odb.DboTbjogos.ToList();
            return View(oLista);
        }

        // GET: JogosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JogosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JogosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DboTbjogos oJog)
        {
            odb.DboTbjogos.Add(oJog);
            odb.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: JogosController/Edit/5
        public ActionResult Edit(int id)
        {
            DboTbjogos oJog = odb.DboTbjogos.Find(id);
            return View(oJog);
        }

        // POST: JogosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DboTbjogos oJog)
        {
            var oJogBanco = odb.DboTbjogos.Find(id);
            oJogBanco.Jogo = oJog.Jogo;
            odb.Entry(oJogBanco).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            odb.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: JogosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JogosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
