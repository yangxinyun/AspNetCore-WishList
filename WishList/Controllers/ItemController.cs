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
        private readonly ApplicationDbContext _context;
        public ItemController(ApplicationDbContext dbcontext)
        {
            this._context = dbcontext;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var it = _context.items.FirstOrDefault(e => e.ID == id);
            _context.items.Remove(it);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var model = _context.items.ToList();
            return View("Index",model);
        }
    }
}
