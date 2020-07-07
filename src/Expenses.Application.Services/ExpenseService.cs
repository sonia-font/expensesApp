using Expenses.Data;
using System;
using System.Collections.Generic;

namespace Expenses.Application.Services
{
    public class ExpenseService : IExpenseService
    {
        IExpenseRepo repo;

        public ExpenseService(IExpenseRepo expenseRepo)
        {
            repo = expenseRepo;
        }

        public Expense Add(DateTime date, string concept, double cost, Category category)
        {
            if (string.IsNullOrWhiteSpace(concept))
            {
                throw new ArgumentNullException(nameof(concept));
            }
            if (cost <= 0.00)
            {
                throw new ArgumentException("Value can't be cero or negative");
            }
            if (date == null)
            {
                date = DateTime.Now;
            }

            Expense expense = new Expense();

            expense.Date = date;
            expense.Concept = concept;
            expense.Cost = cost;
            expense.Category = category;

            repo.Add(expense);
            return expense;
        }

        public void Delete(Expense expense)
        {            
            if (expense == null)
            {
                throw new Exception("Nothing to delete");
            }

            repo.Delete(expense);
        }

        public Expense Get(int id)
        {
            Expense expense = repo.GetById(id);

            if (expense == null)
            {
                throw new Exception("Not found");
            }

            return expense;
        }

        public IEnumerable<Expense> GetAll()
        {
            IEnumerable<Expense> expenses = repo.GetAll();

            return expenses;
        }

        public IEnumerable<Expense> GetAll(Category category)
        {
            IEnumerable<Expense> expenses = repo.GetByFilter(exp => exp.Category == category);

            return expenses;
        }

        public IEnumerable<Expense> GetAll(DateTime init, DateTime end)
        {
            if (init > end)
            {
                throw new ArgumentException("Initial date must be older than end date");
            }

            IEnumerable<Expense> expenses = repo.GetByFilter(exp => exp.Date <= end && exp.Date >= init);

            return expenses;
        }

        public Expense Update(int id, DateTime date, string concept, double cost, Category category)
        {
            Expense expense = repo.GetById(id);

            if (expense == null)
            {
                throw new Exception("Not found");
            }

            expense.Date = date;
            expense.Concept = concept;
            expense.Cost = cost;
            expense.Category = category;

            repo.Update(expense);
            return expense;
        }
    }
}
