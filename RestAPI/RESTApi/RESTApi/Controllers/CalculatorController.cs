using Microsoft.AspNetCore.Mvc;

namespace RESTApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber,string secondNumber)
        {
            if(isDecimal(firstNumber) && isDecimal(secondNumber))
            {
                var sum = convertToDecimal(firstNumber) + convertToDecimal(secondNumber);

                return Ok(sum);
            }

            return BadRequest("Values are not decimal");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Mult(string firstNumber, string secondNumber)
        {
            if (isDecimal(firstNumber) && isDecimal(secondNumber))
            {
                var mult = convertToDecimal(firstNumber) * convertToDecimal(secondNumber);

                return Ok(mult);
            }

            return BadRequest("Values are not decimal");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if (isDecimal(firstNumber) && isDecimal(secondNumber))
            {
                var sub = convertToDecimal(firstNumber) - convertToDecimal(secondNumber);

                return Ok(sub);
            }

            return BadRequest("Values are not decimal");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (isDecimal(firstNumber) && isDecimal(secondNumber))
            {
                var secondNum = convertToDecimal(secondNumber);
                if (secondNum == 0)
                {
                    return  BadRequest("Second number can't be 0");
                }
                var mult = convertToDecimal(firstNumber) / secondNum;

                return Ok(mult);
            }

            return BadRequest("Values are not decimal");
        }
        [HttpGet("med/{firstNumber}/{secondNumber}")]
        public IActionResult Med(string firstNumber, string secondNumber)
        {
            if (isDecimal(firstNumber) && isDecimal(secondNumber))
            {
                var media = (convertToDecimal(firstNumber) + convertToDecimal(secondNumber))/2;

                return Ok(media);
            }

            return BadRequest("Values are not decimal");
        }

        [HttpGet("squareRoot/{number}")]
        public IActionResult squareRoot(string number)
        {
            if (isDecimal(number))
            {
                var num = convertToDecimal(number);
                if(num >=0)
                {
                    return Ok(Math.Sqrt((double)num));
                }
                else
                {
                    return BadRequest("Can't calculate the square root of a negative number");
                }
            }

            return BadRequest("Values are not decimal");
        }
        private decimal convertToDecimal(string number)
        {
            return Convert.ToDecimal(number);
        }

        private bool isDecimal(string firstNumber)
        {
           return decimal.TryParse(firstNumber, out _);
        }
    }
}