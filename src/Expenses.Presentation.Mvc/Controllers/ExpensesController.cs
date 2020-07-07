using System;
using System.Collections.Generic;
using System.Linq;
using Expenses.Application.Services;
using Expenses.Data;
using Expenses.Presentation.Mvc.Models;
using Microsoft.AspNetCore.Mvc;


namespace Expenses.Presentation.Mvc.Controllers
{
    public class ExpensesController : Controller
    {
        IExpenseService expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            this.expenseService = expenseService;
        }

        // GET: Expenses
        public ActionResult Index(DateTime init, DateTime end, Category category)
        {
            DateTime emptyDate = DateTime.Parse("1/1/0001");
            List<Expense> expenses = expenseService.GetAll().ToList();

            if (init != emptyDate && end != emptyDate)
            {
                expenses = expenseService.GetAll(init, end).ToList();
            }
            if (category != Category.All)
            {
               expenses = expenses.Where(e => e.Category == category).ToList();
            }

            return View(expenses);
        }

        // GET: Expenses/Details/5
        public ActionResult Details(int id)
        {
            Expense expense = expenseService.Get(id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expenses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Date,Concept,Cost,Category")] Expense expense)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    expenseService.Add(expense.Date, expense.Concept, expense.Cost, expense.Category);
                    return RedirectToAction(nameof(Index));
                }                
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. Try again.");
            }
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public ActionResult Edit(int id)
        {
            Expense expense = expenseService.Get(id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }

        // POST: Expenses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Date,Concept,Cost,Category")] Expense expense)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    expenseService.Update(id, expense.Date, expense.Concept, expense.Cost, expense.Category);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. Try again.");
            }
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public ActionResult Delete(int id)
        {
            Expense expense = expenseService.Get(id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expense expense = expenseService.Get(id);

            try
            {
                expenseService.Delete(expense);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Delete), new { id = id });
            }
        }
    }
}