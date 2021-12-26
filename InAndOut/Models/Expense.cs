using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Expense")]
        [Required]
        public string ExpenseName { get; set; }

        [DisplayName("Amount")]
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Amount must be > zero!")]
        public int Amt { get; set; }
    }
}
