using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreAngular.Models
{
    public class Employee
    {
        [Key]
        [Column("EMPLOYEEID")]
        public int EmployeeId { get; set; }

        [Column("EMPLOYEECODE")]
        [RegularExpression(@"^[-A-Za-z0-9]*$", ErrorMessage = "Invalid Code specified")]
        [Required(ErrorMessage = "Employee Code is a required field")]
        [Display(Name = "Employee Code")]
        public string EmployeeCode { get; set; }

        [Column("FIRSTNAME")]
        [RegularExpression(@"^[-A-Za-z]*$", ErrorMessage = "Invalid First Name specified")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Column("LASTNAME")]
        [RegularExpression(@"^[-A-Za-z]*$", ErrorMessage = "Invalid Last Name specified")]
        [Required(ErrorMessage = "Employee Last Name is a required field")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

    }
}
