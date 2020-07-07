using Expenses.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Expenses.Application.Services
{
    public interface IExpenseService
    {
        #region Methods

        IEnumerable<Expense> GetAll();
        IEnumerable<Expense> GetAll(Category category);
        IEnumerable<Expense> GetAll(DateTime init, DateTime end);
        Expense Get(int id);
        Expense Add(DateTime date, string concept, double cost, Category category);
        Expense Update(int id, DateTime date, string concept, double cost, Category category);
        void Delete(Expense expense);

        #endregion
    }
}
