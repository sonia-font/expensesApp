using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expenses.Data
{
    public class Expense : Entity
    {
        #region Properties

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Concept { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public double Cost { get; set; }

        public Category Category { get; set; }

        #endregion
    }

    #region Enums

    public enum Category
    {
        All,
        Services,
        Commute,
        Entertainment,
        Food        
    }

    #endregion
}
