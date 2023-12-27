using Microsoft.AspNetCore.Mvc;
using WebApplicationDZmodel11.Data;
using System.Collections;
using WebApplicationDZmodel11.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationDZmodel11.Controllers
{
    public class CatalogController : Controller
    {
        private readonly AppAddContext _context;

        public CatalogController(AppAddContext context) => _context = context;

        // Страница общего каталога:
        public IActionResult Index()
        {
            List<ModelDB> tovari = _context.modelDB.ToList();
            return View(tovari);
        }

        [HttpGet]   // Данные получаемые по URL
        public ActionResult AddItem()
        {
            return View();
        }

        // Добавление нового товара:
        [HttpPost]   // Данные получаемые из формы
        public IActionResult AddItem(ModelDB modeldb) 
        {
            if(ModelState.IsValid)
            {
                _context.modelDB.Add(modeldb);
                _context.SaveChanges();

                return Redirect("/catalog");
            }

            return View();
        }

        // Метод для изменения товара:
        [Route("catalog/{id:int}/formedit")]
        public IActionResult formedit(ModelDB modeldb, int id)
        {
            List<ModelDB> tovari = _context.modelDB.Where(el => el.Id == id).ToList();
            return View(tovari);
        }

        // Редактирование товара:
        [HttpPost]
        [Route("catalog/{id:int}/edit")]
        public IActionResult edit(ModelDB modeldb, int id)
        {
             ModelDB tovarToUpdate = _context.modelDB.Find(id);


                tovarToUpdate.Name = modeldb.Name;
                tovarToUpdate.Anons = modeldb.Anons;
                tovarToUpdate.Fulltext = modeldb.Fulltext;

                _context.modelDB.Update(tovarToUpdate);
                _context.SaveChanges();

            return Redirect("/catalog");
        }

        // Удаление товара
        [HttpPost]
        [Route("catalog/{id:int}/delete")]
        public IActionResult delete(int id)
        {
            ModelDB tovarToRemove = _context.modelDB.Find(id);

            if (tovarToRemove != null)
            {
                _context.modelDB.Remove(tovarToRemove);
                _context.SaveChanges();
            }

            return Redirect("/catalog");
        }
    }
}