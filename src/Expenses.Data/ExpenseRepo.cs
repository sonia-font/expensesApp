using System;
using System.Collections.Generic;
using System.Text;

namespace Expenses.Data
{
    public class ExpenseRepo : Repository<Expense>, IExpenseRepo
    {
        public ExpenseRepo(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
