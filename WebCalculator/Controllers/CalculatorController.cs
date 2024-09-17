using Microsoft.AspNetCore.Mvc;
using WebCalculator.Models;

namespace WebCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly Calculator _calculator;

        public CalculatorController()
        {
            var operationFactory = new OperationFactory();
            _calculator = new Calculator(operationFactory);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        public IActionResult Index(CalculatorModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Expression))
            {
                model.ErrorMessage = "Введите выражение для вычисления.";
                return View(model);
            }

            try
            {
                model.Result = _calculator.Evaluate(model.Expression);
                model.ErrorMessage = null;
            }
            catch (DivideByZeroException ex)
            {
                model.ErrorMessage = ex.Message;
            }
            catch (FormatException)
            {
                model.ErrorMessage = "Некорректный формат числа. Проверьте вводимые значения.";
            }
            catch (InvalidOperationException ex)
            {
                model.ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                model.ErrorMessage = $"Ошибка: {ex.Message}";
            }

            return View(model);
        }
    }
}
