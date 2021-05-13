using CalculatorApp.Models;
using System;
using System.Configuration;
using System.IO;
using System.Web.Mvc;

namespace CalculatorApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult CalculationForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculationForm(CalculationDetails calculationDetails)
        {
            if (ModelState.IsValid)
            {
                var firstNo = calculationDetails.FirstNumber;
                var secondNo = calculationDetails.SecondNumber;
                var multipliedValue = Multiply(firstNo, secondNo);

                if (calculationDetails.Operation == OperationType.CombinedWith)
                {
                    calculationDetails.OperationOutput = multipliedValue;
                }
                else if(calculationDetails.Operation == OperationType.Either)
                {
                    calculationDetails.OperationOutput = Add(firstNo, secondNo) - multipliedValue;
                }

                LogCalculationToFile(calculationDetails);
                ViewBag.Output = calculationDetails.OperationOutput;
            }
            
            return View("Index", calculationDetails);
        }

        public double Multiply(double numberA, double numberB)
        {
            return numberA * numberB;
        }

        public double Add(double numberA, double numberB)
        {
            return numberA + numberB;
        }

        public void LogCalculationToFile(CalculationDetails calculationDetails)
        {
            string logFilePath = ConfigurationManager.AppSettings["LogFilePath"].ToString();
            calculationDetails.LogDate = DateTime.Now;

            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, append: true))
                {
                    foreach (var calculationProperty in calculationDetails.GetType().GetProperties())
                    {
                        writer.Write(calculationProperty.GetValue(calculationDetails) + "\t");
                    }
                    writer.WriteLine();
                }
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Error occured during logging: " + ex.Message);
            }
        }

    }
}