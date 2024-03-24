using Microsoft.AspNetCore.Mvc;
using Web_API.Model;
using Domain;

namespace purchaseCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly Calculator _CalculatorDomain;

        public CalculatorController() 
        {
            _CalculatorDomain = new Calculator();
        }

        [HttpGet("VATCalculator")]
        public VATCalculatorModel VATCalculator(double Price, double VAT, double PnV, double Percentage)
        {
            return _CalculatorDomain.VATCalculator(Price, VAT, PnV, Percentage);
        }
    }
}
