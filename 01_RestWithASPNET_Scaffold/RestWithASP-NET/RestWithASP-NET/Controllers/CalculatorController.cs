using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASP_NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (!IsValidNumber(firstNumber) || !IsValidNumber(secondNumber))
            {
                return BadRequest("Invalid number format");
            }

            // Realize a lógica do cálculo aqui
            // Por exemplo:
            // double result = Convert.ToDouble(firstNumber) + Convert.ToDouble(secondNumber);

            // Retorna o resultado do cálculo
            // return Ok(result);

            // Por enquanto, vamos apenas retornar uma mensagem de sucesso para fins de exemplo
            return Ok("GET endpoint called with firstNumber: " + firstNumber + " and secondNumber: " + secondNumber);
        }

        private bool IsValidNumber(string number)
        {
            // Adicione validação adicional conforme necessário
            // Por exemplo, você pode verificar se o número é um número válido
            return !string.IsNullOrEmpty(number);
        }
    }
}
