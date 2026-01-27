using Microsoft.AspNetCore.Mvc;
using WebAPI.Utils;

namespace RestWithASPNET10Erudio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        //private readonly MathService _service;

        //public MathController(MathService service)
        //{
        //    _service = service;
        //}

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
            {
                var sum = NumberHelper.CovertToDecimal(firstNumber) + NumberHelper.CovertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
            {
                var sum = NumberHelper.CovertToDecimal(firstNumber) - NumberHelper.CovertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
            {
                var division = NumberHelper.CovertToDecimal(firstNumber) / NumberHelper.CovertToDecimal(secondNumber);
                return Ok(division.ToString());
            }
            return Ok("Invalid Input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
            {
                var multiplication = NumberHelper.CovertToDecimal(firstNumber) * NumberHelper.CovertToDecimal(secondNumber);
                return Ok(multiplication.ToString());
            }
            return Ok("Invalid Input");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
            {
                var mean = (NumberHelper.CovertToDecimal(firstNumber) + NumberHelper.CovertToDecimal(secondNumber)) / 2;
                return Ok(mean.ToString());
            }
            return Ok("Invalid Input");
        }

        [HttpGet("square-root/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (NumberHelper.IsNumeric(number))
            {
                var squareRoot = Math.Sqrt((double)NumberHelper.CovertToDecimal(number));
                return Ok(squareRoot.ToString());
            }
            return Ok("Invalid Input");
        }


    }
}