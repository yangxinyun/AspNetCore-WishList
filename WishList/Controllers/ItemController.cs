using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext Dbcontext;
        public ItemController(ApplicationDbContext dbcontext)
        {
            this.Dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Item item)
        {
            Dbcontext.items.Add(item);
            Dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var it = Dbcontext.items.FirstOrDefault(e => e.ID == id);
            Dbcontext.items.Remove(it);
            Dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var model = Dbcontext.items.ToList();
            return View("Index",model);
        }
    }
}
