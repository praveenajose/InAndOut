using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;
            return View(objList);
        }

        //Get - Create
        public IActionResult Create()
        {
            return View();
        }
        
        //Post - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense obj)
        {
            if(ModelState.IsValid)
            {
                _db.Expenses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //Get - Delete
        public IActionResult Delete(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }

            var obj = _db.Expenses.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //Post - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.Expenses.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.Expenses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get - Update
        public IActionResult Update(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var obj = _db.Expenses.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //Post - Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }


    }
}
