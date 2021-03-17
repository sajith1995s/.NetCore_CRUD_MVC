using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_crud_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_crud_MVC.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var displaydata = _db.EmployeeTable.ToList();
            return View(displaydata); 
        }

        public IActionResult Create()
        {
             
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create (Employee emp)
        {
            if (ModelState.IsValid)
            {
                _db.Add(emp);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(emp);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var getempdetails = await _db.EmployeeTable.FindAsync(id);
            return View(getempdetails);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _db.Update(emp);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(emp);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var getempdetails = await _db.EmployeeTable.FindAsync(id);
            return View(getempdetails);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var getempdetails = await _db.EmployeeTable.FindAsync(id);
            return View(getempdetails);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int  id)
        { 
            var getempdetails = await _db.EmployeeTable.FindAsync(id);
            _db.EmployeeTable.Remove(getempdetails);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
