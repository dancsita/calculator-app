using System;
using System.ComponentModel.DataAnnotations;

namespace CalculatorApp.Models
{
    public class CalculationDetails
    {
        public DateTime LogDate { get; set; }
    
        [Required(ErrorMessage = "Please select an operation")]
        public OperationType? Operation { get; set; }

        [Display(Name = "First number:")]
        [Range(0, 1)]
        public double FirstNumber { get; set; }

        [Display(Name = "Second number:")]
        [Range(0, 1)]
        public double SecondNumber { get; set; }

        [Display(Name = "Solution:")]
        public double OperationOutput { get; set; }
    }

    public enum OperationType
    {
        CombinedWith,
        Either
    }
}